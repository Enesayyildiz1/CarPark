using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPark.User
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()

           .WriteTo.Console()
           .WriteTo.File("log.txt")
           .WriteTo.Seq("http://localhost:5341/")
           .WriteTo.MongoDB("mongodb+srv://enesayyildiz:yozgatordu@carparkcluster.bmiv4.mongodb.net/CarParkDB?retryWrites=true&w=majority", "Test")
           .MinimumLevel.Information()
           .Enrich.WithProperty("ApplicationName","CarParkUser")
           .Enrich.WithMachineName()
           
           .CreateLogger();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).UseSerilog();
    }
}
