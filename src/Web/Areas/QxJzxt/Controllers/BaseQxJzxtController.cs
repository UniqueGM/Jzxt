using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Controllers.Base;

namespace Web.Areas.QxJzxt.Controllers
{
    public class BaseQxJzxtController : BaseController
    {
        // GET: QxJzxt/BaseQxJzxt
        protected void InitReport(string Title, string AddLink, bool showDeafultButton = true, string ExtraParam = "")
        {
            base.InitReport(Title, AddLink, ExtraParam, showDeafultButton, "ecampus.jzxt");
        }
    }
}