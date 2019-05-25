var _ = function (i, p) {
    return (p || document).querySelector(i);
};

_.toArr = function (r) {
    return Array.prototype.slice.call(r)
};

var __ = function (i, p) {
    return _.toArr((p || document).querySelectorAll(i));
};

var _D = Element.prototype;


_D._ = function (i) {
    return _(i, this);
};
_D.__ = function (i) {
    return __(i, this);
};


var en = function (text) {
    return encodeURIComponent(text)
}


_.U = function (url, search) {
    return baseAPIPath + url;
}


var baseAPIPath = '/api/';





_.object2url = function (O, a, b) {

    a = a || '=';
    b = b || '&';


    var
        r = [];
    for (var key in O)
        //if(key&&O[key])
        r.push(en(key) + a + en(O[key]));


    return r.join(b);
};


_.toast = function (text) {
    alert(text)
}

_.error = function (r) {
    var text = r.error;

    _.toast(text);
};


_.onRequest = function (xhr, func) {
    var r = xhr.responseText;

    if (r) {

        if ((xhr.getResponseHeader('Content-Type') || '').match(/json/)) {
            try {
                r = JSON.parse(r);
            } catch (e) { }
        }


        if (r.error) {
            _.error(r);
            return;
        }
    }

    if (func) {
        func(r);
    }
};

_.get = function (url, data, onOver) {

    var x = new XMLHttpRequest();



    x.open('GET', url + '?' + _.object2url(data));
    x.withCredentials = true;
    x.setRequestHeader('Content-Type', 'application/json');


    x.onload = function () {

        _.onRequest(x, onOver);
    };

    x.send();


    return x;
};
_.post = function (url, data, onOver) {

    var x = new XMLHttpRequest();



    x.open('POST', url);
    x.withCredentials = true;
    x.setRequestHeader('Content-Type', 'application/json');


    x.onload = function () {

        _.onRequest(x, onOver);
    };

    x.send(JSON.stringify(data));


    return x;
};

var enTxt = function (t) {
    return String(t).replace(/(^\s*)|(\s*$)/g, '')
        .replace(/&/g, "&amp;")
        .replace(/</g, "&lt;")
        .replace(/>/g, "&gt;")
        .replace(/\t/g, "&nbsp;&nbsp;&nbsp;&nbsp;")
        .replace(/\'/g, "&#39;")
        .replace(/\"/g, "&quot;")
    // .replace(/\n/g,"<br>");
};

if (_('.user-box')) {
    _.get(_.U('user/getUserInfo'), {}, function (data) {
        console.log(data);

        if (data.id) {
            _('.user-box').innerHTML = '<div status="auth"><a href="/member/personal">' + enTxt(data.name || data.email || data.mobilePhone || data.id) + '</a><hr><a href="/" action="退出登录">退出</a></div>';
        } else {
            _('.user-box').innerHTML = '<div status="guest"><a href="/login">登录</a> <hr> <a href="/reg">注册</a></div>';
        }

        if (data.unReadCount) {
            const noticeLink = _('.ui-topbar-box a[href="/member/message"]');
            if (noticeLink) {
                noticeLink.setAttribute('data-notice', data.unReadCount);
            }
        }
    });

    _('.user-box').onclick = function (e) {
        var target = e.target;
        var action = target.getAttribute('action');
        switch (action) {
            case '退出登录':
                e.preventDefault();
                _.post(_.U('user/logout'), {}, function () {
                    location.href = '/';
                });
                break;

        }
    }
}


if (_('.search-shop')) {
    var searchShopBtn = _('.search-shop');
    var searchForm = searchShopBtn.parentNode;
    var searchSiteBtn = searchForm._('.search-all');
    var searchInput = searchForm._('input');

    searchForm.onsubmit = function (e) {
        e.preventDefault()

        var value = searchInput.value.trim();


        if (!value) {
            searchInput.focus();
            return;
        }

    }

    searchShopBtn.onclick = function () {
        var value = searchInput.value.trim();

        // if(!value){
        // 	searchInput.focus()
        // 	return;
        // }

        var shopId = location.pathname.match(/^\/shop\/(\d+)/);

        if (!shopId) {
            return alert('没有找到这个店铺信息，请联系开发工程师')
        }

        shopId = shopId[1];

        location.href = '/shop/' + shopId + '/product/search.html?keyword=' + encodeURIComponent(value);
    }

    searchSiteBtn.onclick = function () {
        var value = searchInput.value.trim();

        // if(!value){
        // 	searchInput.focus()
        // 	return;
        // }

        location.href = '/product/search.html?keyword=' + encodeURIComponent(value);
    }

}

var slideSelectors = [
    '.ui-coupons-box',
    '.ui-special-banner-type-a-box',
    '.ui-special-contents-box[type="E"]',
    '.ui-cat-banner-box>.ui-special-contents-box',
    '.ui-special-banner-box>.ui-special-contents-box'
];
var slides = __(slideSelectors.join(','));


if (slides.length) {
    var nextBtn = document.createElement('span');
    var prevBtn = document.createElement('span');

    nextBtn.className = 'next-btn';
    prevBtn.className = 'prev-btn';


    slides.forEach(function (BOX) {
        var list = BOX.children[0];

        var items = _.toArr(list.children);

        var length = items.length;

        if (!length) {
            return;
        }

        var _nextBtn = nextBtn.cloneNode()
        var _prevBtn = prevBtn.cloneNode()
        BOX.appendChild(_nextBtn)
        BOX.appendChild(_prevBtn)


        var _width = items[0].offsetWidth;
        var _boxWidth = BOX.offsetWidth;
        var _allWidth = _width * length;

        if (BOX.classList.contains('ui-coupons-box')) {
            _boxWidth += -52;
        } else if (BOX.classList.contains('ui-special-contents-box') && BOX.getAttribute('type') == 'E') {
            _boxWidth += 20;
        }

        list.style.cssText += 'width:' + _allWidth + 'px';

        var now = 0;
        console.log(_allWidth / _boxWidth)
        var max = Math.ceil(_allWidth / _boxWidth);

        var one = function () {
            clearTimeout(BOX.T)
            BOX.T = setTimeout(function () {
                now++;

                if (now >= max) {
                    now = 0
                }

                list.style.cssText += 'transform:translate3d(-' + now * _boxWidth + 'px,0,0);';

                one();
            }, 5000);
        };

        one()

        _nextBtn.onclick = function () {
            now++;

            if (now >= max) {
                now = 0
            }

            list.style.cssText += 'transform:translate3d(-' + now * _boxWidth + 'px,0,0);';

            one();
        };

        _prevBtn.onclick = function () {
            now--;

            if (now < 0) {
                now = max - 1
            }

            list.style.cssText += 'transform:translate3d(-' + now * _boxWidth + 'px,0,0);';

            one();
        };
    })
}



let viewportMeta = document.querySelector('meta[name="viewport"]');

if (viewportMeta) {

    if (location.pathname.match(/^\/(|product)/)) {
        viewportMeta.setAttribute('content', 'width=device-width,initial-scale=1.0');
    } else {
        viewportMeta.setAttribute('content', 'width=1200px');
    }


}

document.body.actions = {
    '领取优惠劵': function (e) {
        e.preventDefault();
        _.post(_.U('coupon/takeCoupon'), {
            id: +this.getAttribute('data-id')
        }, function (r) {
            _.toast('领取成功');
        });
    }
};

document.body.addEventListener('click', function (e) {
    var target = e.target;
    var action = target.getAttribute('action');

    if (document.body.actions[action]) {
        document.body.actions[action].call(target, e);
    }

}, false);
