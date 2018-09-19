namespace Qx.Jzxt.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("org")]
    public partial class org
    {
        [StringLength(50)]
        public string orgid { get; set; }

        [StringLength(50)]
        public string orgname { get; set; }

        [StringLength(50)]
        public string fatherorgid { get; set; }

        [Column(TypeName = "text")]
        public string description { get; set; }
    }
}
