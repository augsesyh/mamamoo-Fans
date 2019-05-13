jQuery(document).ready(function ($) {


    $("#UP_Register").validate({
        rules: {
            name: {
                required: "required",
                rangelength: [6, 18],
                remote: {                                          //验证用户名是否存在
                    type: "POST",
                    url: "/UP/Findsame",
                    //servlet
                    data: {
                        name: function () { return $("#name").val(); }
                    }
                }
            },
            account: {
                required: "required",
                rangelength: [6, 18],
                remote: {
                    type: "POST",
                    url: "/UP/Findaccount",
                    //servlet
                    data: {
                        account: function () { return $("#account").val(); }
                    }
                }

            },

            email: {
                required: "required",
                email: true,
                remote: {
                    type: "POST",
                    url: "/UP/FindEmail",
                    //servlet
                    data: {
                        Email: function () { return $("#email").val(); }
                    }
                }
            },

            password: {
                required: "required",
                rangelength: [5, 18]
            },
            confirm_pwd: {
                required: "required",
                equalTo: "#password"
            },
            realname: "required"
        },
        messages: {
            name: {
                required: "昵称不能为空",
                rangelength: "昵称位数必须在6到18字符之间！",
                remote: "昵称已经被注册"
            },
            account: {
                required: "账号不能为空",
                rangelength: "账号位数必须在6到18字符之间！",
                remote: "账号已经被注册"
            },
            email: {
                required: "邮箱不能为空",
                email: "邮箱格式不正确",
                remote: "邮箱已被注册"
            },
            password: {
                required: "密码不能为空",
                rangelength: "密码位数必须在{0}到{1}字符之间！"
            },
            confirm_pwd: {
                required: "确认密码不能为空",
                equalTo: "密码不一致"
            },
            realname: "真实姓名不能为空"
        },
        submitHandler: function (form) {
           
            form.submit();
            
            $.ajax({
                type: "POST",
                url: "/UP/Register",
                data: $("#UP_Register").serialize(),
                success: function (reslut) {
                    //提交成功的提示词或者其他反馈代码
                    if (reslut !== "0") { alert("注册成功！"); }
                    else { alert("注册失败"); }

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