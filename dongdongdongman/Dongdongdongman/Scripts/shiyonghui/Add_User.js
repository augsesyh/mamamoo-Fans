$().ready(function () {
    $("#signin_form").validate({
        rules: {
            name: {
                required: true,
                rangelength:[6,18],
                remote: {                                          //验证用户名是否存在
                    type: "POST",
                    url: "/Login/Findsame",             //servlet
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
                    url: "/Login/Findaccount",             //servlet
                    data: {
                        account: function () { return $("#account").val(); }
                    }
                }
            },
            Email: {
                required: true,
                email: true
            },
            upwd:{
                required: true,
                rangelength:[5,18]
            },
            conupwd: {
                required: true,
                equalTo: "#upwd"
            },
            realname:"required"
        },
        messages: {
            name: {
                required: "昵称不能为空",
                rangelength: jQuery.format("昵称位数必须在{0}到{1}字符之间！"),
                remote: jQuery.format("昵称已经被注册")
            },
            account: {
                required: "账号不能为空",
                rangelength: jQuery.format("账号位数必须在{0}到{1}字符之间！"),
                remote: jQuery.format("账号已经被注册")
            },
            Email: {
                required: "邮箱不能为空"，

            }
        }
    });
});