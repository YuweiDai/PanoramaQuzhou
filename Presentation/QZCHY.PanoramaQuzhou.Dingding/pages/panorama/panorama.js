var app = getApp();
Page({
  data: {
    locationId:0,
    sceneName: "",
    targetUrl: ""
  },
  onLoad(query) {
    var locationId = query.id;
    var sceneName = query.sname;
    var newUrl = app.globalData.webUrl + "?id=" + locationId;
    console.log(query);
    this.setData({
      locationId:locationId,
      targetUrl: newUrl,
      sceneName: sceneName
    });
  },
  onShareAppMessage() {

    var title = this.data.sceneName;
    var desc = "立即查看" + title + "全景";
    var path = "pages/panorama/panorama?id=" + this.data.locationId + "&sname=" + this.data.sceneName;

    console.log(path);
    return {
      title: title,
      desc: desc,
      path: path
    };
  }
});
