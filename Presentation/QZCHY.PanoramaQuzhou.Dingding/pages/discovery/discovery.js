var app = getApp();

Page({
  data: {
    banners: [],
    projects: [
      {
        src: "../../resources/images/p1.jpg",
        url: ""
      },
      {
        src: "../../resources/images/p2.jpg",
        url: ""
      },
      {
        src: "../../resources/images/p3.jpg",
        url: ""
      }
    ],
    tags: [
      {
        src: "../../resources/images/t2.jpg",
        title: "城市时光机",
        url: ""
      },
      {
        src: "../../resources/images/t1.jpg",
        title: "美丽乡村",
        url: ""
      },
      {
        src: "../../resources/images/t3.jpg",
        title: "室内全景",
        url: ""
      }
    ],
    hotPanoramas: [
      {
        src: "../../resources/images/h1.jpg",
        title: "西区二期未来科技城",
        count: 1213,
        date: "2019-03-12",
        url: ""
      },
      {
        src: "../../resources/images/h2.jpg",
        title: "古城双修",
        count: 1213,
        date: "2019-03-12"
      },
      {
        src: "../../resources/images/h3.jpg",
        title: "绿色产业集聚区",
        count: 1213,
        date: "2019-03-12"
      },
      {
        src: "../../resources/images/h4.jpg",
        title: "衢江新城",
        count: 1213,
        date: "2019-03-12"
      },
      {
        src: "../../resources/images/h5.jpg",
        title: "酒醉池淮",
        count: 1213,
        date: "2019-03-12"
      }

    ],
    indicatorDots: true,
    autoplay: false,
    interval: 3000,
  },

  //初始化函数  
  onLoad() { 
    console.log("123");

    dd.httpRequest({
      url: app.globalData.apiBaseUrl+"banners/top",
      method: 'GET',
      dataType: 'json',
      success: function (res) {

        res.forEach(function(item){

          item.imageUrl=app.globalData.resourceUrl+"/Minapp/banners/"+item.imageUrl;
          console.log(item);
        });

        this.setData({
          banners:res
        })
      },
      fail: function (res) {
        console.log(res);
        dd.alert({ content: '加载banner发生错误' });
      },
      complete: function (res) {
      }
    });
  }
})