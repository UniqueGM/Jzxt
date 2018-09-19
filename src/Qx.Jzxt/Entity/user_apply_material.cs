namespace Qx.Jzxt.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class user_apply_material
    {
        [Key]
        [StringLength(100)]
        public string applymaterialid { get; set; }

        [Required]
        [StringLength(100)]
        public string applyid { get; set; }

        [Required]
        [StringLength(100)]
        public string usermaterialid { get; set; }

        public virtual award_apply award_apply { get; set; }

        public virtual user_material user_material { get; set; }
    }
}
