var app = getApp();
Page({
  data: {
    sceneId:0,
    sceneName: "",
    targetUrl: ""
  },
  onLoad(query) {

    var sceneId = query.sid;
    var sceneName = query.sname;
    var newUrl = app.globalData.webUrl + "/index.html?id=" + sceneId;
    console.log(sceneId);
    console.log(sceneName);

    this.setData({
      sceneId:sceneId,
      targetUrl: newUrl,
      sceneName: sceneName
    });
  },
  onShareAppMessage() {

    var title = this.data.sceneName;
    var desc = "立即查看" + title + "全景";
    var path = "pages/panorama/panorama?sid=" + this.data.sceneId + "&sname=" + this.data.sceneName;

    console.log(path);
    return {
      title: title,
      desc: desc,
      path: path
    };
  }
});
