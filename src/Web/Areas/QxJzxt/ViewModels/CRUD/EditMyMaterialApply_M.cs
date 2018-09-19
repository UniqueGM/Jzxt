using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Qx.Jzxt.Model;

namespace Web.Areas.QxJzxt.ViewModels.CRUD
{
    public class EditMyMaterialApply_M
    {
        public List<MaterialValue> materialApply { get;  set; }
        public string usermaterialid { get;  set; }

        public static EditMyMaterialApply_M ToViewModel(string usermaterialid,List<MaterialValue> materialApply)
        {
            return new EditMyMaterialApply_M()
            {
                materialApply= materialApply,
                usermaterialid= usermaterialid
            };
        }
    }
}