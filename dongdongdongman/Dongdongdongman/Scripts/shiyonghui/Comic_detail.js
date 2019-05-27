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
    var d = 0;
    $(".j-reply-button").click(function () {
        var a = $(this).parent().parent().parent().children(".j-emoji").text();
        alert();
        $(".textarea").remove();
        if (d === 0) {
            d = 1;
            $(this).parent().parent().children("form").append("<div class='textarea'> <div class='sr-cinput__input f - pr'><textarea class='sr-textarea z-small' placeholder='回复 ' name='recontent' ></textarea><div class='sr-creply__triangle'></div></div > <div class='sr-cinput-c2-r2 f-cb'><div class='f-cb f-fr'> <button class='u-btn-reply z-danger f-fl  js-btn-comment' type='submit' id='re3'>回复</button></div></div></div>");
        } else {
            d = 0;
        }
    });
  
});