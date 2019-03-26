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
    panoramas: [
      {
        title: "测试全景1",
        imgs: {
          front: "http://220.191.238.125/resources/images/s1/front.jpg",
          back: "http://220.191.238.125/resources/images/s1/back.jpg",
          up: "http://220.191.238.125/resources/images/s1/up.jpg",
          down: "http://220.191.238.125/resources/images/s1/down.jpg",
          left: "http://220.191.238.125/resources/images/s1/left.jpg",
          right: "http://220.191.238.125/resources/images/s1/right.jpg"
        },
        location: [118.232345, 28.98761],
        tags: ["城市时光机", "重大项目", "123"],
        stars: 123,
        produce: "衢州市地理信息中心",
        date: "2019-03-15"
      },
      {
        title: "测试全景2",
        imgs: {
          front: "http://220.191.238.125/resources/images/s2/front.jpg",
          back: "http://220.191.238.125/resources/images/s2/back.jpg",
          up: "http://220.191.238.125/resources/images/s2/up.jpg",
          down: "http://220.191.238.125/resources/images/s2/down.jpg",
          left: "http://220.191.238.125/resources/images/s2/left.jpg",
          right: "http://220.191.238.125/resources/images/s2/right.jpg"
        },
        location: [118.232345, 28.98761],
        tags: ["城市时光机", "重大项目", "123"],
        stars: 31,
        produce: "衢州市地理信息中心",
        date: "2019-04-15"
      }
    ],
    currentPanoIndex: 0,
    currentPano: null
  },
  onLoad() {


    this.setData({
      screenHeight: app.globalData.systemInfo.windowHeight,
      cubeBoxSize: app.globalData.systemInfo.windowHeight * 4,
      currentPanoIndex: 0,
      currentPano: this.data.panoramas[0]
    });
    console.log(this.data.currentPano);
  },

  navToPano: function () {
    dd.navigateTo({
      url: '../panorama/panorama'
    })
  },

  refreshPano: function () {
    var index = this.data.currentPanoIndex + 1;
    console.log(index);
    if (index >= this.data.panoramas.length) index = 0;
    this.setData({
      currentPanoIndex: index,
      currentPano: this.data.panoramas[index]
    });


    console.log("refresh");
    console.log(this.data.currentPano);
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

    // if (Math.abs(X) > Math.abs(Y) && X > 0) {
    //   alert("left 2 right");
    // }
    // else if (Math.abs(X) > Math.abs(Y) && X < 0) {
    //   alert("right 2 left");
    // }
    // else if (Math.abs(Y) > Math.abs(X) && Y > 0) {
    //   alert("top 2 bottom");
    // }
    // else if (Math.abs(Y) > Math.abs(X) && Y < 0) {
    //   alert("bottom 2 top");
    // }
    // else {
    //   alert("just touch");
    // }


    // if (moving) {

    //   if (e.changedTouches[0] == undefined || e.changedTouches[0] == null) return;

    //   console.log(e.changedTouches[0]);

    //   x2 = e.changedTouches[0].pageX;
    //   y2 = e.changedTouches[0].pageY;

    //   var dist_x = x2 - x1,
    //     dist_y = y2 - y1,
    //     perc_x = dist_x / w_v,
    //     perc_y = dist_y / h_v,
    //     deg_x = Math.atan2(dist_y, perspective) / Math.PI * 180,
    //     deg_y = -Math.atan2(dist_x, perspective) / Math.PI * 180,
    //     i,
    //     vendors = ['-webkit-', '-moz-', ''];
    //   c_x_deg += deg_x;
    //   c_y_deg += deg_y;
    //   c_x_deg = Math.min(90, c_x_deg);
    //   c_x_deg = Math.max(-90, c_x_deg);

    //   c_y_deg %= 360;

    //   deg_x = c_x_deg;
    //   deg_y = c_y_deg;
    //   var transform = "";

    //   transform += "-webkit-transform:" + 'rotateX(' + deg_x + 'deg) rotateY(' + deg_y + 'deg);';
    //   transform += "-moz-transform:" + 'rotateX(' + deg_x + 'deg) rotateY(' + deg_y + 'deg);';
    //   transform += "transform:" + 'rotateX(' + deg_x + 'deg) rotateY(' + deg_y + 'deg)';

    //   this.setData({
    //     transform: transform
    //   });

    //   x1 = x2;
    //   y1 = y2;
    // }
  },

  touchEnd: function (e) {
    // moving = false;
  },

  touchCancel: function (e) {
    // moving = false;
  }

});
