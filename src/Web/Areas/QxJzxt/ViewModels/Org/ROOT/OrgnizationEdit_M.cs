using Qx.Jzxt.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.QxJzxt.ViewModels.Org.ROOT
{
    public class OrgnizationEdit_M
    {
        public orgnization ToModel()
        {
            return new orgnization
            {
                orgnization_id= orgnization_id,
                father_id= father_id,
                name= name,
                descripe= descripe,
                note=note,
                sub_system=sub_system,
                orgnization_type_id= orgnization_type_id,
                organization_level_id = organization_level_id
            };
        }
        public static OrgnizationEdit_M ToViewModel(orgnization childOrg, orgnization fatherOrg, List<SelectListItem> typeSelect, List<SelectListItem> levelSelect)
        {
            if (fatherOrg != null)//不为根节点
            {
                return new OrgnizationEdit_M
                {
                    typeSelect = typeSelect,
                    levelSelect = levelSelect,
                    orgnization_id = childOrg.orgnization_id,
                    father_id = childOrg.father_id,
                    name = childOrg.name,
                    descripe = childOrg.descripe,
                    note = childOrg.note,
                    sub_system = childOrg.sub_system,
                    orgnization_type_id = childOrg.orgnization_type_id,
                    organization_level_id = childOrg.organization_level_id,
                    fatherOrgName = fatherOrg.name,
                };
            }
            else
            {//根节点
                return new OrgnizationEdit_M
                {
                    typeSelect = typeSelect,
                    levelSelect = levelSelect,
                    orgnization_id = childOrg.orgnization_id,
                    father_id = "0",
                    name = childOrg.name,
                    descripe = childOrg.descripe,
                    note = childOrg.note,
                    sub_system = childOrg.sub_system,
                    orgnization_type_id = childOrg.orgnization_type_id,
                    organization_level_id = childOrg.organization_level_id,
                    fatherOrgName = "根节点，无父组织机构",
                };
            }
        
        }

        [Display(Name = "上级组织机构")]
        public string fatherOrgName { get; set; }

        [Display(Name = "组织机构ID")]
        [Key]
        [StringLength(100)]
        public string orgnization_id { get; set; }

        [Display(Name = "组织机构父ID")]
        [StringLength(100)]
        public string father_id { get; set; }

        [Display(Name = "组织机构名称")]
        [StringLength(100)]
        public string name { get; set; }

        [Display(Name = "描述")]
        [StringLength(100)]
        public string descripe { get; set; }

        [Display(Name = "组织机构类型")]
        [StringLength(100)]
        public string orgnization_type_id { get; set; }

        [Display(Name = "备注")]
        [StringLength(100)]
        public string note { get; set; }

        [Display(Name = "子系统")]
        [StringLength(100)]
        public string sub_system { get; set; }

        [Display(Name = "组织机构级别")]
        [StringLength(100)]
        public string organization_level_id { get; set; }
        public List<SelectListItem> typeSelect { get;  set; }
        public List<SelectListItem> levelSelect { get;  set; }
    }
}