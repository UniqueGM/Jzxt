using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Qx.Jzxt.Entity;

namespace Web.Areas.QxJzxt.ViewModels.CRUD
{
    public class EditMTA_M
    {
        [Display(Name = "材料类型")]
        public string materialtype { get; set; }
        [Display(Name = "材料属性")]
        public string attrname { get; set; }
        public material_type_attrs materialattr { get; set; }

        public static EditMTA_M ToViewModel(string materialtype,string attrname, material_type_attrs materialattr)
        {
            return new EditMTA_M()
            {
                materialtype = materialtype,
                attrname = attrname,
                materialattr= materialattr,

                materialtypeattrid = materialattr.materialtypeattrid,
                materialtypeid = materialattr.materialtypeid,
                materialattrid = materialattr.materialattrid,
                attrtypeid=materialattr.attrtypeid,
                sequence = materialattr.sequence,
                isprimarykey=materialattr.isprimarykey,
                defaultvalue = materialattr.defaultvalue
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
                attrtypeid = attrtypeid,
                sequence = sequence,
                isprimarykey = isprimarykey,
                defaultvalue = defaultvalue
            };
        }
    }
}