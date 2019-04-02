// E应用页面对应的page.js声明test方法，
// 由于page.axml里的web-view组件设置了onMessage="test",
// 当网页里执行完dd.postMessage后，test方法会被执行
// "web-view-1"为视图中<web-view />组件的id，必须设置
var app = getApp();

Page({
  data: {
    mapUrl: "http://220.191.238.125:8070/map.html"
  },
  onLoad(query) {
    var that = this;
    var queryStr = "?lng=" + app.globalData.location.lng + "&lat=" + app.globalData.location.lat;
    console.log("setdata");


    if (query.level && query.centerLat && query.centerLng) {
      queryStr += "&level=" + query.level + "&centerLat=" + query.centerLat + "&centerLng=" + query.centerLng;
    }



    var url = app.globalData.webUrl + "map.html" + queryStr
    that.setData({
      mapUrl: url,
    });
    this.webViewContext = dd.createWebViewContext('webMapView');
    console.log(url);
  },
  onReady() {
  },
  onShareAppMessage() {
   // 返回自定义分享信息
  },
  postMsg(e) {
    dd.alert({
      content: JSON.stringify(e.detail),
    });
    this.webViewContext.postMessage({ 'sendToWebView': '1' });
  }
});