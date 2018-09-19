using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Qx.Jzxt.Model;

namespace Web.Areas.QxJzxt.ViewModels.CRUD
{
    public class AddMyMaterial_M
    {
        public List<MaterialAttr> List { get; set; }
        public string materialtypeid { get; set; }

        //   public string  marterial_values;
        public static AddMyMaterial_M ToViewModel(string materialtypeid, List<MaterialAttr> list)
        {
            return new AddMyMaterial_M()
            {
                List = list,
                materialtypeid= materialtypeid
            };
        }
    }
}