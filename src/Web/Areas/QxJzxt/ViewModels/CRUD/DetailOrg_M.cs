using Qx.Jzxt.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Areas.QxJzxt.ViewModels.CRUD
{
    public class DetailOrg_M
    {
        public org data { get; set; }
        public string orgid { get; set; }

        [Display(Name = "学院名称")]
        public string orgname { get; set; }

        public string fatherorgid { get; set; }

        [Display(Name = "学院描述")]
        public string description { get; set; }
        public static DetailOrg_M ToViewModel(string orgid, org data)
        {
            return new DetailOrg_M()
            {
                data = data,
                orgid = orgid,
                orgname = data.orgname,
                description = data.description
            };
        }
    }
}