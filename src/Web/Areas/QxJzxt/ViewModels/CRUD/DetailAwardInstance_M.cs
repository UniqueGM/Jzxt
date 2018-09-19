using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Qx.Jzxt.Entity;

namespace Web.Areas.QxJzxt.ViewModels.CRUD
{
    public class DetailAwardInstance_M
    {
        [Required]
        [StringLength(100)]
        [Display(Name = "奖项类型")]
        public string awardtypename { get; set; }

        public int? state { get; set; }

        [StringLength(50)]
        public string instanceid { get; set; }

        [StringLength(100)]
        [Display(Name = "奖项实施名称")]
        public string instancename { get; set; }

        [Display(Name = "开始时间")]
        public DateTime? starttime { get; set; }

        [Display(Name = "结束时间")]
        public DateTime? endtime { get; set; }

        [Display(Name = "奖金")]
        public int? bonus { get; set; }

        public static DetailAwardInstance_M ToViewModel(award_instance instance)
        {
            return new DetailAwardInstance_M()
            {
                awardtypename = instance.award_type.awardname,
                state = instance.state,
                instanceid = instance.instanceid,
                instancename = instance.instancename,
                starttime = instance.starttime,
                endtime = instance.endtime,
                bonus = instance.bonus
            };
        }    
    }
}