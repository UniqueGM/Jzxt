namespace Qx.Jzxt.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class material_type_attrs
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public material_type_attrs()
        {
            material_values = new HashSet<material_values>();
        }

        [Key]
        [StringLength(100)]
        public string materialtypeattrid { get; set; }

        [StringLength(100)]
        public string materialattrid { get; set; }

        [StringLength(100)]
        public string materialtypeid { get; set; }

        [StringLength(100)]
        public string attrtypeid { get; set; }

        public int sequence { get; set; }

        public int? isprimarykey { get; set; }

        [StringLength(100)]
        public string defaultvalue { get; set; }

        public virtual material_attrs material_attrs { get; set; }

        public virtual material_type material_type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<material_values> material_values { get; set; }
    }
}
