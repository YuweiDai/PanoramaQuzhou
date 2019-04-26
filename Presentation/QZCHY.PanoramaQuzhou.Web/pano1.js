var k,k1; var temp1, temp2, temp,temp4;
var temp3 = 1;
var hotspotData = {};
var hotspotstring = "";
var sceneName = "";
var hlookat, vlookat, fov;

var panoItems = window.location.search.substr(1).split(';');

var id = window.parent.id;

if (id == undefined) id = 57;

var allowDemoRun = false;

var krpanoReady = function (krpano) {
    k = krpano;
}

embedpano({ swf: "tour.swf", xml: "tours/" + id + "_bq.xml", target: "pano", html5: "auto", mobilescale: 1.0, passQueryParameters: true, onready: krpanoReady });

var mybody = document.getElementsByTagName('body')[0];
var h = document.documentElement.clientHeight / 2;
//var rh = $(".RightBtnContainer_container_2TnlAa").outerHeight();
var w = document.documentElement.clientWidth/2;

$(".gq_bq").css("left", (w - 100) + "px");
$(".gq_bq").css("top", (h - 50) + "px");
//加载全景
var addPanor = function () {
  
    
    $.ajax({
        url: "http://220.191.238.125:8070/api/Panoramas/" + id,
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

if (panoItems.length > 2) {
    hlookat = panoItems[0].split('=')[1];
    vlookat = panoItems[1].split('=')[1];
    fov = panoItems[2].split('=')[1];
    k.call("set('view.fov'," + fov + ");");
    k.call("set('view.hlookat'," + hlookat + ");");
    k.call("set('view.vlookat'," + vlookat + ");");
}
else {
    addPanor();
}



//热点中切换场景
function loadpano(xmlname,sceneName) {
    if (k) {
        if (xmlname.indexOf("_gq") != -1) {
            $("#title").html(sceneName.substring(0, sceneName.length - 11));
        }
        else {
            $("#title").html(sceneName.substring(0, sceneName.length - 8));
        }
        //动态切换xml，xmlname为tour.xml传过来的值 
        k.call("loadpano(" + xmlname + ", null, MERGE, BLEND(0.5));"); 
        //sceneName为切换后加载的第一个场景
        k.call("loadscene('" + sceneName + "')"); 
    } 
} 

//场景选择
$("#choose").on('touchstart', function (event) {
    event.stopPropagation();
    k.call("switch(layer[thumbs_background].visible);");
    k.call("switch(layer[auto_thumbs].visible);");
});


$(".SpeakModal_modal_3hilMN").on('touchstart', function (event) {
    event.stopPropagation();
});



$("#pano").on('touchmove', function (e) {
    
    var krpano = top.frame2.document.getElementById("krpanoSWFObject");
    hlookat = k.get("view.hlookat");
    vlookat = k.get("view.vlookat");
    fov = k.get("view.fov");

    krpano.set("view.hlookat", hlookat);
    krpano.set("view.vlookat", vlookat);
    krpano.set("view.fov", fov);

    end(e);
});

$("#pano").on('touchend', function (e) {
    e.preventDefault();
    var krpano = top.frame2.document.getElementById("krpanoSWFObject");
    hlookat = k.get("view.hlookat");
    vlookat = k.get("view.vlookat");
    fov = k.get("view.fov");

    krpano.set("view.hlookat", hlookat);
    krpano.set("view.vlookat", vlookat);
    krpano.set("view.fov", fov);

  

});

function end(e) {

    setTimeout(function () {

        var krpano = top.frame2.document.getElementById("krpanoSWFObject");
        hlookat = k.get("view.hlookat");
        vlookat = k.get("view.vlookat");
        fov = k.get("view.fov");

        krpano.set("view.hlookat", hlookat);
        krpano.set("view.vlookat", vlookat);
        krpano.set("view.fov", fov);

    }, 500)

}









