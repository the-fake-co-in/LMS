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

    $('#hide-error').click(function () {
        HideError();
    });

    function ShowError(errMsg) {
        debugger;
        $("#error-span").css('display', 'block');
        $('#error-msg').html(errMsg);
    };

    function HideError() {
        debugger;
        $("#error-span").css('display', 'none');
        $("#error-span").hide();
        $('#error-msg').html('');
    };

    $('#show-modal').click(function () {
        $("#login-modal").modal('show');
        $('#error-msg').html('');
        GoToLogin();
    });

    function CloseModal() {
        HideError();
        $("#login-modal").modal('hide');
        $('#error-msg').html('');
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
        HideError();
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
        HideError();
        $('#div-login').show('slow')
        $('#div-forgot-pwd').hide('slow')
        $('#div-set-pwd').hide('slow')
    }

    // Validate form for Empty/invalid Fields before submit
    function validateForm() {
        var errorMsg = "";

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
        HideError();
        var username = $('#username').val();
        var password = $('#password').val();
        var headers = { __RequestVerificationToken: $('input[name="__RequestVerificationToken"]').val() };

        debugger;
        var errorMsg = "";
        errorMsg = validateForm()
        if (errorMsg == "") {
            $.ajax({
                url: "Login/VerifyLogin",
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
                    if (data == "Success") {
                        // similar behavior as an HTTP redirect
                        window.location.replace("Login/LMSDashboard");

                        // similar behavior as clicking on a link
                        //window.location.href = "Login/LMSDashBoard";
                    }
                    else {
                        var options = {
                            distance: '40',
                            direction: 'left',
                            times: '3'
                        }
                        debugger;
                        ShowError(data);
                    }
                }
            });
        }
        else {
            debugger;
            ShowError(errorMsg);
        }
    });

}); 