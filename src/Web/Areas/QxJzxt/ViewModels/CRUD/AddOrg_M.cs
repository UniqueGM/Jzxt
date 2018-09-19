using Qx.Jzxt.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Areas.QxJzxt.ViewModels.CRUD
{
    public class AddOrg_M
    {
        public string orgid { get; set; }

        [Display(Name = "学院名称")]
        public string orgname { get; set; }

        public string fatherorgid { get; set; }

        [Display(Name = "学院描述")]
        public string description { get; set; }
        public org ToModel()
        {
            return new org()
            {
                orgname= orgname,
                fatherorgid="0",
                description= description
            };
        }
    }
}