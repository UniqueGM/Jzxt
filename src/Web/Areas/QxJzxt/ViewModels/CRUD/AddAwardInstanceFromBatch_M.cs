using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Qx.Jzxt.Entity;

namespace Web.Areas.QxJzxt.ViewModels.CRUD
{
    public class AddAwardInstanceFromBatch_M
    {
        public List<SelectListItem> awardInstance { get; set; }
        public string batchid { get; set; }

        [Display(Name = "实施奖项")]
        public string instanceid { get; set; }
        public static AddAwardInstanceFromBatch_M ToViewModel(List<SelectListItem> instance, string batchid)
        {
            return new AddAwardInstanceFromBatch_M()
            {
                awardInstance= instance,
                batchid= batchid
            };
        }

        public award_batch_instance ToModel(string batchinstanceid)
        {
            return new award_batch_instance()
            {
                batchinstanceid= batchinstanceid,
                batchid= batchid,
                instanceid= instanceid
            };

        }
    }
}