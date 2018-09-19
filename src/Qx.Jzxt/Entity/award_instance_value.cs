namespace Qx.Jzxt.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class award_instance_value
    {
        [Required]
        [StringLength(100)]
        public string applyid { get; set; }

        [Required]
        [StringLength(100)]
        public string instancebaseinfoid { get; set; }

        [Column(TypeName = "text")]
        public string value { get; set; }

        [Key]
        [StringLength(100)]
        public string awardinstancevalueid { get; set; }

        public virtual award_apply award_apply { get; set; }

        public virtual award_instance_baseInfo award_instance_baseInfo { get; set; }
    }
}
