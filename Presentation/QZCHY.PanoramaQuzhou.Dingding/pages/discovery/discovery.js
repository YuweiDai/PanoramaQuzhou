Page({
  data: {
    banners:[
      {
        src:"../../resources/images/b1.jpg",
        title:"banner1",
        url:""
      },
      {
        src:"../../resources/images/b2.jpg",
        title:"banner2",
        url:""
      },
      {
        src:"../../resources/images/b3.jpg",
        title:"banner3",
        url:""
      }      
    ],
    projects:[
      {
        src:"../../resources/images/p1.jpg",
        url:""
      },
      {
        src:"../../resources/images/p2.jpg",
        url:""
      },
      {
        src:"../../resources/images/p3.jpg",
        url:""
      }
    ],
    tags:[
      {
        src:"../../resources/images/t2.jpg",
        title:"城市时光机",
        url:""
      },
      {
        src:"../../resources/images/t1.jpg",
        title:"美丽乡村",
        url:""
      },      
      {
        src:"../../resources/images/t3.jpg",
        title:"室内全景",
        url:""
      }
    ],    
    hotPanoramas:[
      {
        src:"../../resources/images/h1.jpg",
        title:"西区二期未来科技城",
        count:1213,
        date:"2019-03-12",
        url:""
      },
      {
        src:"../../resources/images/h2.jpg",
        title:"古城双修",
        count:1213,
        date:"2019-03-12"
      },
      {
        src:"../../resources/images/h3.jpg",
        title:"绿色产业集聚区",
        count:1213,
        date:"2019-03-12"
      },
      {
        src:"../../resources/images/h4.jpg",
        title:"衢江新城",
        count:1213,
        date:"2019-03-12"
      },
      {
        src:"../../resources/images/h5.jpg",
        title:"酒醉池淮",
        count:1213,
        date:"2019-03-12"
      }                        

    ],
    indicatorDots: true,
    autoplay: false,
    interval: 3000,
  },
  changeIndicatorDots(e) {
    this.setData({
      indicatorDots: !this.data.indicatorDots
    })
  },
  changeAutoplay(e) {
    this.setData({
      autoplay: !this.data.autoplay
    })
  },
  intervalChange(e) {
    this.setData({
      interval: e.detail.value
    })
  },
})