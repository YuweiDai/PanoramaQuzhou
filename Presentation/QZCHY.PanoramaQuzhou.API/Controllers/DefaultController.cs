using QZCHY.PanoramaQuzhou.Core.Domain.Panoramas;
using QZCHY.PanoramaQuzhou.Services.Panoramas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QZCHY.PanoramaQuzhou.API.Controllers
{
    [RoutePrefix("Default")]
    public class DefaultController : ApiController
    {
        private readonly ISceneService _sceneService;
        private readonly ILocationService _locationService;
        private readonly IProjectService _projectService;


        public DefaultController(ISceneService sceneService,ILocationService locationService, IProjectService projectService)
        {
            _sceneService = sceneService;
            _locationService = locationService;
            _projectService = projectService;
        }


        /// <summary>
        /// hello world
        /// </summary>
        /// <returns></returns>
        [Route("HW")]
        [HttpGet]
        public IHttpActionResult HelloWorld()
        {
            return Ok("Helloworld");
        }


        [Route("AddLocations")]
        [HttpGet]
        public IHttpActionResult InsertLocations()
        {
            return Ok("");


            var locaitonJSON = "[{'OBJECTID':'1','LNG':'118.8521295','LAT':'28.97117788','Name':'市民公园'},{'OBJECTID':'2','LNG':'118.852229','LAT':'28.96215729','Name':'西区大草原'},{'OBJECTID':'3','LNG':'118.8523285','LAT':'28.95313669','Name':'严家淤半岛'},{'OBJECTID':'4','LNG':'118.8524279','LAT':'28.94411608','Name':'城南医院'},{'OBJECTID':'5','LNG':'118.8525273','LAT':'28.93509546','Name':'欧景御花苑'},{'OBJECTID':'6','LNG':'118.8520299','LAT':'28.98019845','Name':'花园258'},{'OBJECTID':'7','LNG':'118.8519303','LAT':'28.98921901','Name':'盈川小区'},{'OBJECTID':'8','LNG':'118.8421727','LAT':'28.94402824','Name':'孙姜大桥'},{'OBJECTID':'9','LNG':'118.841972','LAT':'28.96206939','Name':'新湖玫瑰园'},{'OBJECTID':'10','LNG':'118.8418716','LAT':'28.97108994','Name':'阳光水岸'},{'OBJECTID':'11','LNG':'118.8420724','LAT':'28.95304882','Name':'恒大御景半岛'},{'OBJECTID':'12','LNG':'118.8417711','LAT':'28.98011048','Name':'春江月'},{'OBJECTID':'13','LNG':'118.8416706','LAT':'28.98913101','Name':'沪昆高速2'},{'OBJECTID':'14','LNG':'118.831715','LAT':'28.9619807','Name':'下回龙村'},{'OBJECTID':'15','LNG':'118.8319175','LAT':'28.94393962','Name':'汪村'},{'OBJECTID':'16','LNG':'118.831411','LAT':'28.98904222','Name':'沪昆高速1'},{'OBJECTID':'17','LNG':'118.8315124','LAT':'28.98002173','Name':'衢州西高速出口'},{'OBJECTID':'18','LNG':'118.8318163','LAT':'28.95296017','Name':'回龙小区'},{'OBJECTID':'19','LNG':'118.8316137','LAT':'28.97100122','Name':'壹号院'},{'OBJECTID':'20','LNG':'118.8215603','LAT':'28.95287073','Name':'压潮村'},{'OBJECTID':'21','LNG':'118.8214581','LAT':'28.96189123','Name':'沃华庄园'},{'OBJECTID':'22','LNG':'118.8216624','LAT':'28.94385022','Name':'叶家大桥'},{'OBJECTID':'23','LNG':'118.8212537','LAT':'28.97993219','Name':'后姜村'},{'OBJECTID':'24','LNG':'118.8213559','LAT':'28.97091172','Name':'姜家山村'},{'OBJECTID':'25','LNG':'118.8113043','LAT':'28.95278051','Name':'长河线1'},{'OBJECTID':'26','LNG':'118.810995','LAT':'28.97984188','Name':'柴家'},{'OBJECTID':'27','LNG':'118.8110981','LAT':'28.97082143','Name':'柴家窑'},{'OBJECTID':'28','LNG':'118.8112012','LAT':'28.96180098','Name':'长河线2'},{'OBJECTID':'29','LNG':'118.8114073','LAT':'28.94376003','Name':'前徐村'},{'OBJECTID':'30','LNG':'118.8008404','LAT':'28.97073037','Name':'六一水库'},{'OBJECTID':'31','LNG':'118.8010483','LAT':'28.95268951','Name':'丰收水库'},{'OBJECTID':'32','LNG':'118.8009444','LAT':'28.96170995','Name':'姜家'},{'OBJECTID':'33','LNG':'118.8011522','LAT':'28.94366907','Name':'上黄塘水库'},{'OBJECTID':'34','LNG':'118.8007364','LAT':'28.97975078','Name':'方家圹水库'},]";


            var locations = Newtonsoft.Json.JsonConvert.DeserializeObject<IList<PanoramaLocation>>(locaitonJSON);

            foreach(var location in locations)
            {
                _locationService.InsertPanoramaLocation(location);
            }
        }

        [Route("AddProjects")]
        [HttpGet]
        public IHttpActionResult InsertProjects()
        {
            return Ok("");
            var projectJson = "[{'Id':'9','Name':'未来大厦'},{'Id':'10','Name':'衢州市人才社区'},{'Id':'11','Name':'鹿鸣半岛项目'},{'Id':'12','Name':'鹿鸣山文化院街'},{'Id':'13','Name':'鹿鸣半岛酒店综合体'},{'Id':'14','Name':'市儿童公园'},{'Id':'15','Name':'高铁西站枢纽'},{'Id':'16','Name':'水亭门历史文化街区'},{'Id':'17','Name':'历史街区风貌衔接工程'},{'Id':'18','Name':'东门遗址公园建设工程'},{'Id':'19','Name':'信安湖光影秀'},{'Id':'20','Name':'十里江滨景观改造提升'},{'Id':'21','Name':'全民健身中心'},{'Id':'22','Name':'综合客运枢纽'},{'Id':'23','Name':'信安湖活力岛'},{'Id':'24','Name':'南湖广场改造提升工程'},{'Id':'25','Name':'衢州市区生活垃圾焚烧发电项目'},{'Id':'26','Name':'金瑞泓8 - 12英寸集成电路用硅片项目'},{'Id':'27','Name':'柯城斗潭片区建设'},{'Id':'28','Name':'大荫山丛林穿越项目'},{'Id':'29','Name':'中国运动汽车城'},{'Id':'30','Name':'衢江抽水蓄能电站'},{'Id':'31','Name':'衢江新田铺康养综合体'},{'Id':'32','Name':'铜山源全域旅游休闲度假区'},]";

            var projects = Newtonsoft.Json.JsonConvert.DeserializeObject<IList<Project>>(projectJson);

            foreach(var project in projects)
            {
                project.LogoUrl = "Minapp/Projects/" + project.Id+".jpg";
                _projectService.InsertProject(project);
            }

        }    

    }
}
