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
            $.ajax({
                type: "POST",
                url: "/Login/Login",
                data: $('#Login_form').serialize(),
                success: function (reslut) {
                    //提交成功的提示词或者其他反馈代码
                    if (reslut == "0") { alert("账号密码不正确"); }
                    else { alert("登陆成功"); }
                    
                    window.location.href = window.location.href
                },
                error: function () {
                    //提交失败的提示词或者其他反馈代码
                    alert("登陆失败");
                }
            })
            
        }  
    });
  
});
