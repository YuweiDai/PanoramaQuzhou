Page({
  data: {
    targetUrl:"http://220.191.238.125/qzqj?id="
  },
  onLoad(query) {

    var sceneId=query.sid;
    var newUrl=this.data.targetUrl+sceneId;

    console.log(newUrl)

    this.setData({
      targetUrl:newUrl
    });
 
  },
  onShareAppMessage() {
   // 返回自定义分享信息
  },  
});
