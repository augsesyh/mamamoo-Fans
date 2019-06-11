
jQuery(document).ready(function ($) {
    var btn = document.getElementById("All");
    btn.onclick = function () {
        var flag = this.checked;
        var item = document.getElementsByName("cbox");
       
        for (var i = 0; i < item.length; i++) {
            item[i].checked = flag;
        }
    }
   
    
    $("#del").click(function () {
        
        var ikj = new Array();
        var obj = document.getElementsByName("cbox");
        var obj_length = obj.length;
       
        for (var i = 0; i < obj_length; i++) {
            if (obj[i].checked) {
                ikj.push(obj[i].value);
               
            }
        }
        $.ajax({
            type:"post",
            url:"/admin/Del_More",
            data: { Asid : ikj },
            dataType: "text",
            traditional: true,
            success: function (data) {
                alert("成功");
                $("#pinjia").html(data);
            },
            error: function (error) {
                alert("shibai");
            }
        })
    });
});