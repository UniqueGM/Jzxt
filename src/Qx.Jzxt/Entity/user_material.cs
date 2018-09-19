namespace Qx.Jzxt.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class user_material
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public user_material()
        {
            material_values = new HashSet<material_values>();
            user_apply_material = new HashSet<user_apply_material>();
        }

        [Required]
        [StringLength(100)]
        public string materialtypeid { get; set; }

        [StringLength(100)]
        public string userid { get; set; }

        [Key]
        [StringLength(100)]
        public string usermaterialid { get; set; }

        public int? statusid { get; set; }

        [Column(TypeName = "text")]
        public string opinion { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? material_apply_time { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? examine_time { get; set; }

        [StringLength(200)]
        public string name { get; set; }

        [StringLength(100)]
        public string examine_person { get; set; }

        public virtual material_type material_type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<material_values> material_values { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<user_apply_material> user_apply_material { get; set; }

        public virtual user_material_status user_material_status { get; set; }
    }
}
