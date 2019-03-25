var app = getApp();

Page({
  data: {
    projects: [

    ]

  },

  navTo:function(event){
    dd.navigateTo({
      url:'project_pano_locations/project_pano_locations?pid='+event.currentTarget.dataset.pid
    });
  },



  onLoad() {
    var that = this;
    //获取projects
    dd.httpRequest({
      url: app.globalData.apiBaseUrl + "projects",
      method: 'GET',
      dataType: 'json',
      success: function (res) {

        console.log(res);

        var p = res.data;
        p.forEach(function (item) {
          item.logoUrl = app.globalData.resourceUrl + "Minapp/projects/" + item.logoUrl;
        });
        that.setData({
          projects: p
        });
      },
      fail: function (res) {
        console.log(res);
        dd.alert({ content: '加载projects发生错误' });
      },
      complete: function (res) {
      }
    });
  },
});
