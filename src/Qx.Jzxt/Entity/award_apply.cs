namespace Qx.Jzxt.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class award_apply
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public award_apply()
        {
            award_apply_extension = new HashSet<award_apply_extension>();
            award_instance_value = new HashSet<award_instance_value>();
            user_apply_material = new HashSet<user_apply_material>();
        }

        [Key]
        [StringLength(100)]
        public string applyid { get; set; }

        [StringLength(100)]
        public string userid { get; set; }

        [Required]
        [StringLength(100)]
        public string instanceid { get; set; }

        public int? statusid { get; set; }

        public int? squence { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? apply_time { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? college_examine_time { get; set; }

        public int? mark { get; set; }

        [Required]
        [StringLength(100)]
        public string batchinstanceid { get; set; }

        [Column(TypeName = "text")]
        public string college_opinion { get; set; }

        [Column(TypeName = "text")]
        public string school_opinion { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? school_examine_time { get; set; }

        [StringLength(100)]
        public string college_examine_person { get; set; }

        [StringLength(100)]
        public string school_examine_person { get; set; }

        public virtual apply_status apply_status { get; set; }

        public virtual award_batch_instance award_batch_instance { get; set; }

        public virtual award_instance award_instance { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<award_apply_extension> award_apply_extension { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<award_instance_value> award_instance_value { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<user_apply_material> user_apply_material { get; set; }
    }
}
