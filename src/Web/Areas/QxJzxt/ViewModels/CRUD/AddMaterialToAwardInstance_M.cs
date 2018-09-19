using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Qx.Jzxt.Entity;

namespace Web.Areas.QxJzxt.ViewModels.CRUD
{
    public class AddMaterialToAwardInstance_M
    {
        public List<SelectListItem> materialtype;

        [StringLength(100)]
        [Display(Name = "材料类型")]
        public string materialtypeid { get; set; }

        [Display(Name = "数量")]
        public int count { get; set; }

        [StringLength(50)]
        public string awardmaterialinstanceid { get; set; }

        [StringLength(50)]
        public string instanceid { get; set; }

        public static AddMaterialToAwardInstance_M ToViewModel(List<SelectListItem>materialtype,string instanceid )
        {
            return new AddMaterialToAwardInstance_M()
            {
                materialtype= materialtype,
                instanceid= instanceid
            };
        }

        public award_materia_instance ToModel(string awardmaterialinstanceid)
        {
            return new award_materia_instance()
            {
                awardmaterialinstanceid= awardmaterialinstanceid,
                materialtypeid= materialtypeid,
                instanceid= instanceid,
                count=count
            };
        }
    }
}