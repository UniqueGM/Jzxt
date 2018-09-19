namespace Qx.Jzxt.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class award_batch_instance
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public award_batch_instance()
        {
            award_apply = new HashSet<award_apply>();
            org_award_instance = new HashSet<org_award_instance>();
        }

        [Key]
        [StringLength(100)]
        public string batchinstanceid { get; set; }

        [Required]
        [StringLength(100)]
        public string batchid { get; set; }

        [Required]
        [StringLength(100)]
        public string instanceid { get; set; }

        public int total_count { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<award_apply> award_apply { get; set; }

        public virtual award_batch award_batch { get; set; }

        public virtual award_instance award_instance { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<org_award_instance> org_award_instance { get; set; }
    }
}
