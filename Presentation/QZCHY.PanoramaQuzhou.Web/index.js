var k; var temp1, temp2, temp;
var krpanoReady = function (krpano) {
    k = krpano;
}
embedpano({ swf: "tour.swf", xml: "tour.xml", target: "pano", html5: "auto", mobilescale: 1.0, passQueryParameters: true, onready: krpanoReady });

var mybody = document.getElementsByTagName('body')[0];
var h = document.documentElement.clientHeight;
var w = document.documentElement.clientWidth/2;
var w1 = $('#item_title').width() / 2;
$("#item_title").css("left",(w-w1)+"px");

k.call("set('view.vlookat',10);");

var h = k.get("view.vlookat");

var addList = function () {

    //var scene = k.get("scene[get(xml.scene)].name");

    //var xml = ' <settings name="auto_thumbs" thumb_size="200" thumb_background_size="250" thumb_spacing="0" left="10" right="10" bottom="10" albums_right="10" onstart=""/>';
    //k.call("loadxml(" + xml + " )");




    k.call("switch(layer[auto_thumbs].visible);");
    //   k.call("WebVR.enterVR();");
};

var addPanor = function () {
    $.ajax({
        url: "http://localhost:8070/api/Panorama/5",   
        type: "get",
        success: function (response) {
            var sceneName = response.name;

            k.call("loadscene('" + sceneName + "')");

        }

    })
}


var allowDemoRun = false;
var div = document.getElementById("pano");



$("#pano").on('touchstart', function (event) {
    if (allowDemoRun == false) return;
  
    var addHotsport = function () {
      
        var sphereXY = k.screentosphere(event.screenX, event.screenY - 66);
        var sp = k.spheretoscreen(event.screenX, event.screenY - 66);
        var sphereX = sphereXY.x;
        var sphereY = sphereXY.y;
        k.call("addhotspot(kk);");
        k.call("set(hotspot[kk].url,../skin/vtourskin_mapspot.png);");
        k.call("set(hotspot[kk].ath," + sphereX + ");");
        k.call("set(hotspot[kk].atv," + sphereY + ");");

    }
    addHotsport();
  
})


$(".Button_button_box_IEKNKj").click(function (event) {
    event.stopPropagation();
    if (temp2 != 1) {
        allowDemoRun = true;
        // addHotsport();
        temp2 = 1;
    }
    else {
        allowDemoRun = false;
        temp2 = 2;
    }
})


addPanor();

var play_vr = function () {
    k.call("WebVR.enterVR();");
}

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
