var app = getApp();

Page({
  data: {
    banners: [],
    projects: [],
    // tags: [
    //   {
    //     src: "../../resources/images/t2.jpg",
    //     title: "城市时光机",
    //     url: ""
    //   },
    //   {
    //     src: "../../resources/images/t1.jpg",
    //     title: "美丽乡村",
    //     url: ""
    //   },
    //   {
    //     src: "../../resources/images/t3.jpg",
    //     title: "室内全景",
    //     url: ""
    //   },

    // ],
    hotPanoramas: [
      // {
      //   src: "../../resources/images/h1.jpg",
      //   title: "西区二期未来科技城",
      //   count: 1213,
      //   date: "2019-03-12",
      //   url: ""
      // },
      // {
      //   src: "../../resources/images/h2.jpg",
      //   title: "古城双修",
      //   count: 1213,
      //   date: "2019-03-12"
      // },
      // {
      //   src: "../../resources/images/h3.jpg",
      //   title: "绿色产业集聚区",
      //   count: 1213,
      //   date: "2019-03-12"
      // },
      // {
      //   src: "../../resources/images/h4.jpg",
      //   title: "衢江新城",
      //   count: 1213,
      //   date: "2019-03-12"
      // },
      // {
      //   src: "../../resources/images/h5.jpg",
      //   title: "酒醉池淮",
      //   count: 1213,
      //   date: "2019-03-12"
      // }

    ],
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

        //获取hotpanoramas
    dd.httpRequest({
      url: app.globalData.apiBaseUrl + "panoramas/hot",
      method: 'GET',
      dataType: 'json',
      success: function (res) {
        var panoramas = res.data;
        panoramas.forEach(function (item) {
          item.logoUrl = app.globalData.resourceUrl + "Minapp/projects/" + item.logoUrl;
          item.navToUrl = "../projects/project_pano_locations/project_pano_locations?pid=" + item.id + "&name=" + item.name;
        });
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