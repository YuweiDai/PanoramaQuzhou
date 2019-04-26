
import util from './utils/utils.js';

App({
  onLaunch(options) {
    // E应用初始化
    var that = this;

    this.globalData.systemInfo = dd.getSystemInfoSync();
    this.globalData.rpx = 750 / this.globalData.systemInfo.windowWidth;
    console.log(this.globalData.rpx);

    dd.getAuthCode({
      success: function (res) {
        that.requestGet(that.globalData.apiBaseUrl + "Accounts/SignIn?authCode=" + res.authCode, {}, false)
          .then(function (response) { 
            console.log(response)
          }, function (response) { 
            console.log(response)
          });
      },
      fail: function (err) {
      }
    });


  },
  onShow(options) {
    // E应用显示

    //获取位置
    this.setLocation();
  },
  onHide() {
    // E应用隐藏
  },
  onError(msg) {
    console.log(msg)
  },

  setLocation() {
    var that = this;
    return new Promise(function (resolve, reject) {

      console.log("promise");
      dd.getLocation({
        success(res){
          console.log("sucess--res");
          console.log(res.longitude);
          console.log(res.latitude);

          var lng = res.longitude;
          var lat = res.latitude;

          // var gpsLng = util.toGPSPoint(30.273923, 120.12703);
          var gpsLngLat = util.gdToGps(res.latitude, res.longitude);

          console.log("gd to gps");
          console.log(gpsLngLat);
          that.globalData.location.initial = true;
          that.globalData.location.lng = gpsLngLat[0];
          that.globalData.location.lat = gpsLngLat[1];
          resolve(res);
        },
        fail() {
          that.globalData.location.initial = false;
          console.log("fail");
          reject(res);
        }
      })
    });
  },

  requestGet(url, data, showLoading) {
    var that = this;
    return new Promise(function (resolve, reject) {
      if (showLoading) {
        dd.showLoading({
          content: '请求中...'
        });
      }

      dd.httpRequest({
        url: url,
        method: 'Get',
        data: data,
        dataType:'json',
        success: function (res) {
          resolve(res);
        },
        fail: function (res) {
          reject(res);
        },
        complete: function (res) {
          if (showLoading) {
            dd.hideLoading();
          }
        }
      });
    });
  },


  globalData: {
    systemInfo: {
      
    },
    rpx: 0.5,
    apiBaseUrl: "http://qzgis.vaiwan.com/api/",
    //apiBaseUrl: "http://220.191.238.125:8070/api/",
    resourceUrl: "http://220.191.238.125:8070/assets/",
    webUrl: "http://220.191.238.125:8070/",
    location: {
      initial: false,
      lng: 118.8898357316,
      lat: 28.9721214555
    }
  }
});
