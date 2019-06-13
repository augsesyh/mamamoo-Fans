jQuery(document).ready(function ($) {
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
});