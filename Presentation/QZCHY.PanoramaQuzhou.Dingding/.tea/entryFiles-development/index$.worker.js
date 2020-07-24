if(!self.__appxInited) {
self.__appxInited = 1;


require('./config$');


      if( navigator.userAgent && (navigator.userAgent.indexOf('LyraVM') > 0 || navigator.userAgent.indexOf('AlipayIDE') > 0) ) {
        var AFAppX = self.AFAppX.getAppContext ? self.AFAppX.getAppContext().AFAppX : self.AFAppX;
      } else {
        importScripts('https://appx/af-appx.worker.min.js');
        var AFAppX = self.AFAppX;
      }
      self.getCurrentPages = AFAppX.getCurrentPages;
      self.getApp = AFAppX.getApp;
      self.Page = AFAppX.Page;
      self.App = AFAppX.App;
      self.my = AFAppX.bridge || AFAppX.abridge;
      self.abridge = self.my;
      self.Component = AFAppX.WorkerComponent || function(){};
      self.$global = AFAppX.$global;
      self.requirePlugin = AFAppX.requirePlugin;
    

if(AFAppX.registerApp) {
  AFAppX.registerApp({
    appJSON: appXAppJson,
  });
}



function success() {
require('../../app');
require('../../pages/index/index?hash=7da53690ff015fafc40ebbe2de99bf33c6f02acd');
require('../../pages/home/home?hash=7da53690ff015fafc40ebbe2de99bf33c6f02acd');
require('../../pages/map/map?hash=7da53690ff015fafc40ebbe2de99bf33c6f02acd');
require('../../pages/discovery/discovery?hash=7da53690ff015fafc40ebbe2de99bf33c6f02acd');
require('../../pages/projects/projects?hash=7da53690ff015fafc40ebbe2de99bf33c6f02acd');
require('../../pages/panorama/panorama?hash=7da53690ff015fafc40ebbe2de99bf33c6f02acd');
require('../../pages/projects/project_pano_locations/project_pano_locations?hash=7da53690ff015fafc40ebbe2de99bf33c6f02acd');
require('../../pages/introduction/introduction?hash=7da53690ff015fafc40ebbe2de99bf33c6f02acd');
}
self.bootstrapApp ? self.bootstrapApp({ success }) : success();
}