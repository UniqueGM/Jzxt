using Qx.Jzxt.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Areas.QxJzxt.ViewModels.CRUD
{
    public class AddAwardType_M
    {
        public string awardtypeid { get; set; }

        [Display(Name = "奖项名称")]
        [Required]
        public string awardname { get; set; }

        [Display(Name = "奖项描述")]
        [Required]
        public string description { get; set; }
        public award_type ToModel(string awardtypeid)
        {
            return new award_type()
            {
                awardtypeid= awardtypeid,
                awardname= awardname,
                description= description
            };
        }
    }
}