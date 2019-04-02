﻿//引入钉钉接口
//if (navigator.userAgent.toLowerCase().indexOf('dingtalk') > -1) {
//    document.writeln('<script src="https://appx/web-view.min.js"' + '>' + '<' + '/' + 'script>');
//}

var k; var temp1, temp2, temp;
var temp3 = 1;
var hotspotData = {};
var hotspotstring = "";
var sceneName = "";
(function ($) {
    $.getUrlParam = function (name) {
        var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");//构造一个含有目标参数的正则表达式对象
        var r = window.location.search.substr(1).match(reg);//匹配目标参数
        if (r != null) return unescape(r[2]); return null;//返回参数值
    }
})(jQuery);
var id = $.getUrlParam('id');
 
var allowDemoRun = false;
var div = document.getElementById("pano");

var krpanoReady = function (krpano) {
    k = krpano;
}

embedpano({ swf: "tour.swf", xml: "tour.xml", target: "pano", html5: "auto", mobilescale: 1.0, passQueryParameters: true, onready: krpanoReady });

var mybody = document.getElementsByTagName('body')[0];
var h = document.documentElement.clientHeight / 2;
//var rh = $(".RightBtnContainer_container_2TnlAa").outerHeight();
var w = document.documentElement.clientWidth/2;

$(".gq_bq").css("left", (w - 100) + "px");
$(".gq_bq").css("top", (h - 50) + "px");
//$(".RightBtnContainer_container_2TnlAa").css("top", (h - rh) + "px");
//加载全景
var addPanor = function () {
  
    if (id == undefined) id=7;
    $.ajax({
        url: "http://220.191.238.125/qzqj/api/Panoramas/" + id,
        type: "get",
        success: function (response) {
            sceneName = response.name;
            $("#starnum").html(response.stars);
            $("#title").html(sceneName.substring(0, sceneName.length - 8));
            $("#psrq").html(sceneName.substring(sceneName.length - 8,sceneName.length-4)+"-"+sceneName.substring(sceneName.length-4,sceneName.length-2)+"-"+sceneName.substring(sceneName.length-2));

            k.call("loadscene('" + sceneName + "')");

            var w1 = $('#item_title').width() / 2;
            $("#item_title").css("left", (w - w1) + "px");

            $.each(response.hotspots, function (i,data) {

                var spotname = "spot" + i;
                k.call("addhotspot("+spotname+");");
                k.call("set(hotspot[" + spotname + "].url,assets/06.png);");

                k.call("set(hotspot[" + spotname + "].onloaded,do_crop_animation(64,64, 50));");
                k.call("set(hotspot[" + spotname + "].tooltip," + data.title + ");");
                k.call("set(hotspot[" + spotname + "].zoom,false);");
                k.call("set(hotspot[" + spotname + "].ath," + data.ath + ");");
                k.call("set(hotspot[" + spotname + "].atv," + data.atv + ");");
            })       

        }

    })
}
//加载全景调用
addPanor();


//高清标清切换
$("#div_gq").on('touchstart', function (event) {
    event.stopPropagation();
    if (sceneName.indexOf("_gq") == -1) {
        sceneName = sceneName + "_gq";
        k.call("loadscene('" + sceneName + "')");
    }
    else {
        return;
    }
});
$("#div_bq").on('touchstart', function (event) {
    event.stopPropagation();
    if (sceneName.indexOf("_gq") != -1) {
        sceneName = sceneName.substring(0, sceneName.length - 3);
        k.call("loadscene('" + sceneName + "')");
    }
    else { return; }
});

//场景选择
var addList = function () {

    //var scene = k.get("scene[get(xml.scene)].name");

    //var xml = ' <settings name="auto_thumbs" thumb_size="200" thumb_background_size="250" thumb_spacing="0" left="10" right="10" bottom="10" albums_right="10" onstart=""/>';
    //k.call("loadxml(" + xml + " )");

    k.call("switch(layer[auto_thumbs].visible);");
    //   k.call("WebVR.enterVR();");
};

//VR切换按钮
var play_vr = function () {
    k.call("WebVR.enterVR();");
}

//控制自动旋转
var play_xz = function () {
    if (temp != 1) {
        $("#xz2").css("display", "block");
        $("xz").css("display", "none");
        k.set("autorotate.enabled", true);
        temp = 1;
    }
    else {
        $("xz").css("display", "block");
        $("#xz2").css("display", "none");
        k.set("autorotate.enabled", false);
        temp = 2;
    }

}

