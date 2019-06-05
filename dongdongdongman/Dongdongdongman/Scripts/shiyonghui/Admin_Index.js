jQuery(document).ready(function ($) {
    $(".guanli").click(function () {
        $(".guanli").removeClass("opened");
        $(this).toggleClass("opened");
        $(this).children("ul").toggle("slow");
    });
    $("#file").change(function (e) {
        var file = e.target.files[0] || e.dataTransfer.files[0];
        if (file === null || file === undefined) {
            alert("请选择您要上传的文件！");
            $("#photoCover1").val("");
            return false;
        }
        if (file.type.indexOf('image') === -1) {
            alert("请选择图片文件！");
            return false;
        }
        var size = Math.floor(file.size / 1024);
        if (size > 5000) {
            alert("上传文件不得超过5M!");
            return false;
        }     
        $('#photoCover').val(document.getElementById("file").files[0].name);
        if (file) {
            var reader = new FileReader();
            reader.onload = function () {
                $("#img1").attr("src", this.result);
            };

            reader.readAsDataURL(file);
        }
    });
    $("#file1").change(function (e) {
        var file = e.target.files[0] || e.dataTransfer.files[0];
        if (file === null || file === undefined) {
            alert("请选择您要上传的文件！");
            $("#photoCover1").val("");
            return false;
        }
        if (file.type.indexOf('image') === -1) {
            alert("请选择图片文件！");
            return false;
        }
        var size = Math.floor(file.size / 1024);
        if (size > 5000) {
            alert("上传文件不得超过5M!");
            return false;
        }        

        $('#photoCover1').val(document.getElementById("file1").files[0].name);
        if (file) {
            var reader = new FileReader();
            reader.onload = function () {
                $("#img").attr("src", this.result);
            };

            reader.readAsDataURL(file);
        }
    });
    function saveUser2() {
        var id = $("#id").val().trim();
        var uname = $("#uname").val().trim();
        var pwd = $("#pwd").val().trim();
        var file = document.getElementById("file").files[0];
        var formData = new FormData();
        formData.append('id', id);
        formData.append('uname', uname);
        formData.append('pwd', pwd);
        formData.append('file', file);
        alert(file);
        $.ajax({
            url: "/",
            type: "post",
            data: formData,
            contentType: false,
            processData: false,
            mimeType: "multipart/form-data",
            success: function (data) {
                console.log(data);
            },
            error: function (data) {
                console.log(data);
            }
        });
    }

});