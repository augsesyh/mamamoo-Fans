jQuery(document).ready(function ($) {
    $("#inputvalicode").hide();

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
                        alert("发送失败");
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
               
            }

        });
    });
});