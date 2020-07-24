
import util from './utils/utils.js';

App({
  onLaunch(options) {

    console.log(this.globalData.initial);
    if (!this.globalData.initial) this.globalData.initial = true;
    console.log("------");
    console.log(this.globalData.initial);
    // E应用初始化
    var that = this;

    this.globalData.systemInfo = my.getSystemInfoSync();
    this.globalData.rpx = 750 / this.globalData.systemInfo.windowWidth;
    console.log(this.globalData.rpx);

    my.getAuthCode({
      success: function (res) {
        that.requestGet(that.globalData.apiBaseUrl + "Accounts/SignIn?authCode=" + res.authCode, {}, false)
          .then(function (response) {
            if (response.data != undefined && response.data != null && response.data != "") {
              if (response.data.indexOf("Guid:") >= 0) {
                var guid = response.data.replace("Guid:", "");
                console.log("guid:" + guid);
                my.setStorage({
                  key: 'userInfo',
                  data: {
                    guid: guid
                  }
                });
              }
            }
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
      my.getLocation({
        success(res) {
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
        fail(res) {
          that.globalData.location.initial = false;
          console.log("fail");
          console.log(res)
          reject(res);
        }
      })
    });
  },

  requestGet(url, data, showLoading) {
    var that = this;
    return new Promise(function (resolve, reject) {
      if (showLoading) {
        my.showLoading({
          content: '请求中...'
        });
      }

      my.httpRequest({
        url: url,
        method: 'Get',
        data: data,
        dataType: 'json',
        success: function (res) {
          resolve(res);
        },
        fail: function (res) {
          reject(res);
        },
        complete: function (res) {
          if (showLoading) {
            my.hideLoading();
          }
        }
      });
    });
  },


  globalData: {
    initial: false,
    systemInfo: {},
    guid: "",
    rpx: 0.5,
    //apiBaseUrl: "http://qzschy.vaiwan.com/api/",
    apiBaseUrl: "https://www.qzgis.cn/api/",
    resourceUrl: "https://www.qzgis.cn/assets/",
    webUrl: "https://www.qzgis.cn/",
    location: {
      initial: false,
      lng: 118.8546289036,
      lat: 28.9732601540,
    }
  }
});
