var k, k1; var temp1, temp2, temp, temp4;
var temp3 = 1;
var hotspotData = {};
var hotspotstring = "";


var panoItems = window.location.search.substr(1).split(';');

var id = window.parent.id;
var sceneName = window.parent.name2;

var allowDemoRun = false;

var krpanoReady = function (krpano) {
    k = krpano;
}

embedpano({ swf: "tour.swf", xml: "tours/" + id + "_bq.xml", target: "pano", html5: "auto", mobilescale: 1.0, passQueryParameters: true, onready: krpanoReady });

var mybody = document.getElementsByTagName('body')[0];
var h = document.documentElement.clientHeight / 2;
//var rh = $(".RightBtnContainer_container_2TnlAa").outerHeight();
var w = document.documentElement.clientWidth / 2;

$(".gq_bq").css("left", (w - 100) + "px");
$(".gq_bq").css("top", (h - 50) + "px");
//加载全景
var addPanor = function () {

    k.call("loadscene('" + sceneName + "')");
    $("#title").html(sceneName.substring(0, sceneName.length - 8));
    $("#psrq").html(sceneName.substring(sceneName.length - 8, sceneName.length - 4) + "-" + sceneName.substring(sceneName.length - 4, sceneName.length - 2) + "-" + sceneName.substring(sceneName.length - 2));
    var w1 = $('#item_title').width() / 2;
    $("#item_title").css("left", (w - w1) + "px");

}
//加载全景调用

addPanor();




//场景选择
$("#choose").on('touchstart', function () {
    event.stopPropagation();
    k.call("switch(layer[thumbs_background].visible);");
    k.call("switch(layer[auto_thumbs].visible);");
});


$(".SpeakModal_modal_3hilMN").on('touchstart', function (event) {
    event.stopPropagation();
});



$("#pano").on('touchmove', function (e) {

    var krpano = top.frame1.document.getElementById("krpanoSWFObject");
    hlookat = k.get("view.hlookat");
    vlookat = k.get("view.vlookat");
    fov = k.get("view.fov");

    krpano.set("view.hlookat", hlookat);
    krpano.set("view.vlookat", vlookat);
    krpano.set("view.fov", fov);

    end(e);

})

$("#pano").on('touchend', function (e) {
    e.preventDefault();
    var krpano = top.frame1.document.getElementById("krpanoSWFObject");
    hlookat = k.get("view.hlookat");
    vlookat = k.get("view.vlookat");
    fov = k.get("view.fov");

    krpano.set("view.hlookat", hlookat);
    krpano.set("view.vlookat", vlookat);
    krpano.set("view.fov", fov);

});

function end(e) {

    setTimeout(function () {

        var krpano = top.frame1.document.getElementById("krpanoSWFObject");
        hlookat = k.get("view.hlookat");
        vlookat = k.get("view.vlookat");
        fov = k.get("view.fov");

        krpano.set("view.hlookat", hlookat);
        krpano.set("view.vlookat", vlookat);
        krpano.set("view.fov", fov);

    }, 500)

}





