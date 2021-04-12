$(document).ready(function () {
    window.onload = function () {
        debugger;
        $(".text-box").removeClass("text-box").removeClass("single-line").addClass("form-control").addClass("w-100");

        $('select').removeAttr("htmlattributes").addClass("form-control");

        $("div[disabled] input").prop("disabled", true);
    }
}); 