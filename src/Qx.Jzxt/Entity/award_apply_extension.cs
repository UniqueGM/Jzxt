namespace Qx.Jzxt.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class award_apply_extension
    {
        [Key]
        [StringLength(100)]
        public string award_apply_extension_id { get; set; }

        [Required]
        [StringLength(100)]
        public string applyid { get; set; }

        [Required]
        [StringLength(100)]
        public string old_instanceid { get; set; }

        [Required]
        [StringLength(100)]
        public string now_instanceid { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime revise_time { get; set; }

        [Required]
        [StringLength(100)]
        public string revise_user { get; set; }

        public virtual award_apply award_apply { get; set; }

        public virtual award_instance award_instance { get; set; }

        public virtual award_instance award_instance1 { get; set; }
    }
}
