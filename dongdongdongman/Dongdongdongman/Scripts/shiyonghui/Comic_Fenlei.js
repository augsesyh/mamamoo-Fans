jQuery(document).ready(function ($) {
    var List = new Array();
    List[0] = "全部";
    List[1] = "全部";
    List[2] = "全部";
    List[3] = "全部";
    List[4] = "全部";
    $('.theme a').click(function () {//点击的时候给当前这个加上，其他的移除
        var a = $(this).text();
        $(this).addClass("active").siblings("a").removeClass("active");
        
        var d = $(this).parent().parent().children(".selName").text();
        switch (d) {
            case "颜色": List[0] = a; break;
            case "受众": List[1] = a; break;
            case "内容": List[2] = a; break;
            case "地区": List[3] = a; break;
            case "篇幅": List[4] = a; break;
            default: alert("不要乱点");
        }
        $(".tagContent").load("/Comic/FenleiPart", { List: List }, function () { alert("查找成功"); });
        //$.ajax({
        //    traditional: true,
        //    type: "post",
        //    url: "/Comic/FenLeiByOther",
        //    data: { List: List },
        //    success: function (data) {
                
        //    },
        //    error: function (data) {
        //        alert(data);
        //    }
        //});
    });
});