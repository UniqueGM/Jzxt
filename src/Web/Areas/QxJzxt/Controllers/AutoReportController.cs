using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Qx.Jzxt.Interfaces;
using Qx.Tools.CommonExtendMethods;
using Web.Controllers.Base;
using Qx.Tools.Models.Report;

namespace Web.Areas.QxJzxt.Controllers
{
    public class AutoReportController : AccountFilterController
    {
        private QxIJzxtService _qxIJzxtService;

        public AutoReportController(QxIJzxtService qxIJzxtService)
        {
            _qxIJzxtService = qxIJzxtService;
        }

        //GET: QxJzxt/AutoReport
        public ActionResult Index()
        {
            return View();
        }

        #region QxJzxt/AutoReport/AwardTypeList 奖项类型
        public ActionResult AwardTypeList(string reportId, string Params)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("AwardTypeList",
                    new
                    {
                        reportId = "Qx.Jzxt.奖项类型",
                        Params = ";",
                        pageIndex = 1,
                        perCount = 10
                    });
            }
            Search.Add("奖项名称");
            InitReport("奖项类型列表", "/QxJzxt/CRUD/AddAwardType", "", true, "ecampus.jzxt");
            return ReportView();
        }
        #endregion

        #region QxJzxt/AutoReport/BaseInfoList 基本信息
        public ActionResult BaseInfoList(string reportId, string Params)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("BaseInfoList",
                    new
                    {
                        reportId = "Qx.Jzxt.基本信息",
                        Params = ";",
                        pageIndex = 1,
                        perCount = 10
                    });
            }
            Search.Add("信息名称");
            InitReport("基本信息列表", "/QxJzxt/CRUD/AddBaseInfo", "", true, "ecampus.jzxt");
            return ReportView();
        }
        #endregion

        #region QxJzxt/AutoReport/BatchList 批次
        public ActionResult BatchList(string reportId, string Params)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("BatchList",
                    new
                    {
                        reportId = "Qx.Jzxt.奖项批次",
                        Params = ";",
                        pageIndex = 1,
                        perCount = 10
                    });
            }
            Search.Add("批次名称");
            InitReport("奖项批次列表", "/QxJzxt/CRUD/AddAwardBatch", "", true, "ecampus.jzxt");
            return ReportView();
        }
        #endregion

        #region QxJzxt/AutoReport/MaterialList 材料类型
        public ActionResult MaterialTypeList(string reportId, string Params)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("MaterialTypeList",
                    new
                    {
                        reportId = "Qx.Jzxt.材料类型",
                        Params = ";",
                        pageIndex = 1,
                        perCount = 10
                    });
            }
            Search.Add("类型名称");
            InitReport("材料类型列表", "/QxJzxt/CRUD/AddMaterialType", "", true, "ecampus.jzxt");
            return ReportView();
        }
        #endregion

        #region QxJzxt/AutoReport/MaterialTypeAttrsList 材料类型属性
        public ActionResult MaterialTypeAttrsList(string reportId, string Params)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("MaterialTypeAttrsList",
                    new
                    {
                        reportId = "Qx.Jzxt.材料类型属性",
                        Params = Params.IsFixedParam(),
                        pageIndex = 1,
                        perCount = 10
                    });
            }
            Search.Add("类型名称");
            InitReport("材料类型属性列表", "/QxJzxt/AutoReport/MaterialAttrsList", "", true, "ecampus.jzxt");
            return ReportView();
        }
        #endregion

        #region QxJzxt/AutoReport/MaterialAttrsList 材料属性
        public ActionResult MaterialAttrsList(string reportId, string Params)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("MaterialAttrsList",
                    new
                    {
                        reportId = "Qx.Jzxt.材料属性",
                        Params = ";",
                        pageIndex = 1,
                        perCount = 10
                    });
            }
            Search.Add("属性名称");
            InitReport("材料属性列表", "/QxJzxt/CRUD/AddMaterialAttrs", "", true, "ecampus.jzxt");
            return ReportView();
        }
        #endregion

        #region  QxJzxt/AutoReport/AwardApplyList 奖项申请列表
        public ActionResult AwardApplyList(string reportId, string Params)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("AwardApplyList",
                    new
                    {
                        reportId = "Qx.Jzxt.奖项申请列表",
                        Params = ";",
                        pageIndex = 1,
                        perCount = 10
                    });
            }
            Search.Add("申请人");
            Search.Add("申请奖项");
            InitReport("奖项申请列表", "#", "", true, "ecampus.jzxt");
            return ReportView();
        }
        #endregion

        #region QxJzxt/AutoReport/AwardBaseInfoList 奖项基本信息
        public ActionResult AwardBaseInfoList(string reportId, string Params)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("AwardBaseInfoList",
                    new
                    {
                        reportId = "Qx.Jzxt.奖项基本信息",
                        Params = Params.IsFixedParam(),
                        pageIndex = 1,
                        perCount = 10
                    });
            }
            Search.Add("信息名称");
            InitReport("奖项基本信息列表", "/QxJzxt/CRUD/AddBaseInfoToAward?awardtypeid=" + Params, "", true, "ecampus.jzxt");
            return ReportView();
        }
        #endregion

        #region  QxJzxt/AutoReport/AwardMaterialList 奖项所需材料
        public ActionResult AwardMaterialList(string reportId, string Params)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("AwardMaterialList",
                    new
                    {
                        reportId = "Qx.Jzxt.奖项所需材料",
                        Params = Params.IsFixedParam(),
                        pageIndex = 1,
                        perCount = 10
                    });
            }
            Search.Add("材料名称");
            InitReport("奖项材料列表", "/QxJzxt/AutoReport/MaterialTypeList", "", true, "ecampus.jzxt");
            return ReportView();
        }
        #endregion

        #region QxJzxt/AutoReport/AwardInstanceList 奖项实例列表
        public ActionResult AwardInstanceList(string reportId, string Params)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("AwardInstanceList",
                    new
                    {
                        reportId = "Qx.Jzxt.奖项实例",
                        Params = ";",
                        pageIndex = 1,
                        perCount = 10
                    });
            }
            Search.Add("奖项种类");
            Search.Add("实施奖项");
            //InitReport("实施奖项列表", "/QxJzxt/CRUD/AddAwardInstance?awardtypeId="+"", "", true, "ecampus.jzxt");
            InitReport("实施奖项列表", "#", "", true, "ecampus.jzxt");
            return ReportView();
        }
        #endregion

        #region QxJzxt/AutoReport/BatchAwardInstanceList 批次奖项实例列表
        public ActionResult BatchAwardInstanceList(string reportId, string Params)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("BatchAwardInstanceList",
                    new
                    {
                        reportId = "Qx.Jzxt.批次奖项实例",
                        Params = Params.IsFixedParam(),
                        pageIndex = 1,
                        perCount = 10
                    });
            }
            Search.Add("奖项类型");
            Search.Add("实施奖项");
            InitReport("批次奖项实例列表", "/QxJzxt/CRUD/AddAwardInstanceFromBatch?id=" + Params, "", true, "ecampus.jzxt");
            return ReportView();
        }
        #endregion

        #region QxJzxt/AutoReport/AwardInstanceBaseInfoList 奖项实例基本信息列表
        public ActionResult AwardInstanceBaseInfoList(string reportId, string Params)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("AwardInstanceBaseInfoList",
                    new
                    {
                        reportId = "Qx.Jzxt.奖项实例基本信息",
                        Params = Params.IsFixedParam(),
                        pageIndex = 1,
                        perCount = 10
                    });
            }
            Search.Add("信息名称");
            InitReport("实施奖项基本信息列表", "/QxJzxt/CRUD/AddAwardInstanceBaseInfo?id=" + Params, "", true, "ecampus.jzxt");
            return ReportView();
        }
        #endregion

        #region QxJzxt/AutoReport/AwardInstanceMaterialList 奖项实例材料列表
        public ActionResult AwardInstanceMaterialList(string reportId, string Params)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("AwardInstanceMaterialList",
                    new
                    {
                        reportId = "Qx.Jzxt.奖项实例材料",
                        Params = Params.IsFixedParam(),
                        pageIndex = 1,
                        perCount = 10
                    });
            }
            Search.Add("材料名称");
            InitReport("奖项实例材料列表", "/QxJzxt/CRUD/AddMaterialToAwardInstance?id=" + Params, "", true, "ecampus.jzxt");
            return ReportView();
        }
        #endregion

        #region QxJzxt/AutoReport/MyMaterialApplyList 用户材料列表
        public ActionResult MyMaterialApplyList(string reportId, string Params)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("MyMaterialApplyList",
                    new
                    {
                        reportId = "Qx.Jzxt.用户材料列表",
                        Params = DataContext.UserID.IsFixedParam() + ";,;", // Params.IsFixedParam(),
                        pageIndex = 1,
                        perCount = 10
                    });
            }
            Search.Add("状态", _qxIJzxtService.MaterialApplyStatus());
            Search.Add("材料类型", _qxIJzxtService.SearchMaterialTypeSelect());
            InitReport("用户材料列表", "/QxJzxt/AutoReport/MyMaterialApplyTypeList", "", true, "ecampus.jzxt");
            return ReportView();
        }
        #endregion

        #region QxJzxt/AutoReport/MyMaterialApplyTypeList 用户的材料类型列表
        public ActionResult MyMaterialApplyTypeList(string reportId, string Params)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("MyMaterialApplyTypeList",
                    new
                    {
                        reportId = "Qx.Jzxt.用户的材料类型列表",
                        Params = "", // Params.IsFixedParam(),
                        pageIndex = 1,
                        perCount = 10
                    });
            }
            InitReport("用户材料列表", "#", "", true, "ecampus.jzxt");
            return ReportView();
        }
        #endregion

        #region QxJzxt/AutoReport/MyAwardApplyList 用户奖项申请列表
        public ActionResult MyAwardApplyList(string reportId, string Params)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("MyAwardApplyList",
                    new
                    {
                        reportId = "Qx.Jzxt.用户奖项申请列表",
                        Params = DataContext.UserID.IsFixedParam() + ";;;", // Params.IsFixedParam(),
                        pageIndex = 1,
                        perCount = 10
                    });
            }
            //  OverWriteParam(Params+DataContext.UserID);
            Search.Add("批次名称");
            Search.Add("奖项类型");
            Search.Add("状态", _qxIJzxtService.AwardApplyStatus());
            InitReport("奖项申请列表", "/QxJzxt/AutoReport/CanApplyAwardList", "", true, "ecampus.jzxt");
            return ReportView();
        }
        #endregion

        #region QxJzxt/AutoReport/CanApplyAwardList 用户可申请奖项列表
        public ActionResult CanApplyAwardList(string reportId, string Params)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("CanApplyAwardList",
                    new
                    {
                        reportId = "Qx.Jzxt.用户可申请奖项列表",
                        Params = ";", // Params.IsFixedParam(),
                        pageIndex = 1,
                        perCount = 10
                    });
            }
            //  OverWriteParam(Params+DataContext.UserID);
            Search.Add("批次名称");
            Search.Add("奖项类型");
            Search.Add("实施奖项");
            InitReport("奖项申请列表", "#", "", true, "ecampus.jzxt");
            return ReportView();
        }
        #endregion

        #region QxJzxt/AutoReport/OrgList 组织机构列表
        public ActionResult OrgList(string reportId, string Params)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("OrgList",
                    new
                    {
                        reportId = "Qx.Jzxt.学院机构列表",
                        Params = ";", // Params.IsFixedParam(),
                        pageIndex = 1,
                        perCount = 10
                    });
            }
            //OverWriteParam(Params+DataContext.UserID);
            Search.Add("学院名称");
            //Search.Add("奖项类型");
            //Search.Add("实施奖项");
            InitReport("学院列表", "/QxJzxt/CRUD/AddOrg", "", true, "ecampus.jzxt");
            return ReportView();
        }
        #endregion

        #region QxJzxt/AutoReport/OrgAwardInstanceList 学院分配奖项列表（管理员可以管理）
        public ActionResult OrgAwardInstanceList(string reportId, string Params)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("OrgAwardInstanceList",
                    new
                    {
                        reportId = "Qx.Jzxt.学院奖项实例列表",
                        Params = Params.IsFixedParam(), // Params.IsFixedParam(),
                        pageIndex = 1,
                        perCount = 10
                    });
            }

            // OverWriteParam(Params+DataContext.UserID);

            Search.Add("批次名称");
            Search.Add("奖项名称");
            //Search.Add("实施奖项");
            InitReport("奖项申请列表", "#", "", true, "ecampus.jzxt");
            return ReportView();
        }
        #endregion

        #region QxJzxt/AutoReport/CollegeAwardInstanceList 每个学院所分配奖项列表
        ///（每个学院只能看当前的学院的）.现在来说只能看计算机学院的，组织机构那一块的还没完善，为了数据演示，救急
        public ActionResult CollegeDistributionAwardList(string reportId, string Params)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("CollegeDistributionAwardList",
                    new
                    {
                        reportId = "Qx.Jzxt.学院所分配奖项列表", //报表只能看计算机学院的，救急，演示过了再改
                        Params = ";",
                        pageIndex = 1,
                        perCount = 10
                    });
            }
            //  OverWriteParam(Params+DataContext.UserID);
            Search.Add("批次名称");
            Search.Add("奖项名称");
            //Search.Add("实施奖项");
            InitReport("学院分配奖项列表", "#", "", true, "ecampus.jzxt");
            return ReportView();
        }
        #endregion

        #region QxJzxt/AutoReport/CollegeMaterialExamineList 学院材料审核
        public ActionResult CollegeMaterialExamineList(string reportId, string Params)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("CollegeMaterialExamineList",
                    new
                    {
                        reportId = "Qx.Jzxt.学院材料审核",
                        Params = ";;;;", // Params.IsFixedParam(),
                        pageIndex = 1,
                        perCount = 10
                    });
            }
            //  OverWriteParam(Params+DataContext.UserID);
            Search.Add("用户ID");
            Search.Add("姓名");
            Search.Add("材料类型", _qxIJzxtService.SearchMaterialTypeSelect());
            Search.Add("状态", _qxIJzxtService.SearchCollegeMaterialSelect());
            InitReport("学院材料审核列表", "/QxJzxt/CRUD/AddOrg", "", true, "ecampus.jzxt");
            return ReportView();
        }
        #endregion

        #region QxJzxt/AutoReport/CollegeAwardExamineList 学院奖项审核
        public ActionResult CollegeAwardExamineList(string reportId, string Params)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("CollegeAwardExamineList",
                    new
                    {
                        reportId = "Qx.Jzxt.学院奖项审核",
                        Params = ";;;;;", // Params.IsFixedParam(),
                        pageIndex = 1,
                        perCount = 10
                    });
            }
            // OverWriteParam(Params+DataContext.UserID);
            Search.Add("用户ID");
            Search.Add("姓名");
            Search.Add("批次名称", _qxIJzxtService.SearchBatchSelect());
            Search.Add("奖项名称");
            Search.Add("奖项类型", _qxIJzxtService.SearchAwardTypeSelect());
            Search.Add("状态", _qxIJzxtService.SearchCollegeAwardSelect());
            InitReport("学院奖项审核列表", "#", "", true, "ecampus.jzxt");
            return ReportView();
        }
        #endregion

        #region QxJzxt/AutoReport/SchoolAwardExamineList 学校奖项审核
        public ActionResult SchoolAwardExamineList(string reportId, string Params)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("SchoolAwardExamineList",
                    new
                    {
                        reportId = "Qx.Jzxt.学校奖项审核",
                        Params = ";;;;;", // Params.IsFixedParam(),
                        pageIndex = 1,
                        perCount = 10
                    });
            }
            //  OverWriteParam(Params+DataContext.UserID);
            Search.Add("用户ID");
            Search.Add("姓名");
            Search.Add("批次名称", _qxIJzxtService.SearchBatchSelect());
            Search.Add("奖项名称");
            Search.Add("奖项类型", _qxIJzxtService.SearchAwardTypeSelect());
            Search.Add("状态", _qxIJzxtService.SearchSchoolAwardSelect());
            InitReport("学院奖项审核列表", "#", "", true, "ecampus.jzxt");
            return ReportView();
        }
        #endregion

        #region QxJzxt/AutoReport/UserChildOrg 该用户下面的第一级子机构，（针对学院一级的管理员） 审核资料
        ///比如说该用户是计算机学院的管理员，计算机学院下面还有软件工程系，数字媒体系...那么这里出现的列表就是软件工程系，数字媒体系
        public ActionResult UserChildOrgMaterial(string reportId, string Params)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("UserChildOrgMaterial",
                    new
                    {
                        reportId = "Qx.Jzxt.用户所在机构的子机构",
                        Params = DataContext.UserID.IsFixedParam(), // Params.IsFixedParam(),
                        pageIndex = 1,
                        perCount = 10
                    });
            }
            Search.Add("机构名称");
            InitReport("学院奖项审核列表", "#", "", true, "ecampus.jzxt");
            return ReportView();
        }
        #endregion

        #region  QxJzxt/AutoReport/ChildOrg_CommonMaterial  公共的组织机构列表  (子组织机构) 审核资料
        ///这里跟orgcontroller的Org_Common不太一样，只是针对学院管理员才能看见的
        ///这里出现的是软件工程系，数字媒体系下面的一级，如果还有下级，那么都是调用同样的方法
        public ActionResult ChildOrg_CommonMaterial(string ReportID, string Params)
        {
            if (!ReportID.HasValue())
            {
                return RedirectToAction("ChildOrg_CommonMaterial",
                    new
                    {
                        ReportID = "Qx.Jzxt.用户所在机构的子机构的子机构",
                        //father_id = father_id,
                        //orgnization_id = orgnization_id,
                        Params = Params.IsFixedParam(),
                        pageIndex = 1,
                        perCount = 10
                    });
            }
            Search.Add("机构名称");
            InitReport("组织机构列表", "#", "", true, "ecampus.jzxt");
            return ReportView();
        }
        #endregion

        #region QxJzxt/AutoReport/UserMaterialRecordList 材料统计记录(学院)
        public ActionResult UserMaterialRecordList(string reportId, string Params)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("UserMaterialRecordList",
                    new
                    {
                        reportId = "Qx.Jzxt.材料统计记录",
                        Params = Params.IsFixedParam(), // Params.IsFixedParam(),
                        pageIndex = 1,
                        perCount = 10
                    });
            }
            var index = Params.IndexOf('!');
            var orgnization_id = Params.Substring(0, index);
            InitReport("材料统计记录", "#", "orgnization_id=" + orgnization_id, true, "ecampus.jzxt");
            return ReportView();
        }
        #endregion

        #region QxJzxt/AutoReport/UserMaterialPassList 根据材料类型审核学生申请列表  审核通过(学院)
        public ActionResult UserMaterialPassList(string reportId, string Params, string materialtypeid,
            string orgnization_id)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("UserMaterialPassList",
                    new
                    {
                        reportId = "Qx.Jzxt.学生材料申请通过列表",
                        Params = ";;", // Params.IsFixedParam(),
                        materialtypeid = materialtypeid,
                        orgnization_id = orgnization_id,
                        pageIndex = 1,
                        perCount = 10
                    });
            }
            SetFixedParam(materialtypeid + ";" + orgnization_id, ";");
            Search.Add("学号");
            Search.Add("姓名");
            InitReport("审核通过列表", "#", "", true, "ecampus.jzxt");
            return ReportView();
        }
        #endregion

        #region QxJzxt/AutoReport/UserMaterialNoPassList 根据材料类型审核学生申请列表   审核不通过(学院)
        public ActionResult UserMaterialNoPassList(string reportId, string Params, string materialtypeid,
            string orgnization_id)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("UserMaterialNoPassList",
                    new
                    {
                        reportId = "Qx.Jzxt.学生材料申请不通过列表",
                        Params = ";;", // Params.IsFixedParam(),
                        materialtypeid = materialtypeid,
                        orgnization_id = orgnization_id,
                        pageIndex = 1,
                        perCount = 10
                    });
            }
            SetFixedParam(materialtypeid + ";" + orgnization_id, ";");
            Search.Add("学号");
            Search.Add("姓名");
            InitReport("审核不通过列表", "#", "", true, "ecampus.jzxt");
            return ReportView();
        }
        #endregion

        #region QxJzxt/AutoReport/UserMaterialPendingList 根据材料类型审核学生申请列表   待审核(学院)
        public ActionResult UserMaterialPendingList(string reportId, string Params, string materialtypeid,
            string orgnization_id)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("UserMaterialPendingList",
                    new
                    {
                        reportId = "Qx.Jzxt.学生材料申请待审核列表",
                        Params = ";;", // Params.IsFixedParam(),
                        materialtypeid = materialtypeid,
                        orgnization_id = orgnization_id,
                        pageIndex = 1,
                        perCount = 10
                    });
            }
            SetFixedParam(materialtypeid + ";" + orgnization_id, ";");
            Search.Add("学号");
            Search.Add("姓名");
            InitReport("待审核列表", "#", "", true, "ecampus.jzxt");
            return ReportView();
        }
        #endregion

        #region QxJzxt/AutoReport/AwardExamineBatchList 审核奖项批次列表
        //（其实跟上面的“批次”是一样的）只是操作列不一样
        public ActionResult AwardExamineBatchList(string reportId, string Params)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("AwardExamineBatchList",
                    new
                    {
                        reportId = "Qx.Jzxt.奖项审核批次",
                        Params = ";",
                        pageIndex = 1,
                        perCount = 10
                    });
            }
            Search.Add("批次名称");
            InitReport("审核奖项批次列表", "#", "", true, "ecampus.jzxt");
            return ReportView();
        }
        #endregion

        #region QxJzxt/AutoReport/AwardExamineInstanceList 审核奖项实例列表 (该学院所分配到的奖项)
        //（其实跟上面的“批次实例”是一样的）只是操作列不一样
        public ActionResult AwardExamineInstanceList(string reportId, string Params,string batchid)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("AwardExamineInstanceList",
                    new
                    {
                        reportId = "Qx.Jzxt.审核奖项实例列表",
                        Params = ";;",
                        batchid= batchid,
                        pageIndex = 1,
                        perCount = 10
                    });
            }
            SetFixedParam(batchid + ";"+DataContext.UserID,";");
            Search.Add("实施名称");
            Search.Add("奖项类型");
            InitReport("审核奖项实例列表", "#", "", true, "ecampus.jzxt");
            return ReportView();
        }
        #endregion

        #region QxJzxt/AutoReport/UserChildOrgAward 该用户下面的第一级子机构，（针对学院一级的管理员） 审核奖项
        ///比如说该用户是计算机学院的管理员，计算机学院下面还有软件工程系，数字媒体系...那么这里出现的列表就是软件工程系，数字媒体系
        public ActionResult UserChildOrgAward(string reportId, string Params,string batchid)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("UserChildOrgAward",
                    new
                    {
                        reportId = "Qx.Jzxt.用户所在机构的子机构_奖项审核",
                        Params = DataContext.UserID.IsFixedParam(), // Params.IsFixedParam(),
                        batchid= batchid,
                        pageIndex = 1,
                        perCount = 10
                    });
            }
            Search.Add("机构名称");
            InitReport("学院奖项审核列表", "#", "batchid="+ batchid , true, "ecampus.jzxt");
            return ReportView();
        }
        #endregion

        #region  QxJzxt/AutoReport/ChildOrg_CommonAward  公共的组织机构列表  (子组织机构) 审核奖项
        ///这里跟orgcontroller的Org_Common不太一样，只是针对学院管理员才能看见的
        ///这里出现的是软件工程系，数字媒体系下面的一级，如果还有下级，那么都是调用同样的方法
        public ActionResult ChildOrg_CommonAward(string ReportID, string Params,string batchid)
        {
            if (!ReportID.HasValue())
            {
                return RedirectToAction("ChildOrg_CommonAward",
                    new
                    {
                        ReportID = "Qx.Jzxt.用户所在机构的子机构的子机构_奖项审核",
                        //father_id = father_id,
                        //orgnization_id = orgnization_id,
                        Params = Params.IsFixedParam(),
                        batchid= batchid,
                        pageIndex = 1,
                        perCount = 10
                    });
            }
            Search.Add("机构名称");
            InitReport("组织机构列表", "#", "batchid=" + batchid, true, "ecampus.jzxt");
            return ReportView();
        }
        #endregion

        #region QxJzxt/AutoReport/UserAwardApplyRecordList 用户奖项申请统计记录(学院)
        public ActionResult UserAwardApplyRecordList(string reportId, string Params,string orgnization_id,string batchid)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("UserAwardApplyRecordList",
                    new
                    {
                        reportId = "Qx.Jzxt.用户奖项申请统计记录_学院",
                        orgnization_id= orgnization_id,
                        batchid= batchid,
                        Params = ";", // Params.IsFixedParam(),
                        pageIndex = 1,
                        perCount = 10
                    });
            }
            SetFixedParam(orgnization_id + ";" + batchid,";");
            Search.Add("奖项名称");
            InitReport("奖项申请统计记录", "","orgnization_id="+ orgnization_id, true, "ecampus.jzxt");
            return ReportView();
        }
        #endregion

        #region QxJzxt/AutoReport/UserAwardApplyCollegePendingList 根据奖项审核学生申请列表  待审核(学院)
        public ActionResult UserAwardApplyCollegePendingList(string reportId, string Params, string instanceid, string orgnization_id)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("UserAwardApplyCollegePendingList",
                    new
                    {
                        reportId = "Qx.Jzxt.用户奖项申请_学院待审核列表",
                        Params = ";;", // Params.IsFixedParam(),
                        instanceid = instanceid,
                        orgnization_id = orgnization_id,
                        pageIndex = 1,
                        perCount = 10
                    });
            }
            SetFixedParam(instanceid + ";" + orgnization_id, ";");
            Search.Add("学号");
            Search.Add("姓名");
            InitReport("审核通过列表", "#", "", true, "ecampus.jzxt");
            return ReportView();
        }
        #endregion

        #region QxJzxt/AutoReport/UserAwardApplyCollegePassList 根据奖项审核学生申请列表  审核通过(学院)
        public ActionResult UserAwardApplyCollegePassList(string reportId, string Params, string instanceid, string orgnization_id)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("UserAwardApplyCollegePassList",
                    new
                    {
                        reportId = "Qx.Jzxt.用户奖项申请_学院通过列表",
                        Params = ";;", // Params.IsFixedParam(),
                        instanceid = instanceid,
                        orgnization_id = orgnization_id,
                        pageIndex = 1,
                        perCount = 10
                    });
            }
            SetFixedParam(instanceid + ";" + orgnization_id, ";");
            Search.Add("学号");
            Search.Add("姓名");
            InitReport("审核通过列表", "#", "", true, "ecampus.jzxt");
            return ReportView();
        }
        #endregion

        #region QxJzxt/AutoReport/UserAwardApplyCollegeNoPassList 根据奖项审核学生申请列表  审核不通过(学院)
        public ActionResult UserAwardApplyCollegeNoPassList(string reportId, string Params, string instanceid, string orgnization_id)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("UserAwardApplyCollegeNoPassList",
                    new
                    {
                        reportId = "Qx.Jzxt.用户奖项申请_学院不通过列表",
                        Params = ";;", // Params.IsFixedParam(),
                        instanceid = instanceid,
                        orgnization_id = orgnization_id,
                        pageIndex = 1,
                        perCount = 10
                    });
            }
            SetFixedParam(instanceid + ";" + orgnization_id, ";");
            Search.Add("学号");
            Search.Add("姓名");
            InitReport("审核通过列表", "#", "", true, "ecampus.jzxt");
            return ReportView();
        }
        #endregion
        
        #region QxJzxt/AutoReport/UserAwardApplySchoolPendingList 根据奖项审核学生申请列表  待审核(学校)
        public ActionResult UserAwardApplySchoolPendingList(string reportId, string Params, string instanceid, string orgnization_id)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("UserAwardApplyCollegePendingList",
                    new
                    {
                        reportId = "Qx.Jzxt.用户奖项申请_学校待审核列表",
                        Params = ";;", // Params.IsFixedParam(),
                        instanceid = instanceid,
                        orgnization_id = orgnization_id,
                        pageIndex = 1,
                        perCount = 10
                    });
            }
            SetFixedParam(instanceid + ";" + orgnization_id, ";");
            Search.Add("学号");
            Search.Add("姓名");
            InitReport("审核通过列表", "#", "", true, "ecampus.jzxt");
            return ReportView();
        }
        #endregion

        #region QxJzxt/AutoReport/UserAwardApplySchoolPassList 根据奖项审核学生申请列表  审核通过(学校)
        public ActionResult UserAwardApplySchoolPassList(string reportId, string Params, string instanceid, string orgnization_id)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("UserAwardApplyCollegePassList",
                    new
                    {
                        reportId = "Qx.Jzxt.用户奖项申请_学校通过列表",
                        Params = ";;", // Params.IsFixedParam(),
                        instanceid = instanceid,
                        orgnization_id = orgnization_id,
                        pageIndex = 1,
                        perCount = 10
                    });
            }
            SetFixedParam(instanceid + ";" + orgnization_id, ";");
            Search.Add("学号");
            Search.Add("姓名");
            InitReport("审核通过列表", "#", "", true, "ecampus.jzxt");
            return ReportView();
        }
        #endregion

        #region QxJzxt/AutoReport/UserAwardApplySchoolNoPassList 根据奖项审核学生申请列表  审核不通过(学校)
        public ActionResult UserAwardApplySchoolNoPassList(string reportId, string Params, string instanceid, string orgnization_id)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("UserAwardApplyCollegeNoPassList",
                    new
                    {
                        reportId = "Qx.Jzxt.用户奖项申请_学校不通过列表",
                        Params = ";;", // Params.IsFixedParam(),
                        instanceid = instanceid,
                        orgnization_id = orgnization_id,
                        pageIndex = 1,
                        perCount = 10
                    });
            }
            SetFixedParam(instanceid + ";" + orgnization_id, ";");
            Search.Add("学号");
            Search.Add("姓名");
            InitReport("审核通过列表", "#", "", true, "ecampus.jzxt");
            return ReportView();
        }
        #endregion


    }
}