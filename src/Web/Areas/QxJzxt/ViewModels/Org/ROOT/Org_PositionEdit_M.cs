using Qx.Jzxt.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.QxJzxt.ViewModels.Org.ROOT
{
    public class Org_PositionEdit_M
    {
        public position ToModel()
        {
            return new position
            {
               
            };
        }
        public static Org_PositionEdit_M ToViewModel()
        {
            return new Org_PositionEdit_M
            {
               
            };
        }

        [Display(Name = "职位编号")]
        [Key]
        [StringLength(100)]
        public string position_id { get; set; }

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