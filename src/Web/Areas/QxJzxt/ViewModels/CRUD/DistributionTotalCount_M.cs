using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Qx.Jzxt.Entity;

namespace Web.Areas.QxJzxt.ViewModels.CRUD
{
    public class DistributionTotalCount_M
    {
        [Display(Name = "奖项名称")]
        public string award_instance_name { get;  set; }
        public string batchid { get;  set; }

        public string batchinstanceid { get;  set; }

        [Display(Name = "奖项批次名称")]
        public string batch_name { get;  set; }
        public string instanceid { get;  set; }

        [Display(Name = "名额总数")]
        public int total_count { get;  set; }

        public static DistributionTotalCount_M ToViewModel(award_batch_instance batch_instance,award_batch batch,award_instance award_Instance,string batchinstanceid)
        {
            return new DistributionTotalCount_M()
            {
                batch_name= batch.batchname,
                award_instance_name= award_Instance.instancename,
                batchinstanceid= batchinstanceid,
                batchid= batch_instance.batchid,
                instanceid= batch_instance.instanceid,
                total_count= batch_instance.total_count
            };
        }

        public award_batch_instance ToModel()
        {
            return new award_batch_instance()
            {
                batchinstanceid = batchinstanceid,
                batchid = batchid,
                instanceid = instanceid,
                total_count = total_count
            };
        }
    }
}