jQuery(document).ready(function ($) {
    $("#admin_login").validate({
        rules: {
            name: "required",
            pwd: "required"
        },
        messages: {
            name: "该空不能为空",
            pwd: "密码不能为空"
        },
        submitHandler: function (form) {
            alert("验证成功");
            form.submit();
        }
    });
});