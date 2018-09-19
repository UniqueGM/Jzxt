using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Qx.Jzxt.Entity;

namespace Web.Areas.QxJzxt.ViewModels.CRUD
{
    public class AddBaseInfoToAward_M
    {
        public List<SelectListItem> baseinfo;

        [Display(Name = "奖项")]
        public string awardtypeid { get; set; }
        public string awardname { get; set; }

        [Display(Name = "基本信息名称")]
        public string baseinfoid { get; set; }


        [Display(Name = "次序")]
        public int sequence { get; set; }
        

        public static AddBaseInfoToAward_M ToViewModel(List<SelectListItem> baseinfo, string awardtypeid)
        {
            return new AddBaseInfoToAward_M()
            {
                awardtypeid= awardtypeid,
                baseinfo = baseinfo
            };
        }

        public award_type_baseInfo ToModel()
        {
            return new award_type_baseInfo()
            {
                baseinfoid = baseinfoid,
                awardtypeid = awardtypeid,
                sequence= sequence
            };
        }
    }
}