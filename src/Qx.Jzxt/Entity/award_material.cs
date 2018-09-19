namespace Qx.Jzxt.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class award_material
    {
        [Required]
        [StringLength(100)]
        public string materialtypeid { get; set; }

        [Required]
        [StringLength(100)]
        public string awardtypeid { get; set; }

        [Key]
        [StringLength(100)]
        public string awardmaterialid { get; set; }

        public virtual award_type award_type { get; set; }

        public virtual material_type material_type { get; set; }
    }
}
