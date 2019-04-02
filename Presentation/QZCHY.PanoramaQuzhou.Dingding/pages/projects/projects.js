var app = getApp();

Page({
  data: {
    projects: []
  },

  navTo: function (event) {
    dd.navigateTo({
      url: 'project_pano_locations/project_pano_locations?pid=' + event.currentTarget.dataset.pid
    });
  },



  onLoad() {
    var that = this;
    //获取projects
    app.requestGet(app.globalData.apiBaseUrl + "projects", null, true).then(function (res) {
      console.log(res);
      var p = res.data;
      p.forEach(function (item) {
        item.logoUrl = app.globalData.resourceUrl + "Minapp/projects/" + item.logoUrl;
      });
      that.setData({
        projects: p
      });
    }, function () {
      console.log(res);
      dd.alert({ content: '加载projects发生错误' });
    });

  },
});
