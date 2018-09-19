using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Qx.Jzxt.Entity;

namespace Web.Areas.QxJzxt.ViewModels.CRUD
{
    public class DetailMaterialType_M
    {
        [StringLength(100)]
        public string materialtypeid { get; set; }

        [StringLength(100)]
        [Display(Name = "材料类型名称")]
        public string typename { get; set; }

        [Column(TypeName = "text")]
        [Display(Name = "材料类型描述")]
        public string description { get; set; }

        public static DetailMaterialType_M ToViewModel(material_type type)
        {
            return new DetailMaterialType_M()
            {
                materialtypeid = type.materialtypeid,
                typename = type.typename,
                description = type.description
            };
        }
    }
}