﻿$(document).ready(function () {

    window.onload = function () {
        $(".text-box").removeClass("text-box").removeClass("single-line").addClass("form-control").addClass("w-100");

        $('select').removeAttr("htmlattributes").addClass("form-control");

        $("div[disabled] input").prop("disabled", true);

        $.ajax({
            url: '/Home/GetProfPic',
            type: 'get',
            success: function (response) {
                ChangeProfPic(response, false);
            }
        });
    }

    function ChangeProfPic(imgPath, showMsg) {
        if (imgPath != '') {
            if (imgPath.startsWith('Error')) {
                $.notify(imgPath, "error");
            }
            else {
                $('#profilePic-1').removeAttr("src").attr("src", imgPath);
                $('#profilePic').removeAttr("src").attr("src", imgPath);

                if (showMsg) {
                    $.notify('Profile Picture updated!', "success");
                } 
            }
        }

    }

    var inputFile = document.createElement('input');
    inputFile.type = 'file';

    inputFile.onchange = function () {
        debugger;
        var file = inputFile.files;

        // Check file selected or not
        if (file.length > 0) {
            var fd = new FormData();
            fd.append('file', file[0]);
            $.ajax({
                url: '/Home/ChangeProfPic',
                type: 'post',
                data: fd,
                contentType: false,
                processData: false,
                success: function (response) {
                    ChangeProfPic(response, true);
                }
            });
        }
    };

    $("#profilePic").click(function ChangeProfPic() {
        inputFile.click();
    });

    $('#profilePic').hover(function () {
        $(this).css('cursor', 'pointer');
    });

    function UpdateProfile() {
        $.ajax({
            url: '/Home/UpdateProfile',
            type: 'post',
            data: fd,
            contentType: false,
            processData: false,
            success: function (response) {
                if (response == '') {
                    HideError();
                    $.notify('Please check Email to get your UserName!', "success");
                }
                else {
                    $.notify(response, "error");
                    ShowError(response);
                }
            }
        });
    }
}); 