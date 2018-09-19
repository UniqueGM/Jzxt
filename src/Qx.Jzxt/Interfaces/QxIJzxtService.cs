using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Qx.Jzxt.Entity;
using Qx.Jzxt.Model;

namespace Qx.Jzxt.Interfaces
{
    public  interface QxIJzxtService
    {
        bool AwardInstanceDistributionToOrgUpdate(List<int> count, List<string> orgawardinstanceid);
        List<org_award_instance> GetDistributionList(string batchinstanceid);
        List<orgnization> GetAllCollege();
        List<SelectListItem> SearchBatchSelect();
        List<SelectListItem> SearchAwardTypeSelect();
        List<SelectListItem> SearchMaterialTypeSelect();
        bool FindAwardInstanceAboutBatch(string instanceid);
        bool FindBatchAboutAwardInstance(string batchid);
        List<SelectListItem> FindAwardTypeAboutMaterialList(string awardtypeid);
        bool FindMaterialAboutAwardInstance(string materialtypeid);
        bool FindAwardInstanceAboutAwardType(string awardtypeid);
        List<List<UserMaterial>> UserAwardMaterialAndVauleList(string applyid);
        List<SelectListItem> BaseInfoTypeList();
        List<UserMaterial> UserAwardMaterialList(string applyid);
        List<AwardInstanceBaseInfo> GetAwardInstanceBaseInfoValue(string applyid);
        bool FindUserApplyRecord(string uid, string batchinstanceid);
        bool AddUserApplyAward(string uid, string instanceid, string batchinstanceid, List<string> instancebaseinfoid, List<string> baseinfoValue, List<string> usermaterialid);
        List<UserMaterial> UserMaterialList(string uid);
        List<SelectListItem> SearchSchoolAwardSelect();
        List<SelectListItem> SearchCollegeAwardSelect();
        bool FindUserAwardApplyRecord(string uid, string batchinstanceid);
        List<AwardMaterialInstance> AwardMaterialList(string instanceid);
        List<SelectListItem> SearchCollegeMaterialSelect();
        bool FindOrgDistributionRecord(string orgid);
        org_award_instance Findorg_award_instanceRecord(string orgid, string batchinstanceid);
        bool AwardInstanceDistributionToOrg(string batchinstanceid, List<string> orgid, List<int> count);
        List<SelectListItem> OrgList();
        award_apply FindAwardApply(string uid, string batchinstanceid);
        bool AddAwardapplyFormMaterial(string uid, string instanceid, string batchinstanceid, string usermaterialid);
        bool AddAwardapplyFormBaseInfo(string uid, string instanceid, string batchinstanceid, List<string> instancebaseinfoid, List<string> value);
        List<AwardInstanceBaseInfo> GetAwardInstanceBaseInfo(string instanceid);
        bool OffCurrentBatch(string batchid);
        List<SelectListItem> AwardApplyStatus();
        user_material MaterialApplyDetail(string usermaterialid);
        bool SubmitMyMaterialApply(string usermaterialid);
        bool ReEditMaterialValue(string user_material_name, string usermaterialid, List<string> marterialvaluesid,List<string> attrValue);
        List<MaterialValue> MaterialAttrAndValue(string usermaterialid);
        List<SelectListItem> MaterialApplyStatus();
        bool AddUserMaterialAndMaterialValue(string uid,string materialid,string user_material_name, List<MaterialValue> materialValue);
        bool FindATBI(string baseinfoid, string awardtypeid);
        bool FindMTA(string materialtypeid, string materialattrid);
        bool FindAM(string materialtypeid, string awardtypeid);
        bool FindABI(string batchid, string instanceid);
        bool ChangeAwardInstanceStatus(string instanceid, string flag);
        bool FindAMI(string materialtypeid, string instanceid);
        bool FindAIB(string baseInfoid, string instanceid);
        List<award_type_baseInfo> FindATBList(string awardtypeid);
        bool AddAwardInstanceAndBaseinfoAndMaterial(award_instance award_instance_list);
        bool FindAwardInstanceApplyRecord(string batchinstanceid);
        List<MaterialAttr> FindMAList(string materialtypeid);
        bool SetCurrentBatch(string batchid);
        List<SelectListItem> TypeList();
    }
}
