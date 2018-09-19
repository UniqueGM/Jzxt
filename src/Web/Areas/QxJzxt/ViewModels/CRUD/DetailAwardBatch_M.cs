using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Qx.Jzxt.Entity;

namespace Web.Areas.QxJzxt.ViewModels.CRUD
{
    public class DetailAwardBatch_M
    {
        [StringLength(50)]
        public string batchid { get; set; }

        [StringLength(50)]
        [Display(Name = "批次名称")]
        public string batchname { get; set; }

        [Column(TypeName = "text")]
        [Display(Name = "描述")]
        public string description { get; set; }

        public static DetailAwardBatch_M ToViewModel(award_batch batch)
        {
            return new DetailAwardBatch_M()
            {
                batchid = batch.batchid,
                batchname = batch.batchname,
                description = batch.description
            };
        }
    }
}