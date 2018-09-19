namespace Qx.Jzxt.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class award_baseInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public award_baseInfo()
        {
            award_instance_baseInfo = new HashSet<award_instance_baseInfo>();
            award_type_baseInfo = new HashSet<award_type_baseInfo>();
        }

        [Key]
        [StringLength(100)]
        public string baseinfoid { get; set; }

        [StringLength(100)]
        public string infoname { get; set; }

        [StringLength(50)]
        public string infodatatype { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<award_instance_baseInfo> award_instance_baseInfo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<award_type_baseInfo> award_type_baseInfo { get; set; }
    }
}
