using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Qx.Jzxt.Entity;
using Qx.Jzxt.Model;

namespace Web.Areas.QxJzxt.ViewModels.CRUD
{
    public class DetailMaterialApply_M
    {
        public user_material MaterialApplyDetail { get;  set; }
        public List<MaterialValue> MaterialAttrAndValue { get;  set; }

        public static DetailMaterialApply_M ToViewModel(List<MaterialValue> MaterialAttrAndValue, user_material MaterialApplyDetail)
        {
            return new DetailMaterialApply_M()
            {
                MaterialAttrAndValue=MaterialAttrAndValue,
                MaterialApplyDetail= MaterialApplyDetail
            };
        }
    }
}