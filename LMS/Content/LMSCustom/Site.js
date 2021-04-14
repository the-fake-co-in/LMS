$(document).ready(function () {

    $(function () {
        if ($('[type="datetime"]')) {
            $('[type="datetime"]').datepicker();
        }
    });

    window.onload = function () {
        $(".text-box").removeClass("text-box").removeClass("single-line").addClass("form-control").addClass("w-100");

        $('select').removeAttr("htmlattributes").addClass("form-control");

        //$('[type="datetime"]').attr("type", "text");

        $("div[readonly] input").prop("readonly", true);

        $.ajax({
            url: '/Home/GetProfPic',
            type: 'get',
            success: function (response) {
                ChangeProfPic(response, false);
            }
        });
    }

    var blink_color = 0;
    function BlinkText() {
        if (blink_color == 0) {
            $('.blink').css('color', 'Red');
            blink_color = 1;
        }
        else if (blink_color == 1) {
            $('.blink').css('color', 'Yello');
            blink_color = 2;
        }
        else {
            $('.blink').css('color', 'White');
            blink_color = 0;
        }
        $('.blink').fadeIn(500);
        $('.blink').fadeOut(500);
    }

    setInterval(BlinkText, 1000);

    function ChangeProfPic(imgPath, showMsg) {
        if (imgPath != '') {
            if (imgPath.startsWith('Error')) {
                $.notify(imgPath, "error");
            }
            else {
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