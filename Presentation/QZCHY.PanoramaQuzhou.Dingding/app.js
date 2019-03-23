App({
  onLaunch(options) {
    // E应用初始化


    this.globalData.systemInfo = dd.getSystemInfoSync();
    this.globalData.rpx=750/this.globalData.systemInfo.windowWidth;
    console.log(this.globalData.rpx);
  },
  onShow(options) {
    // E应用显示
  },
  onHide() {
    // E应用隐藏
  },
  onError(msg) {
    console.log(msg)
  },
  globalData: {
    systemInfo: {},
    rpx:0.5,

    apiBaseUrl:"http://abcde.vaiwan.com/",
    resourceUrl:"http://220.191.238.125/resources/"
  }
});
