$(document).ready(function () {

    $('#collapse-menu-div').click(function () {
        debugger;
        if ($('#menu-div').is(":hidden")) {
            $("#menu-div").css('display', 'block');
        }
        else {
            $("#menu-div").css('display', 'none');
        }
    });
});