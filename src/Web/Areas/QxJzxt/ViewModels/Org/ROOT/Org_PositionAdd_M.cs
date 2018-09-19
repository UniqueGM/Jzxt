using Qx.Jzxt.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.QxJzxt.ViewModels.Org.ROOT
{
    public class Org_PositionAdd_M
    {
        public static orgnization_position ToModel(string random,string orgnization_id,string position_id)
        {
            return new orgnization_position
            {
                orgnization_position_id=random,
                position_id= position_id,
                orgnization_id= orgnization_id,
            };
        }
        public static Org_PositionAdd_M ToViewModel(orgnization org)
        {
            return new Org_PositionAdd_M
            {
                orgnization_id=org.orgnization_id,
            };
        }
        [Key]
        [Display(Name = "组织机构与职位关系编号")]
        [StringLength(100)]
        public string orgnization_position_id { get; set; }
        [Display(Name = "职位编号")]
        [StringLength(100)]
        public string position_id { get; set; }
        [Display(Name = "组织机构编号")]
        [Key]
        [StringLength(100)]
        public string orgnization_id { get; set; }

        [Display(Name = "职位类型编号")]
        [StringLength(100)]
        public string position_type_id { get; set; }

        [Display(Name = "职位名称")]
        [StringLength(100)]
        public string name { get; set; }

        [Display(Name = "描述")]
        [StringLength(100)]
        public string descripe { get; set; }

        [Display(Name = "备注")]
        [StringLength(100)]
        public string note { get; set; }

        [Display(Name = "职位类型名称")]
        [StringLength(100)]
        public string position_type_name { get; set; }
    
        

    }
}