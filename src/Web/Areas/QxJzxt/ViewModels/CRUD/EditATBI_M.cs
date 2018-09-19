using Qx.Jzxt.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Areas.QxJzxt.ViewModels.CRUD
{
    public class EditATBI_M
    {
        public award_type_baseInfo data { get; set; }
        [Display(Name = "次序")]
        public int sequence { get; set; }

        public string awardtypebaseinfoid { get; set; }
        public string baseinfoid { get;  set; }
        public string awardtypeid { get;  set; }

        public static EditATBI_M ToViewModel(award_type_baseInfo data)
        {
            return new EditATBI_M()
            {
                sequence = data.sequence,
                awardtypebaseinfoid=data.awardtypebaseinfoid,
                baseinfoid= data.baseinfoid,
                awardtypeid=data.awardtypeid
            };
        }
        public award_type_baseInfo ToModel()
        {
            return new award_type_baseInfo()
            {
                awardtypebaseinfoid= awardtypebaseinfoid,
                baseinfoid= baseinfoid,
                awardtypeid= awardtypeid,
                sequence= sequence
            };
        }
    }
}