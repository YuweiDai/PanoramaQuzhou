var x1,
  y1, x2, y2,
  panoramas,
  moving = false,
  w_v = 375, // width of viewer
  h_v = 667, // height of viewer
  c_x_deg = 0, // current x
  c_y_deg = 0,
  perspective = 450; // current y

var startX = 0, startY = 0;
var refresh = false;
var app = getApp();    //初始化app对象
var lat = app.globalData.location.lat;
var lng = app.globalData.location.lng;
var index = 0;
var pageSize = 15;
var ps = [];
Page({
  data: {
    screenHeight: 100,
    cubeBoxSize: 3000,
    transform: "",
    panoramas: [],
    currentPano: null,
    mapUrl: "../map/map",
    background: [],
    current: 0,
    interval: 3000,
  },
  onLoad(query) {
    var that = this;
    that.loadScenes(0);

    my.getStorage({
      key: 'userInfo',
      success: function (res) {
        var guid = res.data.guid;
        app.requestGet(app.globalData.apiBaseUrl + 'Accounts/' + guid, null, false).then(function (response) {
          console.log(response);
          if (response.data == "true") {
            my.confirm({
              title: '温馨提示',
              content: '欢迎使用全景衢州，是否查看教程？',
              confirmButtonText: '马上去看',
              cancelButtonText: '暂不需要',
              success: (result) => {
                if (result.confirm) {
                  my.navigateTo({
                    url: '../introduction/introduction'
                  })
                }
              },
            });
          }

        }, function () {

        });

      },
      fail: function (res) {
      }
    });


  },
  loadScenes: function (i) {
    lat = app.globalData.location.lat;
    lng = app.globalData.location.lng;
    console.log("lat:" + lat);
    console.log("lng:" + lng);

    var url = app.globalData.apiBaseUrl + 'panoramas/previewlist?lat=' + lat + '&lng='
      + lng + '&pageSize=' + pageSize + '&index=' + i;
    //获取hot panoramas
    var that = this;
    app.requestGet(url, null, false).then(
      function (res) {
        panoramas = res.data;
        panoramas.forEach(function (item) {
          var basePath = app.globalData.resourceUrl + "panos/" + item.imgPath + "/pic_thumb/pano_";
          item.imgs = { front: "", back: "", up: "", down: "", left: "", right: "" };
          item.imgs.front = basePath + "f.jpg";
          // item.imgs.back = basePath + "b.jpg";
          // item.imgs.up = basePath + "u.jpg";
          // item.imgs.down = basePath + "d.jpg";
          // item.imgs.left = basePath + "l.jpg";
          // item.imgs.right = basePath + "r.jpg";
          if (item.dist == 5000) {
            item.dist = "超过5000"
          }
          else {
            item.dist = "约" + item.dist;
          }
          item.navToUrl = '../panorama/panorama?id=' + item.locationId;
          ps.push(item);
        });
        console.log(ps);


        var currentPano = panoramas[0];
        console.log(currentPano);

        if (currentPano == null) return;

        that.setData({
          panoramas: ps,
          screenHeight: app.globalData.systemInfo.windowHeight,
          cubeBoxSize: app.globalData.systemInfo.windowHeight * 4,
          currentPano: currentPano,
          mapUrl: "../map/map?level=16&centerLng=" +
            currentPano.lng + "&centerLat=" + currentPano.lat
        });

      });

  },
  handleChange: function (e) {
    var that = this;
    var currentPanoIndex = e.detail.current;
    var currentPano = that.data.panoramas[currentPanoIndex];
    this.setData({
      currentPano: currentPano,
      mapUrl: "../map/map?level=16&centerLng=" +
        currentPano.lng + "&centerLat=" + currentPano.lat
    })
    //加载下一页
    if ((parseInt(e.detail.current) % 15) == 13) {
      var a = 1 + Math.floor(e.detail.current / 15);
      console.log(a);
      this.loadScenes(a);
    }

  },
  onShareAppMessage() {
    return {
      title: "全景衢州",
      desc: "唱响三城记，打好保障战，护航大花园",
      path: "pages/index/index"
    };
  },
  navToPano: function (event) {
    var that = this;
    my.navigateTo({
      url: that.data.currentPano.navToUrl
    })
  },

  toMap: function () {
    var that = this;
    app.setLocation().then(function () {

      my.switchTab({
        url: that.data.mapUrl
      })
    }, function () { });
  },
});