using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Qx.Jzxt.Entity;

namespace Web.Areas.QxJzxt.ViewModels.CRUD
{
    public class AddAwardBatch_M
    {
        [StringLength(50)]
        public string batchid { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "批次名称")]
        public string batchname { get; set; }

        [Column(TypeName = "text")]
        [Required]
        [Display(Name = "描述")]
        public string description { get; set; }
        public string IsCurrentBatch { get; set; }
        public award_batch ToModel(string batchid)
        {
            return new award_batch()
            {
                batchid = batchid,
                batchname = batchname,
                description = description,
                IsCurrentBatch="0"//默认不是当前批次
            };
        }
    }
}