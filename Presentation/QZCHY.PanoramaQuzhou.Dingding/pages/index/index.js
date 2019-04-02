Page({
  data: {
    tips: "(3秒)"
  },
  onLoad() { },

  onShow() {
    // 页面显示
    var that = this;
    var count = 3;
    that.interval = setInterval(function () {
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

  entry: function () {

    if (this.interval != undefined && this.interval != null) clearInterval(this.interval);


    dd.reLaunch({
      url: '../home/home'
    })
  }
});
