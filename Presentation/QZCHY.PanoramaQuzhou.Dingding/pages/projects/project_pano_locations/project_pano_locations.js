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
  'project.name':query.name
});

    //获取项目具体信息
    dd.httpRequest({
      url: app.globalData.apiBaseUrl + "projects/" + query.pid,
      method: 'GET',
      dataType: 'json',
      success: function (res) {

        console.log(res);

        var project = res.data;

        project.logoUrl = app.globalData.resourceUrl + "Minapp/projects/" + project.logoUrl;

        project.panoramaLocations.forEach(function (item) {
          if (item.logoUrl == undefined || item.logoUrl == null) {
            var size = app.globalData.rpx * 335;
            item.logoUrl = "http://iph.href.lu/" + size + "x" + size + "?text=暂无图片";
          }
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
      },
      fail: function (res) {
        console.log(res);
        dd.alert({ content: '加载panoramaLocations发生错误' });
      },
      complete: function (res) {
      }
    });


  },


  navToPanorama:function(event){
    console.log(event);
    var sceneId=event.currentTarget.dataset.sid;

    dd.navigateTo({
      url:'../../panorama/panorama?sid='+sceneId
    });
  }
});
