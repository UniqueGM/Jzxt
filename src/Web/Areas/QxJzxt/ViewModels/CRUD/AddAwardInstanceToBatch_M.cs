using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Qx.Jzxt.Entity;

namespace Web.Areas.QxJzxt.ViewModels.CRUD
{
    public class AddAwardInstanceToBatch_M
    {
        public string id;
        public List<SelectListItem> batch;
        public string batchinstanceid { get; set; }

        [StringLength(50)]
        [Display(Name = "批次")]
        public string batchid { get; set; }

        [Required]
        [StringLength(50)]
        public string instanceid { get; set; }
        public static AddAwardInstanceToBatch_M ToViewModel(string id,List<SelectListItem> batch)
        {
            return  new AddAwardInstanceToBatch_M()
            {
                instanceid = id,
                batch = batch
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