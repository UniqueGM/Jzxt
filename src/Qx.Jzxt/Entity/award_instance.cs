namespace Qx.Jzxt.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class award_instance
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public award_instance()
        {
            award_apply = new HashSet<award_apply>();
            award_apply_extension = new HashSet<award_apply_extension>();
            award_apply_extension1 = new HashSet<award_apply_extension>();
            award_batch_instance = new HashSet<award_batch_instance>();
            award_instance_baseInfo = new HashSet<award_instance_baseInfo>();
            award_materia_instance = new HashSet<award_materia_instance>();
        }

        [Required]
        [StringLength(100)]
        public string awardtypeid { get; set; }

        public int? state { get; set; }

        [Key]
        [StringLength(100)]
        public string instanceid { get; set; }

        [StringLength(100)]
        public string instancename { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? starttime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? endtime { get; set; }

        public int? bonus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<award_apply> award_apply { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<award_apply_extension> award_apply_extension { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<award_apply_extension> award_apply_extension1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<award_batch_instance> award_batch_instance { get; set; }

        public virtual award_type award_type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<award_instance_baseInfo> award_instance_baseInfo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<award_materia_instance> award_materia_instance { get; set; }
    }
}
