var x1,
  y1, x2, y2,
  moving = false,
  w_v = 375, // width of viewer
  h_v = 667, // height of viewer
  c_x_deg = 0, // current x
  c_y_deg = 0,
  perspective = 450; // current y

var startX = 0, startY = 0;
var refresh = false;

var app = getApp();
Page({
  data: {
    screenHeight: 100,
    cubeBoxSize: 3000,
    transform: "",
    panoramas: [],
    currentPanoIndex: 0,
    currentPano: null,
    mapUrl:"../map/map"
  },
  onLoad() {
    var that = this;

    var url = app.globalData.apiBaseUrl + "panoramas/previewlist"
    //获取hot panoramas
    app.requestGet(url, null, true).then(
      function (res) {

        console.log(res);
        var panoramas = res.data;
        panoramas.forEach(function (item) {
          var basePath = app.globalData.resourceUrl + "panos/" + item.imgPath + "/pic_thumb/pano_";
          item.imgs = { front: "", back: "", up: "", down: "", left: "", right: "" };
          item.imgs.front = basePath + "f.jpg";
          item.imgs.back = basePath + "b.jpg";
          item.imgs.up = basePath + "u.jpg";
          item.imgs.down = basePath + "d.jpg";
          item.imgs.left = basePath + "l.jpg";
          item.imgs.right = basePath + "r.jpg";

          item.navToUrl = '../panorama/panorama?sid=' + item.id;
        });

        that.setData({
          panoramas: panoramas,
          screenHeight: app.globalData.systemInfo.windowHeight,
          cubeBoxSize: app.globalData.systemInfo.windowHeight * 4,
          currentPanoIndex: 0,
        });

        //http://localhost/resources/panos/%E8%A1%A2%E5%B7%9E%E4%B8%9C%E9%AB%98%E9%80%9F%E5%87%BA%E5%8F%A320180820.tiles/pic_thumb/pano_d.jpg
        //http://220.191.238.125/resources/panos/%E7%9B%88%E5%B7%9D%E5%B0%8F%E5%8C%BA20180515.tiles/pic_thumb/pano_f.jpg

    
        that.setData({
          currentPano: that.data.panoramas[0],
          mapUrl:"../map/map?level=16&centerLng=" +that.data.panoramas[0].lng+ "&centerLat="+that.data.panoramas[0].lat
        });

      },
      function (res) {

        console.log(res);
        dd.alert({ content: '加载panoramas发生错误' });


      });

  },
  onShareAppMessage() {
   // 返回自定义分享信息
  },
  navToPano: function () {
    var that = this;
    dd.navigateTo({
      url: that.data.currentPano.navToUrl
    })
  },

  toMap: function () {
    var that=this;
    app.setLocation().then(function () {
      dd.switchTab({
        url:that.data.mapUrl
      })
    }, function () { });
  },

  refreshPano: function (forwad) {
    var index = this.data.currentPanoIndex + 1;
    if (index >= this.data.panoramas.length) index = 0;
    this.setData({
      currentPanoIndex: index,
      currentPano: this.data.panoramas[index],
          mapUrl:"../map/map?level=16&centerLng=" +this.data.panoramas[index].lng+ "&centerLat="+this.data.panoramas[index].lat
    });
  },

  //触摸控制  暂时取消
  touchStart: function (e) {
    // x1 = e.changedTouches[0].pageX;
    // y1 = e.changedTouches[0].pageY;
    // moving = true;
    // console.log(e);
    startX = e.changedTouches[0].pageX,
      startY = e.changedTouches[0].pageY;
    refresh = false;
  },

  //触摸控制  暂时取消  
  touchMove: function (e) {

    if (refresh) return;

    var moveEndX = e.changedTouches[0].pageX;
    var moveEndY = e.changedTouches[0].pageY;
    var X = moveEndX - startX - 5;
    var Y = moveEndY - startY - 5;

    if (Math.abs(Y) > Math.abs(X) && Y < 0) {
      this.refreshPano();
      refresh = true;
    }
  },

  touchEnd: function (e) {
    // moving = false;
  },

  touchCancel: function (e) {
    // moving = false;
  }

});
