using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Qx.Jzxt.Entity;

namespace Web.Areas.QxJzxt.ViewModels.CRUD
{
    public class EditMaterialType_M
    {
        [StringLength(100)]
        public string materialtypeid { get; set; }

        [StringLength(100)]
        [Required]
        [Display(Name = "材料类型名称")]
        public string typename { get; set; }

        [Column(TypeName = "text")]
        [Required]
        [Display(Name = "材料类型描述")]
        public string description { get; set; }

        public static EditMaterialType_M ToViewModel(material_type type)
        {
            return new EditMaterialType_M()
            {
                materialtypeid = type.materialtypeid,
                typename = type.typename,
                description = type.description
            };
        }

        public material_type ToModel(string materialtypeid)
        {
            return new material_type()
            {
                materialtypeid = materialtypeid,
                typename = typename,
                description = description
            };
        }
    }
}