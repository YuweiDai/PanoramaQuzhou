var k; var temp1, temp2, temp;
var temp3 = 1;
var hotspotData = {};
var hotspotstring = "";
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
var h = document.documentElement.clientHeight;
var w = document.documentElement.clientWidth/2;
var w1 = $('#item_title').width() / 2;
$("#item_title").css("left",(w-w1)+"px");

//加载全景
var addPanor = function () {
  
    if (id == undefined) id=7;
    $.ajax({
        url: "http://220.191.238.125/qzqj/api/Panoramas/" + id,
        type: "get",
        success: function (response) {
            var sceneName = response.name;
            $("#starnum").html(response.stars);
            $("#title").html(sceneName.substring(0, sceneName.length - 8));
            $("#psrq").html(sceneName.substring(sceneName.length - 8,sceneName.length-4)+"-"+sceneName.substring(sceneName.length-4,sceneName.length-2)+"-"+sceneName.substring(sceneName.length-2));

            k.call("loadscene('" + sceneName + "')");

            $.each(response.hotspots, function (i,data) {

                var spotname = "spot" + i;
                k.call("addhotspot("+spotname+");");
                k.call("set(hotspot[" + spotname + "].url,skin/arrow.png);");

                k.call("set(hotspot[" + spotname + "].onloaded,do_crop_animation(32,32, 30));");
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
        $("#xz_btn i").css("background-position", "-260px -660px");
        k.set("autorotate.enabled", true);
        temp = 1;
    }
    else {
        $("#xz_btn i").css("background-position", "-260px -590px");
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





//添加标注按钮
$("#hotspot").on('touchstart', function (event) {
    event.stopPropagation();
    $("#menu").css("display", "none");
    $(this).css("cursor", "pointer");
    if (temp2 != 1) {
        allowDemoRun = true;
        // addHotsport();
        temp2 = 1;
    }
    else {
        allowDemoRun = false;
        temp2 = 2;
    }
});
//动态添加标注
$("#pano").on('touchstart', function (event) {
    if (allowDemoRun == false) return;

    var sphereXY = k.screentosphere(event.originalEvent.targetTouches[0].pageX, event.originalEvent.targetTouches[0].pageY);
    var sp = k.spheretoscreen(event.originalEvent.targetTouches[0].pageX, event.originalEvent.targetTouches[0].pageY);
    var sphereX = sphereXY.x;
    var sphereY = sphereXY.y;
    k.call("addhotspot(kk);");
    k.call("set(hotspot[kk].url,skin/arrow.png);");
    k.call("set(hotspot[kk].visible,true);");
    k.call("set(hotspot[kk].onloaded,do_crop_animation(32,32, 30));");
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

$(".SpeakModal_modal_3hilMN").on('touchstart', function () {
    event.stopPropagation();
})

//提交说一说
$("#submitBtn").on('click', function () {
    
    hotspotData.title = $(".SpeakModal_textarea_1j66Du").val();
    k.call("set(hotspot[kk].visible,false);");
    k.call("addhotspot(kkk);");
    k.call("set(hotspot[kkk].url,skin/arrow.png);");
    k.call("set(hotspot[kkk].visible,true);");
    k.call("set(hotspot[kkk].onloaded,do_crop_animation(32,32, 30));");
    k.call("set(hotspot[kkk].tooltip," + hotspotData.title + ");");
    k.call("set(hotspot[kkk].ath," + hotspotData.ath + ");");
    k.call("set(hotspot[kkk].atv," + hotspotData.atv + ");");
   
    $.ajax({
        url: "http://220.191.238.125/qzqj/api/Panoramas/addhotspot",
        data: hotspotData,
        type: "post",
        success: function (response) {
     
        
            $("#menu").css("display", "block");
        }

    });

    $(".SpeakModal_modal_3hilMN").css("display", "none");

});

$("#unsubmitBtn").on('click', function () {
    $(".SpeakModal_modal_3hilMN").css("display", "none");
    k.call("set(hotspot[kk].visible,false);");
    $("#menu").css("display", "block");
})

//点赞
$("#addstar").on('click', function () {
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


