jQuery(document).ready(function ($) {
    $("#UP_Login").validate({
        rules: {
            account: "required",
            password: "required"
        },
        messages: {
            account: "请输入账号",
            password: "请输入密码"
        },
        submitHandler: function (form) {
            $.ajax({
                type: "POST",
                url: "/UP/CheckLogin",
                data: $("#UP_Login").serialize(),
                success: function (reslut) {
                    //提交成功的提示词或者其他反馈代码
                    if (reslut === "0") { alert("账号密码不正确"); }
                    else { alert("登录成功"); }

                    window.location.href = window.location.href;
                },
                error: function () {
                    //提交失败的提示词或者其他反馈代码
                    alert("登录失败");
                }
            });
          
        }
    });
});
  
