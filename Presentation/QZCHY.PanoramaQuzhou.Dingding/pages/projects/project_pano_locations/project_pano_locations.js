var app = getApp();

Page({
  data: {
    project: {
      name: "",
      logoUrl: "",
      remark: "",
      panoramaLocations: []
    }
  },
  onLoad(query) {
    console.log(query);
    var that = this;

    this.setData({
      'project.name': query.name
    });

    //获取项目具体信息
    app.requestGet(app.globalData.apiBaseUrl + "projects/" + query.pid, null, true).then(function (res) {
      console.log(res);

      var project = res.data;

      project.logoUrl = app.globalData.resourceUrl + "Minapp/projects/" + project.logoUrl;

      project.panoramaLocations.forEach(function (item) {
        if (item.logoUrl == undefined || item.logoUrl == null || item.logoUrl == "") {

          var size = app.globalData.rpx * 335;
          item.logoUrl = "http://iph.href.lu/" + size + "x" + size + "?text=暂无图片";
        }
        else item.logoUrl = app.globalData.resourceUrl + "panos/" + item.logoUrl;
      });

      that.setData({
        project: project
      })

      //修改标题
      dd.setNavigationBar({
        title: project.name,
        success() { },
        fail() { },
      });
    }, function (res) {
      console.log(res);
      dd.alert({ content: '加载panoramaLocations发生错误' });
    });
  },
  onShareAppMessage() {

    var title = this.data.project.name+"全景集合";
    var desc = "立即查看";
    var path = "pages/projects/project_pano_locations/project_pano_locations?pid=" + this.data.project.id;
    console.log(path);

    return {
      title: title,
      desc: desc,
      path: path
    };
  },

  navToPanorama: function (event) {
    console.log(event);
    var sid = event.currentTarget.dataset.sid;
    var sname=event.currentTarget.dataset.sname;

    dd.navigateTo({
      url: '../../panorama/panorama?sid=' + sid+"&sname="+sname
    });
  }
});
