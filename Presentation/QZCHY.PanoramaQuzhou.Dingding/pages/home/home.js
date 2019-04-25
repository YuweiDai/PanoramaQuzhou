var x1,
  y1, x2, y2,
  panoramas,
  moving = false,
  w_v = 375, // width of viewer
  h_v = 667, // height of viewer
  c_x_deg = 0, // current x
  c_y_deg = 0,
  perspective = 450; // current y

var startX = 0, startY = 0;
var refresh = false;
var app = getApp();    //初始化app对象
var index=0;
var pageSize=15;
var ps=[];
Page({
  data: {
    screenHeight: 100,
    cubeBoxSize: 3000,
    transform: "",
    panoramas: [],
    currentPanoIndex: 0,
    currentPano: null,
    mapUrl:"../map/map",
    background: [],
    autoplay: false,
    vertical:true,
    current:0,
    interval: 3000,
    circular: true,
  },
  onLoad(){
   
  this.loadScenes(0);
  
  },
  loadScenes:function(i){
    var lat=app.globalData.location.lat;
    var lng=app.globalData.location.lng;

 var url=app.globalData.apiBaseUrl + 'panoramas/previewlist?lat='+lat+'&lng='+lng+'&pageSize='+pageSize+'&index='+i;
            //获取hot panoramas
          var that = this;
          app.requestGet(url, null, true).then(
            function (res) {
               
              panoramas = res.data;
                 panoramas.forEach(function (item) {
                   var basePath = app.globalData.resourceUrl + "panos/" + item.imgPath + "/pic_thumb/pano_";
                   item.imgs = { front: "", back: "", up: "", down: "", left: "", right: "" };
                   item.imgs.front = basePath + "f.jpg";
                   item.imgs.back = basePath + "b.jpg";
                   item.imgs.up = basePath + "u.jpg";
                   item.imgs.down = basePath + "d.jpg";
                   item.imgs.left = basePath + "l.jpg";
                   item.imgs.right = basePath + "r.jpg";
                   item.navToUrl = '../panorama/panorama?id=' + item.id;

                   ps.push(item);
               });
             that.setData({  
                  panoramas:ps, 
                  screenHeight: app.globalData.systemInfo.windowHeight,
                  cubeBoxSize: app.globalData.systemInfo.windowHeight * 4,
               });
             //that.data.panoramas.push(p);
             console.log(that.data.panoramas);

       for(var i=0;i<that.data.panoramas.length;i++){
          that.setData({
          currentPano: that.data.panoramas[i],
          transform:that.data.panoramas[i].imgs.back,
          currentPanoIndex: i,
          mapUrl:"../map/map?level=16&centerLng=" +that.data.panoramas[i].lng+ "&centerLat="+that.data.panoramas[i].lat
        });
        
       }
        
            });
 
},
  handletouchmove:function(e){
    console.log( e.detail);

    if((parseInt(e.detail.current)%15)==13){
      var a = 1+Math.floor( e.detail.current/15);
      console.log(a);
      this.loadScenes(a);
   }
   console.log(e.detail.current);


},
  onShareAppMessage() {
   // 返回自定义分享信息
  },
  navToPano: function (event) {
    var that = this;
    dd.navigateTo({
      url: that.data.currentPano.navToUrl
      //event.currentTarget.dataset.id
    })
  },

  toMap: function () {
    var that=this;
    app.setLocation().then(function () {
    
      dd.switchTab({
        url:that.data.mapUrl
      })
    }, function () { });
  },

  refreshPano: function (forwad) {
    var index = this.data.currentPanoIndex + 1;
    if (index >= this.data.panoramas.length) index = 0;
    this.setData({
      currentPanoIndex: index,
      currentPano: this.data.panoramas[index],
          mapUrl:"../map/map?level=16&centerLng=" +this.data.panoramas[index].lng+ "&centerLat="+this.data.panoramas[index].lat
    });
  },

  //触摸控制  暂时取消
  //touchStart: function (e) {
     //x1 = e.changedTouches[0].pageX;
    // y1 = e.changedTouches[0].pageY;
    //moving = true;
    // console.log(e);
   // startX = e.changedTouches[0].pageX,
     // startY = e.changedTouches[0].pageY;
      //refresh = false;
  //},

  //触摸控制  暂时取消  
 // touchMove: function (e) {

    //if (refresh) return;

    //var moveEndX = e.changedTouches[0].pageX;
   // var moveEndY = e.changedTouches[0].pageY;
   // var X = moveEndX - startX - 5;
   // var Y = moveEndY - startY - 5;
   
    //if (Math.abs(Y) > Math.abs(X) && Y < 0) {
     // this.refreshPano();
     // refresh = true;
   // }
  //},

 // touchEnd: function (e) {
    // moving = false;
  //},

 // touchCancel: function (e) {
    // moving = false;
 // },
  //changeVertical(e){
   // this.setData({
     // vertical: this.data.vertical
   // });
  //},
  
});
