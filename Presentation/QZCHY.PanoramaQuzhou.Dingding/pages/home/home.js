var x1,
  y1,
  moving = false,
  // $viewer = $('#pano_viewer'),
  // $cube = $('#cube'),
  // w_v = $viewer.width(), // width of viewer
  // h_v = $viewer.height(), // height of viewer
  c_x_deg = 0, // current x
  c_y_deg = 0,
  perspective = 450; // current y

var app = getApp();
Page({
  data: {
    screenHeight:100,
    cubeBoxSize:3000
  },
  onLoad() {
 
 this.setData({
   screenHeight:app.globalData.systemInfo.windowHeight,
   cubeBoxSize:app.globalData.systemInfo.windowHeight*4
 });

    //   $viewer.on('mousedown', function(e) {
    //     x1 = e.pageX - $(this).offset().left;
    //     y1 = e.pageY - $(this).offset().top;

    //     moving = true;
    //     e.preventDefault();
    //   });

    //   $(document).on('mousemove', function(e) {
    //     if( moving === true ) {
    //       x2 = e.pageX - $viewer.offset().left;
    //       y2 = e.pageY - $viewer.offset().top;

    //       var dist_x = x2 - x1,
    //           dist_y = y2 - y1,
    //           perc_x = dist_x / w_v,
    //           perc_y = dist_y / h_v,
    //           deg_x = Math.atan2(dist_y, perspective) / Math.PI * 180,
    //           deg_y = -Math.atan2(dist_x, perspective) / Math.PI * 180,
    //           i,
    //           vendors = ['-webkit-', '-moz-', ''];

    //       c_x_deg += deg_x;
    //       c_y_deg += deg_y;
    //       c_x_deg = Math.min(90, c_x_deg);
    //       c_x_deg = Math.max(-90, c_x_deg);

    //       c_y_deg %= 360;

    //       deg_x = c_x_deg;
    //       deg_y = c_y_deg;

    //       for(i in vendors) {
    //         $cube.css(vendors[i] + 'transform', 'rotateX(' + deg_x + 'deg) rotateY(' + deg_y + 'deg)');
    //       }

    //       x1 = x2;
    //       y1 = y2;
    //     }
    //     e.preventDefault();
    //   }).on('mouseup', function(e) {
    //     moving = false;
    //     e.preventDefault();
    //   });

    // // https://codepen.io/anon/pen/aMqbMN

  },

  touchStart: function (e) {

    console.log(e);


  }

});
