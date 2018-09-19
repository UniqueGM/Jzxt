using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Qx.Jzxt.Entity;

namespace Web.Areas.QxJzxt.ViewModels.Org.OrgCRUD
{
    public class Org_Position_M
    {
        public string orgnization_position_id { get; set; }
        public string orgnization_id { get; set; }

        [Display(Name = "职位")]
        public string position_id { get; set; }
        public List<SelectListItem> positionSelect { get;  set; }

        [Display(Name = "所属组织机构")]
        public string org_name { get;  set; }
        public orgnization org { get;  set; }

        public static Org_Position_M ToViewModel(string orgnization_id,List<SelectListItem> positionSelect, orgnization org)
        {
            return new Org_Position_M()
            {
                orgnization_id= orgnization_id,
                positionSelect= positionSelect,
                org_name=org.name,
                org= org
            };
        }

        public orgnization_position ToModel()
        {
            return new orgnization_position()
            {
                orgnization_id = orgnization_id,
                position_id = position_id
            };
        }
    }
}