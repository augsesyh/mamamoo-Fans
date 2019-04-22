jQuery(document).ready(function ($) {
    $('.nav-login').click(function () {
        $('.login-form-mask').fadeIn(100);
        $('.login-form').slideDown(200);
    })
    $('.login-close').click(function () {
        $('.login-form-mask').fadeOut(100);
        $('.login-form').slideUp(200);
    })
})
