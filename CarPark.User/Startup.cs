using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Microsoft.AspNetCore.Localization;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using CarPark.User.Resources;
using System.Reflection;
using Microsoft.AspNetCore.Localization.Routing;
using CarPark.Core.Repository.Abstract;
using CarPark.DataAccess.Repository;
using CarPark.Core.Settings;

using CarPark.DataAccess.Abstract;
using CarPark.Business.Concrete;
using CarPark.DataAccess.Concrete;
using CarPark.Business.Abstract;
using Microsoft.AspNetCore.Identity;
using CarPark.Entities.Concrete;
using MongoDB.Driver;
using AspNetCore.Identity.MongoDbCore.Models;
using AutoMapper;


namespace CarPark.User
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //var mapperConfig = new MapperConfiguration(mc =>
            //{
            //    mc.AddProfile(new MappingProfile());
            //});

            //IMapper mapper = mapperConfig.CreateMapper();
            //services.AddSingleton(mapper);

            //services.AddMvc();
            services.AddAutoMapper(typeof(Startup));
            services.AddAuthentication(option =>
            {
                option.DefaultScheme = IdentityConstants.ApplicationScheme;
                option.DefaultSignInScheme = IdentityConstants.ExternalScheme;
            }).AddIdentityCookies(o =>
            {

            }) ;

            services.AddIdentityCore<Personal>(option =>
            {


            })
                .AddRoles<MongoIdentityRole>()
                .AddMongoDbStores<Personal, MongoIdentityRole, Guid>(Configuration.GetSection("MongoConnection:ConnectionString").Value, Configuration.GetSection("MongoConnection:Database").Value)
                .AddSignInManager()
                .AddDefaultTokenProviders();
            services.ConfigureApplicationCookie(option =>
            {
                option.Cookie.HttpOnly = true;
                option.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                option.LoginPath = "/Account/Login";
                option.SlidingExpiration = true;
            });


            services.AddControllersWithViews();
            services.AddLocalization(opt => { opt.ResourcesPath = "Resources"; });
            services.AddMvc().AddViewLocalization().AddDataAnnotationsLocalization(options =>
            {
                options.DataAnnotationLocalizerProvider = (type, factory) =>
                {
                    var assemblyName = new AssemblyName(typeof(SharedModelResource).GetTypeInfo().Assembly.FullName);
                    return factory.Create(nameof(SharedModelResource), assemblyName.Name);
                };
            });
            services.Configure<MongoSettings>(options =>
            {
                options.ConnectionString = Configuration.GetSection("MongoConnection:ConnectionString").Value;
                options.Database = Configuration.GetSection("MongoConnection:Database").Value;
            });
           
            services.AddScoped(typeof(IRepository<>), typeof(MongoRepositoryBase<>));
            services.AddScoped<IPersonalDal, PersonalDal>();
            services.AddScoped<IPersonalService, PersonalManager>();
            services.AddScoped<ICityDal, CityDal>();
            services.AddScoped<ICityService, CityManager >();
            services.Configure<RequestLocalizationOptions>(opt =>
            {
                var supportedCultures = new List<CultureInfo>
                {
                    new CultureInfo("en-US"),
                    new CultureInfo("tr-TR"),
                    new CultureInfo("ar-SA"),
                };
                opt.DefaultRequestCulture = new RequestCulture("tr-TR");
                opt.SupportedCultures = supportedCultures;
                opt.SupportedUICultures = supportedCultures;
                //opt.RequestCultureProviders = new List<IRequestCultureProvider>
                //{
                //    new QueryStringRequestCultureProvider(),
                //    new CookieRequestCultureProvider(),
                //    new AcceptLanguageHeaderRequestCultureProvider(),
                //};
               
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            var options = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(options.Value);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
