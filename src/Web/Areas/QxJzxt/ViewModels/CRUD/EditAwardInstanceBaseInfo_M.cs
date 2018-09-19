using Qx.Jzxt.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Areas.QxJzxt.ViewModels.CRUD
{
    public class EditAwardInstanceBaseInfo_M
    {
        public string baseInfoid { get; set; }
        public string instanceid { get; set; }
        public string instancebaseinfoid { get; set; }

        [Display(Name = "次序")]
        public int sequence { get; set; }
        public static EditAwardInstanceBaseInfo_M ToViewModel(award_instance_baseInfo data)
        {
            return new EditAwardInstanceBaseInfo_M()
            {
                baseInfoid=data.baseInfoid,
                instanceid=data.instanceid,
                instancebaseinfoid=data.instancebaseinfoid,
                sequence=data.sequence
            };
        }
        public award_instance_baseInfo ToModel()
        {
            return new award_instance_baseInfo()
            {
                baseInfoid = baseInfoid,
                instanceid = instanceid,
                instancebaseinfoid = instancebaseinfoid,
                sequence = sequence
            };
        }
    }
}