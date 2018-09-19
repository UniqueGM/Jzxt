using Qx.Jzxt.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Areas.QxJzxt.ViewModels.CRUD
{
    public class DetailCollegeAwardExamine_M
    {
        [Display(Name = "学院审核意见")]
        public string college_opinion { get;  set; }

        [Display(Name = "分数")]
        public int? mark { get;  set; }

        [Display(Name = "次序")]
        public int? squence { get;  set; }

        public static DetailCollegeAwardExamine_M ToViewModel(award_apply data)
        {
            return new DetailCollegeAwardExamine_M()
            {
                mark = data.mark,
                squence = data.squence,
                college_opinion = data.college_opinion
            };
        }
    }
}