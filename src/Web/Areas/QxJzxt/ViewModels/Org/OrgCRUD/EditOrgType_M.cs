using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Qx.Jzxt.Entity;

namespace Web.Areas.QxJzxt.ViewModels.Org.OrgCRUD
{
    public class EditOrgType_M
    {
        public string orgnization_type_id { get; set; }

        [Display(Name = "组织机构类型名")]
        public string name { get; set; }

        [Display(Name = "备注")]
        public string note { get; set; }

        public static EditOrgType_M ToViewModel(orgnization_type data)
        {
            return new EditOrgType_M()
            {
                orgnization_type_id=data.orgnization_type_id,
                name = data.name,
                note = data.note
            };
        }

        public orgnization_type ToModel()
        {
            return new orgnization_type()
            {
                orgnization_type_id = orgnization_type_id,
                name = name,
                note = note
            };
        }
    }
}