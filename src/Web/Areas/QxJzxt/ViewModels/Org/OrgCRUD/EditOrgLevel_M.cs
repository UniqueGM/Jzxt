using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Qx.Jzxt.Entity;

namespace Web.Areas.QxJzxt.ViewModels.Org.OrgCRUD
{
    public class EditOrgLevel_M
    {
        public static EditOrgLevel_M ToViewModel(organization_level data)
        {
            return new EditOrgLevel_M()
            {
                organization_level_id=data.organization_level_id,
                name=data.name,
                note = data.note
            };
        }

        public string organization_level_id { get; set; }
        [Display(Name = "级别名称")]
        public string name { get; set; }
        [Display(Name = "级别备注")]
        public string note { get; set; }

        public organization_level ToModel()
        {
            return new organization_level()
            {
                organization_level_id = organization_level_id,
                name = name,
                note = note
            };
        }
    }
}