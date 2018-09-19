using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Qx.Jzxt.Entity;

namespace Web.Areas.QxJzxt.ViewModels.CRUD
{
    public class EditAwardInstance_M
    {
        public List<SelectListItem> _awardtype { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "奖励类型")]
        public string awardtypeid { get; set; }

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

        public static EditAwardInstance_M ToViewModel(award_instance instance,List<SelectListItem> awardtype)
        {
            return new EditAwardInstance_M()
            {
                _awardtype = awardtype,

                awardtypeid = instance.awardtypeid,
                state = instance.state,
                instanceid = instance.instanceid,
                instancename = instance.instancename,
                starttime = instance.starttime,
                endtime = instance.endtime,
                bonus = instance.bonus
            };
        }

        public award_instance ToModel(string instanceid)
        {
            return new award_instance()
            {
                awardtypeid = awardtypeid,
                state = state,
                instanceid = instanceid,
                instancename = instancename,
                starttime = starttime,
                endtime = endtime,
                bonus = bonus
            };
        }
    }
}