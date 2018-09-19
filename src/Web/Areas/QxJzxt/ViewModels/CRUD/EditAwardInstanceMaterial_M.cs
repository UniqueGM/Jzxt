using Qx.Jzxt.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.QxJzxt.ViewModels.CRUD
{
    public class EditAwardInstanceMaterial_M
    {
        public List<SelectListItem> materialtype;

        [StringLength(100)]
        [Display(Name = "材料类型")]
        public string materialtypeid { get; set; }

        [Display(Name = "材料类型")]
        public string name { get; set; }

        [Display(Name = "数量")]
        public int count { get; set; }

        [StringLength(50)]
        public string awardmaterialinstanceid { get; set; }

        [StringLength(50)]
        public string instanceid { get; set; }

        public static EditAwardInstanceMaterial_M ToViewModel(award_materia_instance data,string awardmaterialinstanceid)
        {
            return new EditAwardInstanceMaterial_M()
            {
                awardmaterialinstanceid= awardmaterialinstanceid,
                count =data.count.Value,
                name=data.material_type.typename
            };
        }

        //public award_materia_instance ToModel(string awardmaterialinstanceid)
        //{
        //    return new award_materia_instance()
        //    {
        //        awardmaterialinstanceid = awardmaterialinstanceid,
        //        materialtypeid = materialtypeid,
        //        instanceid = instanceid,
        //        count = count
        //    };
        //}
    }
}