namespace Qx.Jzxt.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class material_attrs
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public material_attrs()
        {
            material_type_attrs = new HashSet<material_type_attrs>();
        }

        [Key]
        [StringLength(100)]
        public string materialattrid { get; set; }

        [StringLength(100)]
        public string attrname { get; set; }

        [StringLength(50)]
        public string infodatatype { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<material_type_attrs> material_type_attrs { get; set; }
    }
}
