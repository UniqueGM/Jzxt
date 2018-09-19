using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Qx.Jzxt.Entity;

namespace Web.Areas.QxJzxt.ViewModels.Org.OrgCRUD
{
    public class AddOrgLevel_M
    {
        public string organization_level_id { get; set; }
       [Display(Name = "级别名称")]
        public string name { get; set; }
        [Display(Name = "级别备注")]
        public string note { get; set; }
        public organization_level ToModel()
        {
            return new organization_level()
            {
                name = name,
                note = note
            };
        }
    }
}