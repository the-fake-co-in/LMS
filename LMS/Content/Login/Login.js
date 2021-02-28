$(document).ready(function () {

    //    //Disable submit form by Enter Key Press
    //    $(window).keydown(function (event) {
    //        if (event.keyCode == 13) {
    //            event.preventDefault();
    //            return false;
    //        }
    //    });

    //    $(function () {
    //        var $form = $("#login-form");
    //        $.validator.unobtrusive.parse($form);

    //        $form.on("submit", function (e) {
    //            e.preventDefault();
    //            if ($form.valid()) {
    //                $.ajax({
    //                    url: this.action,
    //                    type: this.method,
    //                    data: $(this).serialize(),
    //                    success: function (data) {
    //                        $("#expense-list-div").html(data);
    //                        $("#expense-dialog").dialog("close");
    //                    }
    //                });
    //            }
    //        });
    //    });

    $('#show-modal').click(function () {
        $("#login-modal").modal('show');
        GoToLogin();
    });

    function CloseModal() {
        $("#login-modal").modal('hide');
    }

    $('#close-modal').click(function () {
        CloseModal();
    });

    $('#close-modal-2').click(function () {
        CloseModal();
    });

    $('#close-modal-3').click(function () {
        CloseModal();
    });


    $('#forgot-pwd').click(function () {
        $('#div-login').hide('slow')
        $('#div-forgot-pwd').show('slow')
        $('#div-set-pwd').hide('slow')
    });

    $('#goto-login').click(function () {
        GoToLogin();
    });

    $('#goto-login-2').click(function () {
        GoToLogin();
    });

    function GoToLogin() {
        $('#div-login').show('slow')
        $('#div-forgot-pwd').hide('slow')
        $('#div-set-pwd').hide('slow')
        alert('GoToLogin');
    }

    // Validate form for Empty/invalid Fields before submit
    function validateForm() {
        var errorMsg = "";
        alert('Validate');

        if ($(username).val().trim().length == 0) {
            if ($(password).val().trim().length == 0) {
                errorMsg = 'Enter UserName & Password...';
            }
            else {
                errorMsg = 'Enter UserName...';
            }
        }
        else if ($(password).val().trim().length == 0) {
            errorMsg = 'Enter Password...';
        }

        return errorMsg;
    };

    $('#Login').click(function () {
        alert('Login');

        var username = $('#username').val();
        var password = $('#password').val();
        var headers = { __RequestVerificationToken: $('input[name="__RequestVerificationToken"]').val() };

        debugger;
        var errorMsg = "";
        errorMsg = validateForm()
        if (errorMsg == "") {
            $.ajax({
                url: "Home/Login",
                method: "Get",
                headers: headers,
                data: { username: username, password: password },
                cache: false,
                beforeSend: function () {
                    debugger;
                    $('#Login').val("Connecting...");
                },
                success: function (data) {
                    $('#Login').val("Login");
                    debugger;
                    if (data.toString().indexOf("Error:") == -1) {
                        $("#main").css("margin-left", "200px");
                        //similar behavior as an HTTP redirect
                        window.location.replace("Home/Dashboard");

                        // similar behavior as clicking on a link
                        //window.location.href = "Home/DashBoard";
                    }
                    else {
                        $.notify(data, "error");
                    }
                }
            });
        }
        else {
            $.notify(errorMsg, "error");
        }
    });

//    $('#logout').click(function () {
//        debugger;
//        alert('Logout');
//        $.ajax({
//            url: "Home/Logout",
//            method: "Get",
//            success: function (data) {
//                debugger;
//                if (data == "Success") {
//                    //similar behavior as an HTTP redirect
//                    window.location.replace("Home/Home");
//                    $("#main").css("margin-left", "200px");
//                    // similar behavior as clicking on a link
//                    //window.location.href = "Home/DashBoard";
//                }
//                else {
//                    debugger;
//                    $.notify(data, "error");
//                }
//            }
//        });
//    });
}); 