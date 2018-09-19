using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Qx.Jzxt.Entity;

namespace Web.Areas.QxJzxt.ViewModels.CRUD
{
    public class AddAttrsToMaterialType_M
    {
        public static AddAttrsToMaterialType_M ToViewModel(List<SelectListItem> material,string materialattrid)
        {
            return new AddAttrsToMaterialType_M()
            {
                material= material,
                materialattrid= materialattrid
            };
        }
        public string materialtypeattrid { get; set; }
        [Display(Name = "材料类型")]
        public string materialtypeid { get; set; }
        public string materialattrid { get; set; }

        [Display(Name = "顺序")]
        [Required]
        public int sequence { get; set; }
        [StringLength(100)]
        public string attrtypeid { get; set; }


        public int? isprimarykey { get; set; }

        [StringLength(100)]
        public string defaultvalue { get; set; }
        public List<SelectListItem> material { get; set; }

        public material_type_attrs ToModel(string materialtypeattrid)
        {
            return new material_type_attrs()
            {
                materialtypeattrid = materialtypeattrid,
                materialtypeid = materialtypeid,
                materialattrid = materialattrid,
                attrtypeid=attrtypeid,
                sequence=sequence,
                isprimarykey=isprimarykey,
                defaultvalue=defaultvalue
            };
        }
    }
}