//全屏切换
var play_qp = function () {

    if (temp1 != 1) {
        $("#xz_btn i").css("background-position", "-260px -660px");
        k.set("fullscreen", true);
        temp1 = 1;
    }
    else {
        $("#xz_btn i").css("background-position", "-260px -590px");
        k.set("fullscreen", false);
        temp1 = 2;
    }
}

//高清标清切换
var play_gq_bq = function () {

    if (temp2 != 1) {
        $(".gq_bq").css("display", "block");
        temp2 = 1;
    }
    else {
        $(".gq_bq").css("display", "none");
        temp2 = 2;
    }
}

//var toMap = function () {

//    var lng = k.get("scene[" + sceneName + "].lng");
//    var lat = k.get("scene[" + sceneName + "].lat");

//    dd.navigateTo({
//        url: "../map/map?level=16&centerLng=" + lng + "&centerLat=" + lat
//    })

//}


//添加标注按钮
$("#hotspot").on('touchstart', function (event) {
    event.stopPropagation();
    allowDemoRun = !allowDemoRun;
    if (allowDemoRun == true) {
        $("#menu").css("display", "none");
        $(this).css("cursor", "pointer");
    }
});

//动态添加标注
$("#pano").on('touchstart', function (event) {
    $(".gq_bq").css("display", "none");
    temp2 = 2;
    if (allowDemoRun == false) return;

    var sphereXY = k.screentosphere(event.originalEvent.targetTouches[0].pageX, event.originalEvent.targetTouches[0].pageY);
    var sp = k.spheretoscreen(event.originalEvent.targetTouches[0].pageX, event.originalEvent.targetTouches[0].pageY);
    var sphereX = sphereXY.x;
    var sphereY = sphereXY.y;
    k.call("addhotspot(kk);");
    k.call("set(hotspot[kk].url,assets/06.png);");
    k.call("set(hotspot[kk].visible,true);");
    k.call("set(hotspot[kk].onloaded,do_crop_animation(64,64, 50));");
    k.call("set(hotspot[kk].tooltip,'添加标注');");
    k.call("set(hotspot[kk].ath," + sphereX + ");");
    k.call("set(hotspot[kk].atv," + sphereY + ");");

    hotspotData = {
        title: "测试",
        ath: sphereX,
        atv: sphereY,
        scence_Id: id
    };
    $(".SpeakModal_modal_3hilMN").css("display", "block");

});

$(".SpeakModal_modal_3hilMN").on('touchstart', function (event) {
    event.stopPropagation();
})

//提交说一说
$("#submitBtn").on('click', function () {
    
    hotspotData.title = $(".SpeakModal_textarea_1j66Du").val();
    k.call("set(hotspot[kk].visible,false);");
    k.call("addhotspot(kkk);");
    k.call("set(hotspot[kkk].url,assets/06.png);");
    k.call("set(hotspot[kkk].visible,true);");
    k.call("set(hotspot[kkk].onloaded,do_crop_animation(64,64, 50));");
    k.call("set(hotspot[kkk].tooltip," + hotspotData.title + ");");
    k.call("set(hotspot[kkk].ath," + hotspotData.ath + ");");
    k.call("set(hotspot[kkk].atv," + hotspotData.atv + ");");
   
    $.ajax({
        url: "http://220.191.238.125/qzqj/api/Panoramas/addhotspot",
        data: hotspotData,
        type: "post",
        success: function (response) {
     
            allowDemoRun = false;
            $("#menu").css("display", "block");
        }

    });

    $(".SpeakModal_modal_3hilMN").css("display", "none");

});

$("#unsubmitBtn").on('click', function () {
    $(".SpeakModal_modal_3hilMN").css("display", "none");
    k.call("set(hotspot[kk].visible,false);");
    $("#menu").css("display", "block");
    allowDemoRun = false;
})

//点赞
$("#addstar").on('click', function (event) {
    event.stopPropagation();
    if (temp3 == 2) return;
  
    $.ajax({
        url: "http://220.191.238.125/qzqj/api/Panoramas/addStars/" + id,
        type: "put",
        success: function (response) {

            $("#starnum").html(parseInt($("#starnum").html()) + 1);
            $("#dz1").css("display", "none");
            $("#dz2").css("display", "block");
            temp3 = 2;
        }
    })

});




