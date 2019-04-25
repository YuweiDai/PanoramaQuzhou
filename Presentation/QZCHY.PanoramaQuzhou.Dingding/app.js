
import util from './utils/utils.js';

App({
  onLaunch(options) {
    // E应用初始化
    var that = this;

    that.globalData.systemInfo = dd.getSystemInfoSync();
    that.globalData.rpx = 750 / that.globalData.systemInfo.windowWidth;
    console.log(that.globalData.rpx);
    console.log(that.globalData.systemInfo.windowWidth);
    console.log(that.globalData.systemInfo.windowHeight);
  },
  onShow(options) {
    // E应用显示

    //获取位置
    this.setLocation();
    // then(function () {
      //   // var url = "https://restapi.a.com/v3/assistant/coordinate/convert?locations=" +
    //   //   that.globalData.location.lng + "," + that.globalData.location.lat +
    //   //   "&coordsys=gps&key="
    //   //   + that.globalData.GDToken;
    //   // that.requestGet(url).then(function (res) {
    //   //   if (res.data.info == "ok") {
    //   //     var coors = res.data.locations.split(',');
    //   //     that.globalData.location.lng = coors[0];
    //   //     that.globalData.location.lat = coors[1];
    //   //     console.log("second");
    //   //     console.log(that.globalData.location.lng + "," + that.globalData.location.lat)
    //   //   }
    //   //   console.log(res);
    //   // }, function () { });
    // }, function () {
    // }
    // );    
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
          that.globalData.location.initial=true;
          that.globalData.location.lng = gpsLngLat[0];
          that.globalData.location.lat = gpsLngLat[1];
          resolve(res);
        },
        fail() {
          that.globalData.location.initial=false;
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
    resourceUrl: "http://220.191.238.125:8070/assets/",
    webUrl: "http://220.191.238.125:8070/",
    location: {
      initial:false,
      lng: 118.8898357316,
      lat: 28.9721214555
    }
  }
});
