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
        var e = 0;
        $(".selectedList li").remove();
       
        List.forEach(v => { if (v !== "全部") { $(".selectedList").append(" <li class='selectedItem fl'><span>" + v + "</span></li>"); e = 1; } });
        if (e === 0) { $(".selectedList").append("<li class='selectedItem fl'><span>全部</span></li>"); }
        //$("#tagContent").load("/Comic/FenleiPart", { List: List }, function () { alert("查找成功"); });
        $.ajax({
            traditional: true,
            type: "get",
            url: "/Comic/FenleiPart",
            data: { List: List },
            async: true,
            success: function (data) {
                $("#tagContent").html(data);
            },
            error: function (data) {
                alert(data);
            }
        });
        
        //$.get("/Comic/FenleiPart",{ List: List }, function (result) {
        //    $("#tagContent").html(result);
        //});
    });
});