using Qx.Jzxt.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Areas.QxJzxt.ViewModels.CRUD
{
    public class DetailSchoolAwardExamine_M
    {
        [Display(Name = "学校审核意见")]
        public string school_opinion { get; set; }

        public static DetailSchoolAwardExamine_M ToViewModel(award_apply data)
        {
            return new DetailSchoolAwardExamine_M()
            {
                school_opinion = data.school_opinion
            };
        }
    }
}