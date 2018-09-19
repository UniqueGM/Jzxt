using Qx.Jzxt.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.QxJzxt.ViewModels.Org.ROOT
{
    public class Position_M
    {
        public position ToModel()
        {
            return new position()
            {
                position_id=position_id,
                descripe = descripe,
                name = name,
                note = note,
                position_type_id=position_type_id
            };
        }
        public static Position_M ToViewModel(List<SelectListItem> typeItem)
        {
            return new Position_M()
            {
                typeItem= typeItem
            };
        }
        public static Position_M ToViewModel(List<SelectListItem> typeItem,string position_id,string name,string describe,string note,string typeid)
        {
            return new Position_M()
            {
                typeItem = typeItem,
                descripe = describe,
                name = name,
                note = note,
                position_id = position_id,
                position_type_id = typeid
            };
        }
        [StringLength(50)]
        public string position_id { get; set; }
        [Display(Name ="职位类型")]
        [StringLength(50)]
        public string position_type_id { get; set; }
        public List<SelectListItem> typeItem { get; set; }

        [Display(Name = "职位名称")]
        [StringLength(50)]
        public string name { get; set; }

        [Display(Name = "职位描述")]
        public string descripe { get; set; }

        [Display(Name = "备注")]
        [StringLength(50)]
        public string note { get; set; }
    }
}