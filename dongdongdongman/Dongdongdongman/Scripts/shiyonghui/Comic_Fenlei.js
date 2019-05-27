jQuery(document).ready(function ($) {
    var List[5]
    $('.theme a').click(function () {//点击的时候给当前这个加上，其他的移除

        var a = $(this).text();
       $(".selectedList")
        $(this).addClass("active").siblings("a").removeClass("active");
    });
});