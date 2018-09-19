using Qx.Jzxt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Areas.QxJzxt.ViewModels.CRUD
{
    public class WriteAwardBaseInfoValue_M
    {
        public string batchinstanceid { get;  set; }
        public List<AwardInstanceBaseInfo> data { get;  set; }
        public string instanceid { get;  set; }

        public static WriteAwardBaseInfoValue_M ToViewModel(string instanceid,string batchinstanceid,List<AwardInstanceBaseInfo> data)
        {
            return new WriteAwardBaseInfoValue_M()
            {
                data= data,
                instanceid= instanceid,
                batchinstanceid= batchinstanceid
            };
        }
    }
}