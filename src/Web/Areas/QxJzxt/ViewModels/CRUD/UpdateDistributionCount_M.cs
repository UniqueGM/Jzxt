using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Areas.QxJzxt.ViewModels.CRUD
{
    public class UpdateDistributionCount_M
    {
        public string orgawardinstanceid { get;  set; }

        [Display(Name = "数量")]
        public int count { get; set; }
        public static UpdateDistributionCount_M ToViewModel(string orgawardinstanceid,int count)
        {
            return new UpdateDistributionCount_M()
            {
                orgawardinstanceid= orgawardinstanceid,
                count= count
            };
        }
    }
}