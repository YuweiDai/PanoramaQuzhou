var app = getApp();

Page({
  data: { mapUrl: "" },
  onLoad() {
    var url = app.globalData.webUrl + "map.html";
    console.log(url);
    this.setData({
      mapUrl: url
    })

    console.log("map onload")
    this.webViewContext = dd.createWebViewContext('web-view-2')
    console.log(this.webViewContext);
  },

  test(e) {
    dd.alert({
      content: JSON.stringify(e.detail),
    });
    this.webViewContext.postMessage({ 'sendToWebView': '1' });
  },
});
