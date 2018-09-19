using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Qx.Jzxt.Entity;

namespace Web.Areas.QxJzxt.ViewModels.CRUD
{
    public class AddAwardInstanceBaseInfo_M
    {
        public List<SelectListItem> baseinfo;

        [Required]
        [StringLength(50)]
        [Display(Name = "基础信息")]
        public string baseInfoid { get; set; }

        [Required]
        [StringLength(50)]
        public string instanceid { get; set; }

        [Key]
        [StringLength(50)]
        public string instancebaseinfoid { get; set; }

        public static AddAwardInstanceBaseInfo_M ToViewModel(List<SelectListItem> baseinfo, string instanceid)
        {
            return new AddAwardInstanceBaseInfo_M()
            {
                baseinfo= baseinfo,
                instanceid= instanceid
            };
        }

        public award_instance_baseInfo ToModel(string instancebaseinfoid)
        {
            return new award_instance_baseInfo()
            {
                instancebaseinfoid= instancebaseinfoid,
                instanceid= instanceid,
                baseInfoid=baseInfoid
            };
        }
    }
}