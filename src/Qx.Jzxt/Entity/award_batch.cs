namespace Qx.Jzxt.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class award_batch
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public award_batch()
        {
            award_batch_instance = new HashSet<award_batch_instance>();
        }

        [Key]
        [StringLength(100)]
        public string batchid { get; set; }

        [Required]
        [StringLength(100)]
        public string batchname { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string description { get; set; }

        [StringLength(50)]
        public string IsCurrentBatch { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<award_batch_instance> award_batch_instance { get; set; }
    }
}
