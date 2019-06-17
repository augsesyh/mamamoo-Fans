jQuery(document).ready(function ($) {
    var jf = document.querySelectorAll(".j-flag");

    for (var j = 0; j < jf.length; j++) {
        var jfc = jf[j].querySelectorAll(".sr-rpitem");
        if (jfc.length > 3) {
            alert("j=" + j);
            for (var t = 0; t < jfc.length; t++) {
                if (t > 2) {
                    jfc[t].style.display = "none";
                    jfc[t].classList.add("sr_hish");
                }
                if (t === 1) {
                    var r = jf[j];
                    var y = "<a href='javascript:void(0);' class='f-tac expand-trigger'><span class='sprite-icon_2-star sr-icon'></span> <span class='plain-text expand-trigger-content'>楼太高o(>﹏<)o，点击展开隐藏楼层~</span><span class='sprite-icon_2-star sr-icon'></span> </a>";
                    $(r).append(y);
                    alert("t=" + t);


                }
            }
        }
    }
    var d = 0;
    $(".j-reply-button").click(function () {
        var a = $(this).parent().parent().parent().children(".username").children(".j-emoji").text();


        $(".textarea").remove();
        if (d === 0) {
            d = 1;
            $(this).parent().parent().children("form").append("<div class='textarea'> <div class='sr-cinput__input f - pr'><textarea class='sr-textarea z-small' placeholder='回复" + a + " ' name='recontent' ></textarea><div class='sr-creply__triangle'></div></div > <div class='sr-cinput-c2-r2 f-cb'><div class='f-cb f-fr'> <button class='u-btn-reply z-danger f-fl  js-btn-comment' type='submit' id='re3'>回复</button></div></div></div>");
        } else {
            d = 0;
        }
    });
    $(".expand-trigger").click(function () {

        $(this).parent().children(".sr_hish").toggle();

    });
    $(".jubao").click(function () {
        
        var d = $(this).attr("value");
        alert(d);
        $("#Jubao_Form").children("#jb").remove();
        $("#Jubao_Form").children("#jb1").remove();
        $("#Jubao_Form").append("<input type='hidden' value=" + d + " id='jb' name='jb'>");
    });
    $(".jubao1").click(function () {

        var d = $(this).attr("value");
        alert(d);
        $("#Jubao_Form").children("#jb").remove();
        $("#Jubao_Form").children("#jb1").remove();
        $("#Jubao_Form").append("<input type='hidden' value=" + d + " id='jb1' name='jb1'>");
    });

});