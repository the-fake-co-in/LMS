$(document).ready(function () {

    //Disable submit form by Enter Key Press
    $(window).keydown(function (event) {
        if (event.keyCode == 13) {
            event.preventDefault();
            return false;
        }
    });

    $('#show-modal').click(function () {
        $("#login-modal").modal('show')
        $('#error-msg').html('')
        GoToLogin();
    });

    function CloseModal() {
        $("#login-modal").modal('hide')
        $('#error-msg').html('')
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

    // Validate form for Empty/invalid Fields before submit
    function validateForm() {
        var errorMsg = "";
        if ($(username).val().trim().length == 0) {
            errorMsg = 'Please enter UserName...</br>';
            $('#div-username').tooltip('show')
        }
        if ($(password).val().trim().length == 0) {
            errorMsg += 'Please enter Password...</br>';
            $('#div-password').tooltip('show')
        }
        return errorMsg;
    };

    $('#Login').click(function () {
        var username = $('#username').val();
        var password = $('#password').val();

        debugger;
        var errorMsg = validateForm();
        if (errorMsg == "") {
            $.ajax({
                url: "Home/VerifyLogin",
                method: "Get",
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
                        window.location.replace("Home/LMSDashboard");

                        // similar behavior as clicking on a link
                        //window.location.href = "Home/LMSDashBoard";
                    }
                    else {
                        var options = {
                            distance: '40',
                            direction: 'left',
                            times: '3'
                        }
                        debugger;
                        $('#error-msg').html(data);
                    }
                }
            });
        }
        else {
            debugger;
            //$('#error-msg').html(errorMsg);
        }
    });

}); 