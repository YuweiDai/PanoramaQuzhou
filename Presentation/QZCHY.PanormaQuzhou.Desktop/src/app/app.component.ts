import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { Modal, Toast } from 'ng-zorro-antd-mobile';
import { Picker } from 'ng-zorro-antd-mobile';
import { iif, from } from 'rxjs';
import { ConfigService } from './services/configService';
import { PanoramaLocationService } from './services/panoramaLocationService';
import { PanoramaLocation } from './viewModels/PanoramaLocation';

declare var mapboxgl: any;
declare var dd: any;

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.less']
})
export class AppComponent {
  map: any;
  markers: any[];
  mapHeight = 100;
  modelVisible = false;
  detailVisible = false;
  currentGovernment = null;
  formSelect = false;

  constructor(private cd: ChangeDetectorRef, private configService: ConfigService, private panoramaLocationService: PanoramaLocationService) {
    var height = window.innerHeight;
    this.mapHeight = height
    this.cd = cd;
    this.markers = [];
  }

  ngOnInit() {
    var app = this;
    var ding=dd;


    setTimeout(function () {

      app.map = new mapboxgl.Map({
        container: 'map',
        minZoom: 7,
        maxZoom: 19,
        style: 'http://map.zjditu.cn/vtiles/styles/tdt/streets.json',
        zoom: 12,
        center: [118.8546503613, 28.9731569040],
        renderWorldCopies: false,
        localIdeographFontFamily: "'黑体','san-serif'"
      });
      var nav = new mapboxgl.NavigationControl();
      app.map.addControl(nav, 'top-left');
      app.map.addControl(new MyLocateControl(), 'bottom-left');

      app.map.on('zoomend', function (data) {
        console.log(data);
      });

      dd.getLocation({
        success(res) { 
          var lng = res.longitude;
          var lat = res.latitude; 
          //添加定位点
          var el = document.createElement('div');
          el.className = 'mapboxgl-user-location-dot mapboxgl-marker mapboxgl-marker-anchor-center';
          el.style.transform = "translate(-50%, -50%) translate(960px, 469px);";

          // add location to map
          var m = new mapboxgl.Marker({ element: el, anchor: "bottom" })
            .setLngLat([lng,lat]).addTo(app.map);
        },
        fail() {
          alert('定位失败');
        }
      })



      //获取拍摄点位
      app.panoramaLocationService.getGeoPanoramaLocations()
        .subscribe(response => {
          console.log(response)
          response.forEach(function (item) {

            var el = document.createElement('div');
            el.className = 'marker';
            el.style.backgroundImage = 'url(./assets/location.png)';
            el.style.backgroundSize = "cover";
            el.style.width = '20px';
            el.style.height = '20px';
            el.style.cursor = "pointer";

            // create the popup
            var navBtn = document.createElement('strong');
            navBtn.innerText = item.name + (item.defaultPanoramaSceneId > 0 ? "(点击查看)" : "(全局拍摄中...)");
            navBtn.addEventListener('click', function () {
              if (dd = undefined) {
                alert("no dd obejct")
                return;
              }
              else {
                alert("123");

                dd.navigateTo({
                  url: '../Panorama/Panorama?sid=' + item.defaultPanoramaSceneId
                })
              }
            });

            var popup = new mapboxgl.Popup({ offset: 25 }).setDOMContent(navBtn);

            // add marker to map
            var marker = new mapboxgl.Marker({ element: el, anchor: "bottom" })
              .setLngLat([item.lng, item.lat]).setPopup(popup).addTo(app.map);

            app.markers.push(marker);
          });
        });
    }, 500);

    //      //
    //app.map.resize();
  }
}


// 自定义定位按钮
export class MyLocateControl {
  _map: any;
  _container: HTMLElement

  onAdd(map) {
    this._map = map;
    this._container = document.createElement('div');
    this._container.className = 'mapboxgl-ctrl mapboxgl-ctrl-group';
    this._container.innerHTML = '<button class="mapboxgl-ctrl-icon mapboxgl-ctrl-geolocate" type="button" aria-label="Geolocate" aria-pressed="false"></button>';
    return this._container;
  }

  onRemove() {
    this._container.parentNode.removeChild(this._container);
    this._map = undefined;
  }
}

// Control implemented as ES5 prototypical class
// function HelloWorldControl() { }

// HelloWorldControl.prototype.onAdd = function(map) {
//   this._map = map;
//   this._container = document.createElement('div');
//   this._container.className = 'mapboxgl-ctrl';
//   this._container.textContent = 'Hello, world';
//   return this._container;
// };

// HelloWorldControl.prototype.onRemove = function () {
//    this._container.parentNode.removeChild(this._container);
//    this._map = undefined;
// };