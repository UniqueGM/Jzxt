using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Qx.Jzxt.Entity;

namespace Web.Areas.QxJzxt.ViewModels.CRUD
{
    public class AddMaterialAttrs_M
    {
        public List<SelectListItem> typeList;

        [StringLength(100)]
        public string materialattrid { get; set; }

        [StringLength(100)]
        [Required]
        [Display(Name = "属性名")]
        public string attrname { get; set; }

        [StringLength(50)]
        [Required]
        [Display(Name = "属性类型")]
        public string infodatatype { get; set; }

        public material_attrs ToModel(string attrid)
        {
            return new material_attrs()
            {
                materialattrid = attrid,
                attrname = attrname,
                infodatatype = infodatatype
            };
        }

        public static AddMaterialAttrs_M ToViewModel(List<SelectListItem>typeList )
        {
            return new AddMaterialAttrs_M()
            {
                typeList= typeList
            };
        }
    }
}