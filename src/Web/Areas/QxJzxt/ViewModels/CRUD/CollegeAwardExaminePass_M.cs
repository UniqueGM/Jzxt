using Qx.Jzxt.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Areas.QxJzxt.ViewModels.CRUD
{
    public class CollegeAwardExaminePass_M
    {

        public string applyid { get; set; }
        public string userid { get; set; }
        public string instanceid { get; set; }
        public int? statusid { get; set; }

        [Display(Name = "次序")]
        public int squence { get; set; }
        public DateTime? apply_time { get; set; }
        public DateTime? examine_time { get; set; }

        [Display(Name = "分数")]
        public int mark { get; set; }
        public string batchinstanceid { get; set; }


        [Display(Name = "学院意见")]
        public string college_opinion { get; set; }

        public string school_opinion { get; set; }
        public static CollegeAwardExaminePass_M ToViewModel(string applyid, award_apply data)
        {
            return new CollegeAwardExaminePass_M()
            {
                applyid = applyid,
                mark = Convert.ToInt32(data.mark),
                squence = Convert.ToInt32(data.squence),
                college_opinion = data.college_opinion
            };
        }
    }
}