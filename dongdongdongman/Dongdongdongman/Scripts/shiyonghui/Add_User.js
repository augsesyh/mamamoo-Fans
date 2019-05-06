jQuery(document).ready(function ($) {
    
    $("#zhuce").attr("disabled", "true");
    $("#Signin_form").validate({
        rules: {
            name: {
                required: true,
                rangelength: [6, 18],
                remote: {                                          //验证用户名是否存在
                    type: "POST",
                    url: "/Login/Findsame",
                    //servlet
                    data: {
                        name: function () { return $("#name").val(); }
                    }
                }
            },
            account: {
                required: true,
                rangelength: [6, 18],
                remote: {
                    type: "POST",
                    url: "/Login/Findaccount",
                    //servlet
                    data: {
                        account: function () { return $("#account").val(); }
                    }
                }

            },
       
        Email: {
            required: true,
            email: true,
            remote: {
                type: "POST",
                url: "/Login/FindEmail",
                //servlet
                data: {
                    Email: function () { return $("#Email").val(); }
                }
            }
            },
            
            upwd: {
                required: true,
                rangelength: [5, 18]
            },
            conupwd: {
                required: true,
                equalTo: "#upwd"
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
            Email: {
                required: "邮箱不能为空",
                email: "邮箱格式不正确",
                Email: "邮箱已被注册"
            },
            upwd: {
                required: "密码不能为空",
                rangelength: "密码位数必须在{0}到{1}字符之间！"
            },
            conupwd: {
                required: "确认密码不能为空",
                equalTo: "密码不一致"
            },
            realname: "真实姓名不能为空"
        },
        submitHandler: function (form) {
            alert("验证成功");
            form.submit();
        }
    });
});