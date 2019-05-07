jQuery(document).ready(function ($) {
    $("#inputvalicode").hide();
    $("#Change_password").hide();
    $("#find_pass").click(function () {
        var email = $("#inputEmail").val();
        alert(email);
        if (email === "") {
            alert("输入框不能为空");
            return;
        }
        else {
            var reg = /^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/;
            isok = reg.test(email);
            if (!isok) {
                alert("邮箱格式不正确，请重新输入！");
                $("#inputEmail").val("");
            }
            else {
                $.ajax({
                    type: "Post",
                    url: "/Login/SendValicode",
                    data: $("#inputEmail").serialize(),
                    async: false,
                    error: function (request) {  //失败的话
                        alert("发送失败,该邮箱未注册");
                    },
                    success: function (data) {  //成功
                        alert(data);  //就将返回的数据显示出来
                        $("#inputvalicode").show("slow");
                    }

                }); 
            }
            return;
            
        }
        
       
    });
    $("#find_vali").click(function () {
        $.ajax({
            type: "post",
            url: "/Login/Testvalicode",
            data: $("#valicode").serialize(),
            async: false,
            error: function (request) {  //失败的话
                alert("发送失败");
            },
            success: function (data) {  //成功
                alert(data);  //就将返回的数据显示出来
                $("#Change_password").load(location.href + " #Change_password");
                $("#Change_password").show();
            }

        });
    });
    $("#changepwd").validate({
        rules: {
            newpw: {
                required: true,
                rangelength: [5, 18],
                remote: {
                    type: "POST",
                    url: "/Login/Findpassword",
                    //servlet
                    data: {
                        newpw: function () { return $("#newpw").val(); }
                    }
                }
            },
            conpw: {
                required: true,
                equalTo:"#newpw"
            }
        },
        messages: {
            newpw: {
                required: "密码不能为空",
                rangelength: "密码长度必须在6到18之间",
                remote:"不可与原密码相同"
            },
            conpw: {
                required: "密码不能为空",
                equalTo: "密码不一致"
            },
        },
        submitHandler: function (form) {
            //$.ajax({
            //    type: "POST",
            //    url: "/Login/Changepwd",
            //    data: $('#changepwd').serialize(),
            //    success: function (reslut) {
            //        //提交成功的提示词或者其他反馈代码
            //        if (reslut === "0") { alert("修改失败"); }
            //        else { alert("修改成功"); }

            //        window.location.href = window.location.href;
            //    },
            //    error: function () {
            //        //提交失败的提示词或者其他反馈代码
            //        alert("修改失败");
            //    }
            //});
            alert("验证通过");
            form.submit();
        }
    });
});