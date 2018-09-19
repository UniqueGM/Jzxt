using Qx.Jzxt.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Areas.QxJzxt.ViewModels.CRUD
{
    public class MaterialExaminePass_M
    {
        public string orgawardinstanceid { get; set; }

        [Display(Name = "审核意见")]
        public string opinion { get; set; }
        public user_material data { get;  set; }
        public string usermaterialid { get;  set; }

        public static MaterialExaminePass_M ToViewModel(user_material data)
        {
            return new MaterialExaminePass_M()
            {
                data = data,
                usermaterialid = data.usermaterialid,
                opinion= data.opinion
            };
        }
    }
}