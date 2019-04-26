using QZCHY.PanoramaQuzhou.Core;
using QZCHY.PanoramaQuzhou.Core.Domain.Accounts;
using QZCHY.PanoramaQuzhou.Core.Domain.Common;
using QZCHY.PanoramaQuzhou.Core.Domain.Panoramas;
using QZCHY.PanoramaQuzhou.Core.Domain.Security;
using QZCHY.PanoramaQuzhou.Services.Accounts;
using QZCHY.PanoramaQuzhou.Services.Authentication;
using QZCHY.PanoramaQuzhou.Services.Configuration;
using QZCHY.PanoramaQuzhou.Services.Panoramas;
using QZCHY.PanoramaQuzhou.Services.Security;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Http;

namespace QZCHY.PanoramaQuzhou.API.Controllers
{
    [RoutePrefix("Demo")]
    public class DemoController : ApiController
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IAccountUserService _accountUserService;
        private readonly IAccountUserRegistrationService _accountUserRegistrationService;
        //private readonly IGenericAttributeService _genericAttributeService;
        //private readonly IWorkflowMessageService _workflowMessageService;
        private readonly IEncryptionService _encryptionService;

        private readonly IWebHelper _webHelper;
        private readonly IWorkContext _workContext;
        private readonly AccountUserSettings _accountUserSettings;
        private readonly CommonSettings _commonSettings;
        private readonly SecuritySettings _securitySettings;
        private readonly ISettingService _settingService;
        private readonly ISceneService _sceneService;
        private readonly ILocationService _locationService;

        public DemoController()
        {

        }

        public DemoController(IAuthenticationService authenticationService, IAccountUserService customerService, ISceneService sceneService, ILocationService locationService,
            IAccountUserRegistrationService customerRegistrationService,
        IEncryptionService encryptionService,  
        IWebHelper webHelper,
            IWorkContext workContext,
        AccountUserSettings customerSettings, CommonSettings commonSettings, SecuritySettings securitySettings, ISettingService settingService
            )
        {
            _authenticationService = authenticationService;
            _accountUserService = customerService;
            _accountUserRegistrationService = customerRegistrationService;
            _encryptionService = encryptionService;

            _webHelper = webHelper;
            _workContext = workContext;
            _accountUserSettings = customerSettings;

            _commonSettings = commonSettings;
            _securitySettings = securitySettings;
            _settingService = settingService;
            _sceneService = sceneService;
            _locationService = locationService;
        }

        [HttpGet]
        [Route("hw")]
        public IHttpActionResult HW()
        {
            return Ok("hello world");
        }

        [HttpGet]
        [Route("settings")]
        public IHttpActionResult GetAll()
        { 

            _settingService.SaveSetting<AccountUserSettings>(_accountUserSettings);

            _securitySettings.EncryptionKey = "qzczjwithqzghchy";
            _settingService.SaveSetting(_securitySettings);

            _commonSettings.TelAndMobliePartten = @"^(0[0-9]{2,3}\-)?([2-9][0-9]{6,7})+(\-[0-9]{1,4})?$|(^(13[0-9]|15[0|3|6|7|8|9]|18[0-9])\d{8}$)";
            _commonSettings.Time24Partten = @"^((1|0?)[0-9]|2[0-4]):([0-5][0-9])";

            _settingService.SaveSetting<CommonSettings>(_commonSettings);
             

            _settingService.SaveSetting(_accountUserSettings);

            return Ok("配置保存成功！");
        }

        [HttpGet]
        [Route("temp")]
        public IHttpActionResult Temp() {


            return Ok("导入成功");

            var filePath = @"D:\aa.xls";
            //string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + filePath + ";" + "Extended Properties=Excel 8.0;";
            string strConn = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'", filePath);
            System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection(strConn);
            conn.Open();
            string strExcel = "";
            System.Data.OleDb.OleDbDataAdapter myCommand = null;
            System.Data.DataSet ds = null;
            strExcel = "select * from [Sheet3$]";
            myCommand = new System.Data.OleDb.OleDbDataAdapter(strExcel, strConn);
            ds = new System.Data.DataSet();
            myCommand.Fill(ds, "table1");

            var table = ds.Tables[0];
            for (var i = 0; i < table.Rows.Count; i++)
            {
                var row = table.Rows[i];

                var location = _locationService.GetLocationByName(row[0].ToString());

                if (location == null) continue;

                var scene = new PanoramaScene();
                scene.Views = 0;
                scene.Stars = 0;
                scene.ProductionDate = Convert.ToDateTime(row[1]);
                scene.LastViewDate = DateTime.Now;
                scene.PanoramaLocation = location;
                _sceneService.InsertPanoramaScene(scene);

                location.DefaultPanoramaSceneId = scene.Id;
                _locationService.UpdatePanoramaLocation(location);
                 
            }

        }



    }
}