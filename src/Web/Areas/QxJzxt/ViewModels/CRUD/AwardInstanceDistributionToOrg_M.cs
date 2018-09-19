using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Qx.Jzxt.Entity;

namespace Web.Areas.QxJzxt.ViewModels.CRUD
{
    public class AwardInstanceDistributionToOrg_M
    {
        public string batchinstanceid { get; set; }

        public List<SelectListItem> OrgList { get; set; }

        [Display(Name = "数量")]
        public int count { get; set; }

        [Display(Name = "学院")]
        public string orgid { get; set; }
        public List<orgnization> allCollege { get; set; }
        public string batch_name { get; set; }
        public int total_count { get; set; }
        public string award_name { get; set; }
        public List<org_award_instance> DistributionList { get; set; }

        public static AwardInstanceDistributionToOrg_M ToViewModel(string batchinstanceid, List<orgnization> allCollege, award_batch_instance batch_instance, List<org_award_instance> DistributionList)
        {
            return new AwardInstanceDistributionToOrg_M()
            {
                DistributionList = DistributionList,
                batchinstanceid = batchinstanceid,
                allCollege = allCollege,
                batch_name = batch_instance.award_batch.batchname,
                total_count = batch_instance.total_count,
                award_name = batch_instance.award_instance.instancename
            };
        }
    }
}