﻿function readUrl(input) {
    if (input.files && input.files[0]) {
        console.log("Hey yo");
        var reader = new FileReader();

        reader.onload = function (e) {
            $(".personalImageUrl").attr('src', e.target.result);
        }
        reader.readAsDataURL(input.files[0]);
    }
}

$("#personalImage").change(function () {
    $(".imgArea").LoadingOverlay("show");
    readUrl(this);
    $(".imgArea").LoadingOverlay("hide");
})

var onFailed = function () {
    $.LoadingOverlay("hide");
}
var onSuccess = function (response) {
    $.LoadingOverlay("hide");
    if (response.success) {
        $("#nameSurnameArea").html(response.personal.name + " " + response.personal.surname);
        Swal.fire(
            'Başarılı',
            response.message,
            'success'
        )
    }
    else {
        Swal.fire(
            'Hata!',
            response.message,
            'error'
        )
    }

}
var onBegin = function () {
    $.LoadingOverlay("show");
}