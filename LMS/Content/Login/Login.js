$(document).ready(function () {

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
    }
}); 