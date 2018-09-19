using Qx.Jzxt.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Areas.QxJzxt.ViewModels.CRUD
{
    public class UserApplyAward_M
    {
        public List<AwardInstanceBaseInfo> BaseInfoList { get;  set; }
        public List<AwardMaterialInstance> MaterialList { get;  set; }
        public List<UserMaterial> UserMaterial { get;  set; }

        [Display(Name = "名称")]
        public string instancebaseinfoid { get; set; }
        public string baseinfovalue { get; set; }
        public string awardmaterialinstanceid { get; set; }
        public string materialtypeid { get; set; }
        public string typename { get; set; }
        public string usermaterialid { get; set; }
        public string material_name { get; set; }
        public int tote_count { get; set; }
        public int material_count { get; set; }
        public int baseinfo_count { get; set; }
        public string instanceid { get;  set; }
        public string batchinstanceid { get;  set; }

        public static UserApplyAward_M ToViewModel(
            string instanceid,
            string batchinstanceid,
            List<AwardInstanceBaseInfo> BaseInfoList, 
            List<AwardMaterialInstance> MaterialList, 
            List<UserMaterial> UserMaterial)
        {
            return new UserApplyAward_M()
            {
                instanceid= instanceid,
                batchinstanceid= batchinstanceid,
                BaseInfoList = BaseInfoList,
                MaterialList= MaterialList,
                UserMaterial= UserMaterial,
                baseinfo_count= BaseInfoList.Count,
                material_count= MaterialList.Count,
                tote_count= MaterialList.Count + 1//所有类型的材料+基本信息项
            };
        }
    }
}