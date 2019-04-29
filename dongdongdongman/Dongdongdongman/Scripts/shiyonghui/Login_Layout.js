jQuery(document).ready(function ($) {
    $('.nav-login').click(function () {
        $('.login-form-mask').fadeIn(100);
        $('.login-form').slideDown(200);
    });
    $('.login-close').click(function () {
        $('.login-form-mask').fadeOut(100);
        $('.login-form').slideUp(200);
    });
    $("#Login_form").validate({
        rules: {
            uname: "required",
            upwd:"required"
        },
        messages: {
            uname: "请输入账号",
            upwd:"请输入密码"
        },
        submitHandler: function (form) {
            $(form).ajaxSubmit();
        }  
    });
  
});
