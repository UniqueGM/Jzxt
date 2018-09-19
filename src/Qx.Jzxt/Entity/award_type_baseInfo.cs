namespace Qx.Jzxt.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class award_type_baseInfo
    {
        [Required]
        [StringLength(100)]
        public string awardtypeid { get; set; }

        [Required]
        [StringLength(100)]
        public string baseinfoid { get; set; }

        [Key]
        [StringLength(100)]
        public string awardtypebaseinfoid { get; set; }

        public int sequence { get; set; }

        public virtual award_baseInfo award_baseInfo { get; set; }

        public virtual award_type award_type { get; set; }
    }
}
