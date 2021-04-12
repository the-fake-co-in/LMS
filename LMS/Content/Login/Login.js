$(document).ready(function () {
    window.onload = function () {
        $("#login-modal").modal('show');
    }
    function GoToLogin() {
        HideError();
        $('#div-login').show('slow');
        $('#div-forgot-username').hide('slow');
        $('#div-forgot-pwd').hide('slow');
        $('#div-set-pwd').hide('slow');
    }

    function CloseModal() {
        HideError();
        $("#login-modal").modal('hide');
    }

    function ShowError(errorMsg) {
        $('.error-msg').html(errorMsg);
        $('.error-msg').css('display', 'block');
    }

    function HideError(errorMsg) {
        $('.error-msg').html('');
        $('.error-msg').css('display', 'none');
    }

    $('#show-modal').click(function () {
        $("#login-modal").modal('show');
        GoToLogin();
    });

    $('#close-modal, #close-modal-1, #close-modal-2').click(function () {
        CloseModal();
    });

    $('#forgot-username').click(function () {
        $('#div-login').hide('slow');
        $('#div-forgot-username').show('slow');
        $('#div-forgot-pwd').hide('slow');
        $('#div-set-pwd').hide('slow');
    });

    $('#forgot-pwd').click(function () {
        $('#div-login').hide('slow');
        $('#div-forgot-username').hide('slow');
        $('#div-forgot-pwd').show('slow');
        $('#div-set-pwd').hide('slow');
    });

    $('#goto-login, #goto-login-1, #goto-login-2').click(function () {
        GoToLogin();
    });

    $('#send-email-1').click(function () {
        var email = $('#email-1').val();
        if (!email.trim() || email.length == 0) {
            ShowError('Please enter Email!');
        }
        else {
            $.ajax({
                type: 'GET',
                data: { 'email': email },
                url: '/Login/ForgotUserName',
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

    $('#send-email-2').click(function () {
        var username = $('#username-2').val();
        var email = $('#email-2').val();
        if ((!username.trim() || username.length == 0) && (!email.trim() || email.length == 0)) {
            ShowError('Please enter valid UserName & Email!')
        }
        else if (!username.trim() || username.length == 0) {
            ShowError('Please enter valid UserName!');
        }
        if (!email.trim() || email.length == 0) {
            ShowError('Please enter valid Email!');
        }
        else {
            $.ajax({
                type: 'GET',
                data: { 'userName': username, 'email': email },
                url: '/Login/ForgotPassword',
                success: function (response) {
                    if (response == '') {
                        HideError();
                        $.notify('Please check Email to reset your Password!', "success");
                    }
                    else {
                        $.notify(response, "error");
                        ShowError(response);
                    }
                }
            });
        }
    });
}); 