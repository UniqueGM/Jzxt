using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Qx.Jzxt.Entity;

namespace Web.Areas.QxJzxt.ViewModels.Org.OrgCRUD
{
    public class PositionTypeAdd_M
    {

        public string position_type_id { get; set; }

        [Display(Name = "职位类型名称")]
        public string name { get; set; }

        public string father_id { get; set; }

        public position_type ToModel()
        {
            return new position_type()
            {
                name= name,
                father_id= "ROOT"
            };
        }
    }
}