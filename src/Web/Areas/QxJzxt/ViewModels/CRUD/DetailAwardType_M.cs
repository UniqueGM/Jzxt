using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Qx.Jzxt.Entity;

namespace Web.Areas.QxJzxt.ViewModels.CRUD
{
    public class DetailAwardType_M
    {
        public string awardtypeid { get; set; }

        [Display(Name = "奖项名称")]

        public string awardname { get; set; }

        [Display(Name = "奖项描述")]

        public string description { get; set; }
        public static DetailAwardType_M ToViewModel(award_type award_type)
        {
            return new DetailAwardType_M()
            {
                awardname = award_type.awardname,
                description = award_type.description
            };
        }
    }
}