using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using qx.permmision.v2.Entity;
using qx.permmision.v2.Interfaces;
using Web.Controllers.Base;
using Web.Models;

namespace Web.Controllers
{
    public class OpenController : BaseController
    {
        private readonly qx.permmision.v2.Interfaces.IPermmisionService _permmisionService;
        private readonly IPermissionProvider _permissionProvider;
        public OpenController(IPermmisionService permmisionService, IPermissionProvider permissionProvider)
        {
            _permmisionService = permmisionService;
            _permissionProvider = permissionProvider;
        }

        // GET: Open
        public ActionResult Index()
        {
            return View();
        }

      public  class login
        {
          public login(IPermissionProvider permissionProvider, string uid)
          {
                permission_user u =null;
              _permissionProvider = permissionProvider;
              try
              {
                    u = _permissionProvider.UserInfo(uid);
              }
              catch (Exception)
              {
                  
              }
             
              var ok = u != null;
              this.uid = uid;
              this.state = ok ? 1 : 0;
              this.msg = ok ? "登陆成功": "登陆失败";
              this.name = ok ? u.nick_name:"";
          }

          private readonly IPermissionProvider _permissionProvider;
          public string uid;
            public int state;
            public string msg;
            public string name;

        }
        // GET: Open/Login
        public ActionResult Login(string uid)
        {
            return Json(new login(_permissionProvider,uid), JsonRequestBehavior.AllowGet);
        }
        // GET: Open/GetMenu
        public ActionResult GetMenu(string uid = "1325112032")
        {
            return Json(NavbarIndex.Init(_permmisionService.GetNavbarByUserId(uid),
                 _permmisionService.GetForbidenButtonByUserId(uid)),JsonRequestBehavior.AllowGet);
        }
    }
}