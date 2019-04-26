(function ($) {
    $.getUrlParam = function (name) {
        var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");//构造一个含有目标参数的正则表达式对象
        var r = window.location.search.substr(1).match(reg);//匹配目标参数
        if (r != null) return unescape(r[2]); return null;//返回参数值
    }
})(jQuery);

var id = $.getUrlParam('id');
var name1 = decodeURI($.getUrlParam("name1"), "utf-8");
var name2 = decodeURI($.getUrlParam("name2"), "utf-8");

$(window).bind('orientationchange', function (e) {

    var h = document.documentElement.clientHeight;
    var w = document.documentElement.clientWidth;
    if (h > w) {
     
        window.frames['myFramset'].rows = h;
        window.frames['myFramset'].cols = w / 2 + "," + w / 2;
    }
    else {
        window.frames['myFramset'].cols = w;
        window.frames['myFramset'].rows = h / 2 + "," + h / 2;
    }

});