using Qx.Jzxt.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.QxJzxt.ViewModels.Org.ROOT
{
    public class OrgnizationAdd_M
    {
        public orgnization ToModel()
        {
            return new orgnization()
            {
                father_id= orgnization_id,
                descripe = descripe,
                name=name,
                note = note,
                orgnization_type_id = orgnization_type_id,
                organization_level_id = organization_level_id,
            };
        }
        public static OrgnizationAdd_M ToViewModel(string orgnization_id, List<SelectListItem> typeSelect, List<SelectListItem> levelSelect,orgnization fatherOrg)
        {
            return new OrgnizationAdd_M
            {
                fatherOrgName = fatherOrg.name,
                orgnization_id = orgnization_id,
                typeSelect= typeSelect,
                levelSelect= levelSelect
            };
        }

        [Display(Name = "上级组织机构")]

        public string fatherOrgName { get; set; }

        [Display(Name = "组织机构ID")]

        public string orgnization_id { get; set; }

        [Display(Name = "组织机构父ID")]

        public string father_id { get; set; }

        [Display(Name = "组织机构名称")]

        public string name { get; set; }

        [Display(Name = "描述")]

        public string descripe { get; set; }

        [Display(Name = "组织机构类型")]
        public string orgnization_type_id { get; set; }

        [Display(Name = "组织机构类型名称")]
        public string type_name { get; set; }

        [Display(Name = "备注")]
        public string note { get; set; }

        [Display(Name = "子系统")]
        public string sub_system { get; set; }

        [Display(Name = "组织机构级别")]
        public string organization_level_id { get; set; }

        [Display(Name = "组织机构级别名称")]
        public string level_name { get; set; }
        public List<SelectListItem> typeSelect { get;  set; }
        public List<SelectListItem> levelSelect { get;  set; }
    }
}