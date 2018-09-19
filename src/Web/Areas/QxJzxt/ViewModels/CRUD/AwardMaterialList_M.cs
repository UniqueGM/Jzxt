using Qx.Jzxt.Entity;
using Qx.Jzxt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Areas.QxJzxt.ViewModels.CRUD
{
    public class AwardMaterialList_M
    {
        public List<AwardMaterialInstance> data { get;  set; }

        public static AwardMaterialList_M ToViewModel(List<AwardMaterialInstance> data)
        {
            return new AwardMaterialList_M()
            {
                data=data
            };
        }
    }
}