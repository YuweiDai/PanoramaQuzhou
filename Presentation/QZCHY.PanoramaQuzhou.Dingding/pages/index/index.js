var interval = null;
var app = getApp();

Page({
  data: {
    tips: "(5秒)"
  },
  onLoad() {
    console.log("index page");
  },

  onShow() {
    // 页面显示
    var that = this;
    var count = 5;
    interval = setInterval(function () {
      if (count == 0) {
        that.setData({
          tips: ""
        })
        clearInterval(that.interval);

        that.entry();
      }
      else {
        that.setData({
          tips: "(" + count + "秒)"
        })

        count--;
      }
    }, 1000);
  },
  onShareAppMessage() {
    return {
      title: "全景衢州",
      desc: "唱响三城记，打好保障战，护航大花园",
      path: "pages/index/index"
    };
  },
  entry: function () {
    clearInterval(interval);
    dd.reLaunch({
      url: '../home/home?showIntro=' + app.globalData.first
    });

    // dd.switchTab({
    //   url: '../home/home'
    // })
  }
});
