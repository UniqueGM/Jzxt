namespace Qx.Jzxt.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class award_instance_baseInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public award_instance_baseInfo()
        {
            award_instance_value = new HashSet<award_instance_value>();
        }

        [Required]
        [StringLength(100)]
        public string baseInfoid { get; set; }

        [Required]
        [StringLength(100)]
        public string instanceid { get; set; }

        [Key]
        [StringLength(100)]
        public string instancebaseinfoid { get; set; }

        public int sequence { get; set; }

        public virtual award_baseInfo award_baseInfo { get; set; }

        public virtual award_instance award_instance { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<award_instance_value> award_instance_value { get; set; }
    }
}
