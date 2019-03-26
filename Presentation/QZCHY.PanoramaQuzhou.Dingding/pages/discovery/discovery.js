var app = getApp();

Page({
  data: {
    banners: [],
    projects: [],
    hotPanoramas: [ ],
    newPanoramas: [ ],
    currentTab: 0
  },

  //初始化函数  
  onLoad() {
    var that = this;

    //获取banners
    dd.httpRequest({
      url: app.globalData.apiBaseUrl + "banners/top",
      method: 'GET',
      dataType: 'json',
      success: function (res) {
        var b = res.data;
        b.forEach(function (item) {
          item.imageUrl = app.globalData.resourceUrl + "Minapp/banners/" + item.imageUrl;
        });
        that.setData({
          banners: b
        });
      },
      fail: function (res) {
        console.log(res);
        dd.alert({ content: '加载banner发生错误' });
      },
      complete: function (res) {
      }
    });

    //获取projects
    dd.httpRequest({
      url: app.globalData.apiBaseUrl + "projects/top",
      method: 'GET',
      dataType: 'json',
      success: function (res) {
        var p = res.data;
        p.forEach(function (item) {
          item.logoUrl = app.globalData.resourceUrl + "Minapp/projects/" + item.logoUrl;
          item.navToUrl = "../projects/project_pano_locations/project_pano_locations?pid=" + item.id + "&name=" + item.name;
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

        //获取hot panoramas
    dd.httpRequest({
      url: app.globalData.apiBaseUrl + "panoramas/hot",
      method: 'GET',
      dataType: 'json',
      success: function (res) {
        var panoramas = res.data;
        panoramas.forEach(function (item) {
          if(item.logoUrl==undefined||item.logoUrl==null||item.logoUrl=="")
          {

            var size = app.globalData.rpx * 335;
            item.logoUrl = "http://iph.href.lu/" + size + "x" + size + "?text=暂无图片";
          }
          else item.logoUrl = app.globalData.resourceUrl + "Minapp/pano/" + item.logoUrl;

          item.navToUrl = '../panorama/panorama?sid='+item.id;
        });

        console.log(panoramas);
        that.setData({
          hotPanoramas: panoramas
        });
      },
      fail: function (res) {
        console.log(res);
        dd.alert({ content: '加载panoramas发生错误' });
      },
      complete: function (res) {
      }
    });

        //获取new panoramas
    dd.httpRequest({
      url: app.globalData.apiBaseUrl + "panoramas/new",
      method: 'GET',
      dataType: 'json',
      success: function (res) {
        var panoramas = res.data;
        panoramas.forEach(function (item) {
          if(item.logoUrl==undefined||item.logoUrl==null||item.logoUrl=="")
          {

            var size = app.globalData.rpx * 335;
            item.logoUrl = "http://iph.href.lu/" + size + "x" + size + "?text=暂无图片";
          }
          else item.logoUrl = app.globalData.resourceUrl + "Minapp/pano/" + item.logoUrl;

          item.navToUrl = '../panorama/panorama?sid='+item.id;
        });

        console.log(panoramas);
        that.setData({
          newPanoramas: panoramas
        });
      },
      fail: function (res) {
        console.log(res);
        dd.alert({ content: '加载panoramas发生错误' });
      },
      complete: function (res) {
      }
    });    
  },

  //导航
  navTo: function (event) {
    dd.navigateTo({
      url: event.currentTarget.dataset.url
    })
  },

  //切换
  swichNav: function (event) {
    this.setData({
      currentTab: event.currentTarget.dataset.current
    });
  },

  swiperChange: function (event) {
    this.setData({
      currentTab: event.detail.current
    });
  }

})