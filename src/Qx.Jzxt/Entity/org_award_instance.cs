namespace Qx.Jzxt.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class org_award_instance
    {
        [Key]
        [StringLength(100)]
        public string orgawardinstanceid { get; set; }

        [Required]
        [StringLength(50)]
        public string orgid { get; set; }

        [Required]
        [StringLength(100)]
        public string batchinstanceid { get; set; }

        public int count { get; set; }

        public virtual award_batch_instance award_batch_instance { get; set; }

        public virtual orgnization orgnization { get; set; }
    }
}
