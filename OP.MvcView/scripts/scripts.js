
jQuery(document).ready(function () {

    /*
        Fullscreen background
    */
    $.backstretch("../img/backgrounds/1.jpg");

    /*
        Form validation
    */
    $('.login-form input[type="text"], .login-form input[type="password"], .login-form textarea').on('focus', function () {
        $(this).removeClass('input-error');
    });
    $('.login-form').on('click', function (e) {

        $(this).find('input[type="text"], input[type="password"], textarea').each(function () {
            if ($(this).val() == "") {
                $(this).addClass('input-error');
            }
            else {
                $(this).removeClass('input-error');
            }
        });
        var q = $(this).find('input[type="text"], input[type="password"], textarea').hasClass('input-error');
        console.log(q);
        console.log(e.target.id);
        if (!q && e.target.id == "btnLogin") {
            $('#btnLogin').attr('disabled', true);
            $.ajax({
                async: false,
                data: { uname: $('input[type="text"]').val(), upwd: $(' input[type="password"]').val(), valcode: '' },
                url: '/Account/Login',
                success: function (data) {
                    console.log(data == "sucess");
                    if (data == "sucess") {
                        location.href = "/Home/Index";
                    }
                    else {
                        alert(data);
                    }
                },
                error: function (data) {
                    alert(data);
                },
                complete: function () {
                    $('#btnLogin').attr('disabled', false);
                }
            });
        }
    });
});

