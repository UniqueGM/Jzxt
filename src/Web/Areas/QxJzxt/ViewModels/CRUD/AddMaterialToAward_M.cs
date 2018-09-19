using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Qx.Jzxt.Entity;

namespace Web.Areas.QxJzxt.ViewModels.CRUD
{
    public class AddMaterialToAward_M
    {
        public List<SelectListItem> awardtype { get; set; }

        [Required]
        [StringLength(100)]
        public string materialtypeid { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "奖项类型")]
        public string awardtypeid { get; set; }

        [StringLength(50)]
        public string awardmaterialid { get; set; }

        public static AddMaterialToAward_M ToViewModel(List<SelectListItem> awardtype ,string materialtypeid)
        {
            return new AddMaterialToAward_M()
            {
                awardtype= awardtype,
                materialtypeid= materialtypeid,
            };
        }

        public award_material ToModel(string awardmaterialid)
        {
            return new award_material()
            {
                awardmaterialid= awardmaterialid,
                awardtypeid= awardtypeid,
                materialtypeid= materialtypeid
            };
        }
    }
}