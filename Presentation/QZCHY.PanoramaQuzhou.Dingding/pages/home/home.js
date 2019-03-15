var x1,
  y1, x2, y2,
  moving = false,
  w_v = 375, // width of viewer
  h_v = 667, // height of viewer
  c_x_deg = 0, // current x
  c_y_deg = 0,
  perspective = 450; // current y

var app = getApp();
Page({
  data: {
    screenHeight: 100,
    cubeBoxSize: 3000,
    transform: "",
    tags:["城市时光机","重大项目","123"]
  },
  onLoad() {

    this.setData({
      screenHeight: app.globalData.systemInfo.windowHeight,
      cubeBoxSize: app.globalData.systemInfo.windowHeight * 4
    });
  },

  navToPano:function(){
dd.navigateTo({
  url: '../panorama/panorama'
})
  },

  //触摸控制  暂时取消
  touchStart: function (e) {
    // x1 = e.changedTouches[0].pageX;
    // y1 = e.changedTouches[0].pageY;
    // moving = true;
    // console.log(e);
  },

  //触摸控制  暂时取消  
  touchMove: function (e) {
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
