namespace Qx.Jzxt.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class material_values
    {
        [Required]
        [StringLength(100)]
        public string usermaterialid { get; set; }

        [Column(TypeName = "text")]
        public string materialvalue { get; set; }

        [Required]
        [StringLength(100)]
        public string materialtypeattrid { get; set; }

        [Key]
        [StringLength(100)]
        public string marterialvaluesid { get; set; }

        public virtual material_type_attrs material_type_attrs { get; set; }

        public virtual user_material user_material { get; set; }
    }
}
