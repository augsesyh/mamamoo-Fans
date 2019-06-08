jQuery(document).ready(function ($) {
    $(".guanli").click(function () {
        $(".guanli").removeClass("opened");
        $(this).toggleClass("opened");
        $(this).children("ul").toggle("slow");
    });
});