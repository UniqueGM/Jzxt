using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Qx.Jzxt.Entity;

namespace Web.Areas.QxJzxt.ViewModels.Org.OrgCRUD
{
    public class PositionTypeEdit_M
    {
        public string position_type_id { get; set; }

        [Display(Name = "职位类型名称")]
        public string name { get; set; }

        public string father_id { get; set; }

        public static PositionTypeEdit_M ToViewModel(position_type data)
        {
            return new PositionTypeEdit_M()
            {
                position_type_id = data.position_type_id,
                name = data.name,
                father_id = data.father_id
            };
        }

        public position_type ToModel()
        {
            return new position_type()
            {
                position_type_id = position_type_id,
                name = name,
                father_id = "ROOT"
            };
        }
    }
}