namespace Qx.Jzxt.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class award_materia_instance
    {
        [Required]
        [StringLength(100)]
        public string materialtypeid { get; set; }

        [Key]
        [StringLength(100)]
        public string awardmaterialinstanceid { get; set; }

        [Required]
        [StringLength(100)]
        public string instanceid { get; set; }

        public int? count { get; set; }

        public virtual award_instance award_instance { get; set; }

        public virtual material_type material_type { get; set; }
    }
}
