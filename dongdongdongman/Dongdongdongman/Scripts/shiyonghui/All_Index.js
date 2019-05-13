$(document).ready(function () {
    // 排行榜滑过显示漫画详情
    $(".hot_comic_list li").mousemove(function () {
        $(this).addClass('hot_comic_detail').siblings('li').removeClass('hot_comic_detail');
        $(this).find('.hot_comic_hide').show().siblings('.hot_comic_show').hide();
        $(this).siblings('li').find('.hot_comic_show').show().siblings('.hot_comic_hide').hide();
    });
    var $box = $(".comic_list_slide_box");
    var $ulDataAll = $(".comic_slide_next").siblings('ul');
    var _resize = null;
    var bodyWidth = document.body.offsetWidth + 17;
    if (bodyWidth >= 1550) {
        _resize = true;
        $("body").addClass('big');
        $.each($ulDataAll, function (index, val) {
            $(this).attr("data-page", 1);
        });
        setUlWidth(18);
        slideComicList(18);
    } else {
        _resize = false;
        $("body").removeClass('big');
        $.each($ulDataAll, function (index, val) {
            $(this).attr("data-page", 1);
        });
        setUlWidth(12);
        slideComicList(12);
    }
    $(window).resize(function () {
        if (document.body.offsetWidth + 17 >= 1550) {
            if (_resize) {
                return;
            } else {
                $(".comic_slide_prev").unbind('click');
                $(".comic_slide_next").unbind('click');
                $("body").addClass('big');
                $.each($ulDataAll, function (index, val) {
                    resetUlSize();
                });
                setUlWidth(18);
                slideComicList(18);
                _resize = true;
            }
        } else {
            if (!_resize) {
                return;
            } else {
                $(".comic_slide_prev").unbind('click');
                $(".comic_slide_next").unbind('click');
                $("body").removeClass('big');
                resetUlSize();
                setUlWidth(12);
                slideComicList(12);
                _resize = false;
            }
        }
    });
    function resetUlSize() {
        $.each($ulDataAll, function (index, val) {
            $(this).attr("data-page", 1);
            $(this).css("left", 0);
            $(this).siblings('.comic_slide_prev').hide();
            $(this).siblings('.comic_slide_next').show();
        });
    }
    function resetUlSize() {
        $.each($ulDataAll, function (index, val) {
            $(this).attr("data-page", 1);
            $(this).css("left", 0);
            $(this).siblings('.comic_slide_prev').hide();
            $(this).siblings('.comic_slide_next').show();
        });
    }

    // 设置漫画列表ul的宽度
    function setUlWidth(margin) {
        var allLength = Number();
        if (margin == 12) {
            allLength = 6;
        } else {
            allLength = 8;
        }

        $box.each(function (index, val) {
            var oUl = $(this).find("ul");
            oUl.each(function (i, v) {
                var liLength = $(this).find("li").length;
                // 判断是否小于 一行 隐藏切换按钮
                if (liLength <= allLength) {
                    $(this).closest("ul").siblings('.comic_slide_next').hide();
                }
                var comicWidth = $(this).find('li').width() + margin;
                $(this).css("width", liLength * comicWidth + "px");
                if (margin == 12) {
                    $(this).attr("data-all", Math.ceil(liLength / parseInt(6.5))); // 小分辨率分页
                } else {
                    $(this).attr("data-all", Math.ceil(liLength / 8)); // 大分辨率分页
                }
            });
        });
        var $mgBox = $(".comic_list_mangai .comic_list_slide_box .cutUl");
        if (margin == 18) {
            $mgBox.each(function (index, val) {
                var liLength = $(this).find("li").length;
                $(this).find("ul").attr("data-all", Math.ceil(liLength / 7.5)); // 大分辨率漫改分页
            })
        }
    }

    // 漫画列表滑动
    function slideComicList(margin) {
        var $box = $(".comic_list_slide_box"),
            $ul = $(".comic_list_slide_box ul"),
            $c_prev = $(".comic_slide_prev"),
            $c_next = $(".comic_slide_next");
        $c_next.bind('click', { mr: margin }, nextBtn);
        $c_prev.bind('click', { mr: margin }, prevBtn);
    }
    $('body').bind('DOMNodeInserted', function () {
        if ($(this).find(".ac_results").length > 0) {
            $(".ac_results").bind("mouseleave", function () {
                $(this).find("li").removeClass('ac_over');
            })
        }
    });

    // 漫画滑动下一页
    function nextBtn(ev) {
        var ev = ev || event;
        var marginRight = ev.data.mr;
        var stepNum = Number();
        var stepNumHalf = Number();
        if (marginRight == 12) {
            stepNum = 6;
            stepNumHalf = 6.5;
        } else {
            stepNum = 8;
            stepNumHalf = 8;
        }
        var $that = $(this);
        var all = $(this).siblings('ul').attr("data-all");
        var comicWidth = $(this).siblings('ul').find('li').width() + marginRight;
        var ulWidth = $(this).siblings('ul').width(); //获取ul宽度
        var liLength = $(this).siblings('ul').find('li').length;
        var pageNum = $(this).siblings('ul').attr("data-page");
        if (pageNum >= 1) {
            $(this).siblings('.comic_slide_prev').show();
        }
        if (pageNum == all) {
            return;
        }
        var nextarr = [];
        for (var i = 0; i < all; i++) {
            nextarr.push(i * stepNum * comicWidth);
        };
        var nextarrlast = nextarr[nextarr.length - 1];
        nextarr.pop();
        nextarr.push(ulWidth - stepNumHalf * comicWidth);
        $(this).siblings('ul').stop(true, true).animate({
            left: -nextarr[pageNum] + "px"
        }, 500, function () {
            pageNum++;
            $that.siblings('ul').attr("data-page", pageNum);
            if (pageNum == all) {
                $that.hide();
            }
        });
    }

    // 漫画滑动上一页
    function prevBtn(ev) {
        var ev = ev || event;
        var marginRight = ev.data.mr;
        var stepNum = Number();
        var stepNumHalf = Number();
        if (marginRight == 12) {
            stepNum = 6;
            stepNumHalf = 6.5;
        } else {
            stepNum = 8;
            stepNumHalf = 8;
        }
        var $that = $(this);
        var all = $(this).siblings('ul').attr("data-all");
        var comicWidth = $(this).siblings('ul').find('li').width() + marginRight;
        var ulWidth = $(this).siblings('ul').width(); //获取ul宽度
        var pageNum = $(this).siblings('ul').attr("data-page");
        if (pageNum == 1) {
            return;
        };
        var prevarr = [];
        for (var i = 0; i < all; i++) {
            if (i % 2 == 0) {
                prevarr.push(ulWidth - stepNum * comicWidth - stepNumHalf * i * comicWidth + comicWidth / 2);
            } else {
                prevarr.push(ulWidth - stepNum * comicWidth - stepNumHalf * i * comicWidth);
            }
        };
        prevarr.reverse();
        prevarr.splice(0, 1, 0);
        if (pageNum <= all) {
            $(this).siblings('.comic_slide_next').show();
        }
        $(this).siblings('ul').stop(true, true).animate({
            left: -prevarr[pageNum - 2] + "px"
        }, 500, function () {
            pageNum--;
            $that.siblings('ul').attr("data-page", pageNum);
            if (pageNum == 1) {
                $that.hide();
            }
        });

    }


    /*图片延时加载*/
    //$(".lazyload").imagelazyload({
    //    threshold: 500,
    //    skip_invisible: true,
    //    load: function (self, settings) {
    //        $(self).find('img').each(function () {
    //            var $this = this;
    //            if (typeof ($($this).attr("xsrc")) != 'undefined') {
    //                $("<img />").bind("load", function () {
    //                    $($this).attr("src", $($this).attr("xsrc"));
    //                }).attr("src", $($this).attr("xsrc"));
    //            }
    //        });
    //        self.loaded = true;
    //    }
    //});
    //$(".rank_tab").click(function () {
    //    var index = $(this).index();
    //    var that = $(this).parents(".comic_content_tit").siblings('.comic_list_slide_box').find(".cutUl").eq(index);
    //    that.find('img').each(function (index, el) {
    //        $(el).attr("src", $(el).attr("xsrc"));
    //    });
    //});


    // 全站最热隐藏部分懒加载
    $(".hot_rank_tab_up").click(function () {
        var index = $(this).index() - 1;
        var that = $(this).parents(".hot_tab").siblings('.hot_comic_cut').eq(index);
        that.find('img').each(function (index, el) {
            $(el).attr("src", $(el).attr("xsrc"));
        });
    });

    // 漫画封面滑过标题变色
    !function () {
        $(".v5_comic_list .comic_pic").hover(function () {
            $(this).siblings('.comic_tit').css("color", "#89d38f");
        }, function () {
            $(this).siblings('.comic_tit').css("color", "#333");
        });

        $(".v5_comic_list .comic_tit").hover(function () {
            $(this).css("color", "#89d38f");
            $(this).siblings('.comic_pic').addClass('border1')
        }, function () {
            $(this).siblings('.comic_pic').removeClass('border1')
            $(this).css("color", "#333");
        });
    }();

var loopBg = $(".loop_slide_box a"),
    slideBox = $(".loop_slide_box li"),
    loopTit = $(".loop_tit a"),
    littleUl = $(".loop_focus_pic_box .little_pic"),
    loopContainer = $("#loop_container"),
    pageNext = $(".pagination_next"),
    pagePrev = $(".pagination_prev");
var blurBgBox = $(".hot__mask_bg_box");
var loopTime = null,
    loopIndex = 0,
    slideLength = slideBox.length;
// 循环放上图片
$.each(loopBg, function (index, val) {
    $(this).css("background-image", "url(" + $(this).attr("data-src") + ")");
    littleUl.append('<li>\
                        <span class="little_pic_mask"></span>\
                        <img src="'+ $(this).attr("data-little") + '" alt="" />\
                        <i class="little_pic_border"></i>\
                    </li>');
    littleUl.find('li').eq(loopIndex).addClass('cur');
    blurBgBox.append('<div class="hot__mask_bg" style="background-image:url(' + $(this).attr("data-src") + ')"></div>');
    blurBgBox.find('.hot__mask_bg').eq(loopIndex).addClass('cur');
});
if (!!window.ActiveXObject || "ActiveXObject" in window) {
    blurBgBox.remove();//判断是否IE浏览器移除效果
}
if (littleUl.children().length <= 5) {
    pageNext.hide();
    pagePrev.hide();
}
var blurBg = $(".hot__mask_bg_box .hot__mask_bg");
var paginationLi = $(".little_pic li");
loopTit.html(loopBg.eq(0).attr("data-call"));
loopTit.attr("href", loopBg.eq(0).attr("href"));
var pageLength = littleUl.find('li').length;
littleUl.attr({
    "data-allpage": Math.ceil(pageLength / 5),
    "data-pagenum": 1
})
var littlePicWidth = littleUl.find('li').width() + 12;
littleUl.css("width", pageLength * littlePicWidth + "px");
// 自动播放
function loopGo() {
    slideBox.eq(loopIndex).stop().animate({ "opacity": 0 }, 300).removeClass('cur');
    blurBg.eq(loopIndex).stop().animate({ "opacity": 0 }, 300).removeClass('cur');
    loopIndex++;
    if (loopIndex == slideLength) {
        loopIndex = 0;
    }
    nextShow(loopIndex);
    curSite();
}

// 自动走到li对应的位置
function curSite() {
    var hasCur = $(".little_pic li.cur").index();
    var allLi = littleUl.find('li').length;
    var arr = [];
    var n = 1;
    for (var i = 1; i < allLi + 1; i++) {
        if (i % 5 == 0) {
            arr.push(n);
            n++;
        }
    };
    if (hasCur <= 4) {
        var ulLeft = littleUl.position().left;
        if (ulLeft == 0) {
            return;
        }
        littleUl.animate({
            left: 0
        }, 600);
        littleUl.attr("data-pagenum", 1);
    } else if (hasCur >= arr.length * 5 && allLi % 5 > 0) {
        var slidePx = arr[arr.length - 2] * 530;
        if (isNaN(slidePx)) {
            slidePx = 0;
        }
        littleUl.animate({
            left: - slidePx - allLi % 5 * littlePicWidth + "px"
        }, 600);
        littleUl.attr("data-pagenum", parseInt(littleUl.attr("data-allpage")));
    } else {
        var page = parseInt(hasCur / 5);
        littleUl.animate({
            left: - page * 530 + "px"
        }, 600);
        littleUl.attr("data-pagenum", page + 1);
    }
}

function changeIndex(old, index) {
    slideBox.eq(old).stop(true, true).animate({ "opacity": 0 }, 300);
    blurBg.eq(old).stop(true, true).animate({ "opacity": 0 }, 300);
    nextShow(index);
}
function nextShow(n) {
    littleUl.find('li').eq(n).addClass('cur').siblings('li').removeClass('cur');
    loopTit.html(loopBg.eq(n).attr("data-call"));
    loopTit.attr("href", loopBg.eq(n).attr("href"));
    slideBox.eq(n).stop(true, true).animate({ "opacity": 1 }, 300).addClass('cur').siblings('li').removeClass('cur');
    blurBg.eq(n).stop(true, true).animate({ "opacity": 1 }, 300).addClass('cur').siblings('li').removeClass('cur');
}
if ($("body").find("#loop_container").length > 0) {
    loopTime = setInterval(loopGo, 5000);
}
// 滑过停掉轮播
loopContainer.bind('mouseenter', function () {
    clearInterval(loopTime);
});
loopContainer.bind('mouseleave', function () {
    clearInterval(loopTime);
    loopTime = setInterval(loopGo, 5000);
});

// 滑过小图切换轮播
paginationLi.bind("mouseenter", function () {
    clearInterval(loopTime);
    var oldIndex = $(".little_pic li.cur").index();
    var n = $(this).index();
    if (oldIndex == n) {
        return;
    }
    changeIndex(oldIndex, n);
    loopIndex = n;
});

// 点击按钮切换轮播小图
var clickBtn = true;
pageNext.bind("click", function () {
    if (slideLength <= 5) {
        return;
    }
    if (clickBtn) {
        var pageNum = parseInt(littleUl.attr("data-pagenum"));
        var allPage = parseInt(littleUl.attr("data-allpage"));
        pageNum++;
        littleUl.attr("data-pagenum", pageNum);
        clickBtn = false;
        if (pageNum > allPage) {
            littleUl.animate({
                left: 0 + "px"
            }, 300, function () {
                clickBtn = true;
                littleUl.attr("data-pagenum", 1);
            })
        } else if (pageNum == allPage) {
            var ulLeft = littleUl.position().left;
            var remain = parseInt(pageLength - (pageNum - 1) * 5); // 剩下多少个
            littleUl.animate({
                left: (ulLeft - remain * littlePicWidth) + "px"
            }, 300, function () {
                clickBtn = true;
            })
        } else {
            var ulLeft = littleUl.position().left;
            littleUl.animate({
                left: ulLeft - 5 * littlePicWidth + "px"
            }, 300, function () {
                clickBtn = true;
            })
        }
    }

});
pagePrev.bind("click", function () {
    if (slideLength <= 5) {
        return;
    }
    if (clickBtn) {
        var pageNum = parseInt(littleUl.attr("data-pagenum"));
        var allPage = parseInt(littleUl.attr("data-allpage"));
        pageNum--;
        littleUl.attr("data-pagenum", pageNum);
        clickBtn = false;
        if (pageNum == 0) {
            littleUl.animate({
                left: -(littleUl.width() - 5 * littlePicWidth) + "px"
            }, 300, function () {
                clickBtn = true;
                littleUl.attr("data-pagenum", allPage);
            });
        } else if (pageNum == 1) {
            littleUl.animate({
                left: 0 + "px"
            }, 300, function () {
                clickBtn = true;
                littleUl.attr("data-pagenum", 1);
            });
        } else {
            var ulLeft = littleUl.position().left;
            littleUl.animate({
                left: ulLeft + 5 * littlePicWidth + "px"
            }, 300, function () {
                clickBtn = true;
            });
        }
    }
});

    document.body.addEventListener('click', function (e) {
        var target = e.target;
        var action = target.getAttribute('action');

        if (document.body.actions[action]) {
            document.body.actions[action].call(target, e);
        }

    }, false);


});