jQuery(document).ready(function ($) {
    var liList = document.querySelectorAll(".m-chapter-item");
    var e_num = false;
    for (var i = 0; i < liList.length; i++) {
        if (liList.length < 20) {
            $("#zhangkai").hide();
        }
        if (i < 20) {
            liList[i].style.display="";
        }
        else {
            liList[i].style.display = "none";
        }
        e_num = true;
    }
    var x_num = true;
    
    $("#sunxu").click( function () {

        if (x_num === false) {

            for (var i = liList.length - 1; i > -1; i--) {
                document.querySelector(".sr-catalog__bd").appendChild(liList[i]);
               
            }
            x_num = true;
            this.innerHTML = "<span class='sprite-icon_2-order-up sr-icon z-middle'></span>正序";

        } else if (x_num === true) {

            for (var j = 0; j < liList.length; j++) {
                document.querySelector(".sr-catalog__bd").appendChild(liList[j]);
            }
            x_num = false;
            this.innerHTML = "<span class='sprite-icon_2-order-up sr-icon z-middle'></span>倒序";
        }
    });
   
    $("#zhangkai").click(function () {
    
        if (e_num === false) {
            for (var i = 0; i < liList.length; i++) {
                if (i < 20) {
                    liList[i].style.display = "";
                }
                else {
                    liList[i].style.display = "none";
                }
                e_num = true;
                this.innerHTML = " 点击展开更多目录<span class='sprite-icon_2-down2 sr-icon z-middle'></span>";
            }
        } else if (e_num === true) {
            for (var j = 0; j < liList.length; j++) {
                liList[j].style.display = "";
            }
            e_num = false;
            this.innerHTML = " 点击收起目录<span class='sprite-icon_2-up2 sr-icon z-middle'></span>";
        }
    });

    $("#form0").validate({
        rules: {
            Comment_con:"required"
        },
        messages: {
            Comment_con:"评论内容不为空"
        }
    });

  
});