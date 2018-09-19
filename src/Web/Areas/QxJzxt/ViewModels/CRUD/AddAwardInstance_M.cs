using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Qx.Jzxt.Entity;

namespace Web.Areas.QxJzxt.ViewModels.CRUD
{
    public class AddAwardInstance_M
    {
        public List<award_type_baseInfo> awardtypebaseInfolist;

        public string _awardtypename { get; set; }

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

        public static AddAwardInstance_M ToViewModel(award_type data, string awardtypeid, List<award_type_baseInfo> awardtypebaseInfolist)
        {
            return new AddAwardInstance_M()
            {
                awardtypeid= awardtypeid,
                _awardtypename = data.awardname,
                starttime = DateTime.Now,
                endtime = DateTime.Now,
                awardtypebaseInfolist= awardtypebaseInfolist
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