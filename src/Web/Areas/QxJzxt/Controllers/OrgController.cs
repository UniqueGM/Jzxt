using Qx.Tools.CommonExtendMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Qx.Tools.Models;

namespace Web.Areas.QxJzxt.Controllers
{
    public class OrgController : BaseQxJzxtController
    {
        // GET: QxJzxt/Org
        public ActionResult Index()
        {
            return View();
        }
        //   QxJzxt/Org/OrgnizationList   组织机构根目录列表，虚拟根ROOT
        public ActionResult OrgnizationList(string ReportID, string Params)
        {
            if (!ReportID.HasValue())
            {
                return RedirectToAction("OrgnizationList", 
                    new
                    {
                        ReportID = "ecampus.QxJzxt.组织机构列表",
                        Params = ";",
                        pageIndex = 1,
                        perCount = 10
                    });
            }
            Search.Add("机构名称");
            InitReport("奖项类型列表", "#", "", true, "ecampus.jzxt");
       //     InitReport("组织机构列表", "#");//CRUD 添加班级 ?url=/Yxxt/CRUD/YX_LinkListAdd?
            return ReportView();
        }
        
        //   QxJzxt/Org/RootChild   一级组织机构列表
        public ActionResult RootChild(string ReportID, string father_id, string orgnization_id, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!ReportID.HasValue())
            {
                return RedirectToAction("RootChild", 
                    new
                    {
                        father_id = father_id,
                        orgnization_id = orgnization_id,
                        ReportID = "ecampus.Twxt.ROOTChild",
                        Params = ";",
                        pageIndex = 1,
                        perCount = 10
                    });
            }
            Search.Add("组织机构名称");
           // SetFixedParam(orgnization_id, ";");
            InitReport("组织机构列表", "/QxJzxt/OrgCRUD/LevelOneAdd?father_id=" + orgnization_id);
            return ReportView();
        }
        public ActionResult LevelTwo(string ReportID, string father_id, string orgnization_id, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!ReportID.HasValue())
            {
                return RedirectToAction("LevelTwo", new { father_id = father_id, orgnization_id = orgnization_id, ReportID = "ecampus.Twxt.LevelTwo", Params = ";", pageIndex = 1, perCount = 10 });
            }
            Search.Add("组织机构名称");
            SetFixedParam(orgnization_id, ";");
            InitReport("组织机构列表", "/QxJzxt/OrgCRUD/LevelTwoAdd?father_id=" + orgnization_id);
            return ReportView();
        }
        public ActionResult LevelThree(string ReportID, string father_id, string orgnization_id, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!ReportID.HasValue())
            {
                return RedirectToAction("LevelThree", new { ReportID = "ecampus.Twxt.LevelThree", father_id = father_id, orgnization_id = orgnization_id, Params = ";", pageIndex = 1, perCount = 10 });
            }
            Search.Add("组织机构名称");
            SetFixedParam(orgnization_id, ";");
            InitReport("组织机构列表", "/QxJzxt/OrgCRUD/LevelThreeAdd?father_id=" + orgnization_id);
            return ReportView();
        }
  
           
        #region 公共添加组织机构的方法
        //  QxJzxt/Org/Org_Common  公共的组织机构列表   
        public ActionResult Org_Common(string ReportID, string Params)
        {
            if (!ReportID.HasValue())
            {
                return RedirectToAction("Org_Common", 
                    new
                    {
                        ReportID = "Qx.Jzxt.Org_Common",
                        //father_id = father_id,
                        //orgnization_id = orgnization_id,
                        Params = Params.IsFixedParam(),
                        pageIndex = 1,
                        perCount = 10
                    });
            }
            Search.Add("组织机构名称");
            InitReport("组织机构列表", "/QxJzxt/OrgCRUD/Org_CommonAdd?father_id="+ Params, "", true, "ecampus.jzxt");
            return ReportView();
        }
        #endregion



        #region 处于该位置的人能看到的子组织机构
        public ActionResult Org_WatchChild(string ReportID, string orgnization_id, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!ReportID.HasValue())
            {
                return RedirectToAction("Org_WatchChild", new { ReportID = "ecampus.Twxt.Org_该角色能看到的子机构", orgnization_id = orgnization_id, Params = ";", pageIndex = 1, perCount = 10 });
            }
            Search.Add("组织机构名称");
            SetFixedParam(orgnization_id, ";");
            InitReport("组织机构列表", "/QxJzxt/OrgCRUD/Org_CommonAdd?father_id=" + orgnization_id);
            return ReportView();
        }
        #endregion

        //QxJzxt/Org/Relation_Org 相关联的组织机构
        public ActionResult Relation_Org(string ReportID, string orgnization_id, string Params)
        {
            if (!ReportID.HasValue())
            {
                return RedirectToAction("Relation_Org", 
                    new {
                        orgnization_id = orgnization_id,
                        ReportID = "Qx.Jzxt.相关联组织机构",
                        Params = ";",
                        pageIndex = 1,
                        perCount = 10
                    });
            }
            Search.Add("组织机构名称");
            SetFixedParam(orgnization_id, ";");
            InitReport("组织机构列表", "/QxJzxt/Org/Relation_OrgChoose?orgnization_id=" + orgnization_id);
            return ReportView();
        }
        //组织机构职位对应的人（待定）
        public ActionResult Relation_Org_User(string ReportID, string orgnization_position_id, string position_id, string Params)
        {
            if (!ReportID.HasValue())
            {
                return RedirectToAction("Relation_Org_User",
                    new
                    {
                        ReportID = "ecampus.Twxt.职位对应的职员",
                        orgnization_position_id = orgnization_position_id,
                        position_id = position_id,
                        Params = ";",
                        pageIndex = 1,
                        perCount = 10
                    });
            }
            Search.Add("姓名");
            SetFixedParam(position_id, ";");
            InitReport("组织机构职员", "/Twxt/Org/Relation_Org_UserChoose?orgnization_position_id=" + orgnization_position_id);
            return ReportView();
        }
        public ActionResult Relation_Org_UserChoose(string ReportID, string orgnization_position_id, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!ReportID.HasValue())
            {
                return RedirectToAction("Relation_Org_UserChoose", new { ReportID = "ecampus.Twxt.职位对应的职员_选择", orgnization_position_id = orgnization_position_id, Params = ";", pageIndex = 1, perCount = 10 });
            }
            Search.Add("姓名");
            InitReport("组织机构职员", "#", true, orgnization_position_id);
            return ReportView();
        }
        //----------------------------------------------- 
        public ActionResult Relation_OrgChoose(string ReportID, string Params, string orgnization_id)
        {
            if (!ReportID.HasValue())
            {
                return RedirectToAction("Relation_OrgChoose", 
                    new {
                        orgnization_id = orgnization_id,
                        ReportID = "Qx.Jzxt.关联的组织机构选择",
                        Params = ";",
                        pageIndex = 1,
                        perCount = 10
                    });
            }
            // InitReport("思想汇报（积极分子）", "#", "", true, "ecampus.join_party");//#添加按钮的路由，“”额外参数，TRUE查询按钮显示，“”
            Search.Add("关联的组织机构名称");
            InitReport("选择关联组织机构", "#", true, orgnization_id);
            return ReportView();
        }
        public ActionResult Org_Position(string ReportID, string Params)
        {
            if (!ReportID.HasValue())
            {
                return RedirectToAction("Org_Position", 
                    new
                    {
                        ReportID = "Qx.Jzxt.组织机构对应的职位",
                        Params = Params.IsFixedParam(),
                        pageIndex = 1,
                        perCount = 10
                    });
            }
            Search.Add("职位名称");
            InitReport("组织机构职位", "/QxJzxt/OrgCRUD/Add_Org_Position?orgid=" + Params);//CRUD 添加班级 ?url=/Yxxt/CRUD/YX_LinkListAdd?
            return ReportView();
        }
        public ActionResult Org_Position_Choose(string orgnization_id, string ReportID, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!ReportID.HasValue())
            {
                return RedirectToAction("Org_Position_Choose", 
                    new
                    {
                        orgnization_id = orgnization_id,
                        ReportID = "ecampus.Twxt.添加组织机构职位",
                        Params = ";",
                        pageIndex = 1,
                        perCount = 10
                    });
            }
            // InitReport("思想汇报（积极分子）", "#", "", true, "ecampus.join_party");//#添加按钮的路由，“”额外参数，TRUE查询按钮显示，“”
            Search.Add("职位名称");
            InitReport("添加组织机构职位", "#", true, orgnization_id);
            return ReportView();
        }
        public ActionResult Org_TypeChoose(string ReportID, string Params, string url, int pageIndex = 1, int perCount = 10)
        {
            if (!ReportID.HasValue())
            {
                return RedirectToAction("Org_TypeChoose", new { url = url, ReportID = "ecampus.Twxt.组织机构类型选择", Params = ";", pageIndex = 1, perCount = 10 });
            }
            // InitReport("思想汇报（积极分子）", "#", "", true, "ecampus.join_party");//#添加按钮的路由，“”额外参数，TRUE查询按钮显示，“”
            Search.Add("组织机构类型名称");
            InitReport("组织机构类型选择", "#", true, url);
            return ReportView();
        }
        //public ActionResult Org_TypeChoose_Common(string ReportID, string Params, string url, int pageIndex = 1, int perCount = 10)
        //{
        //    if (!ReportID.HasValue())
        //    {
        //        return RedirectToAction("Org_TypeChoose_Common", new { url = url, ReportID = "ecampus.Twxt.组织机构类型选择_公共", Params = ";", pageIndex = 1, perCount = 10 });
        //    }
        //    // InitReport("思想汇报（积极分子）", "#", "", true, "ecampus.join_party");//#添加按钮的路由，“”额外参数，TRUE查询按钮显示，“”
        //    Search.Add("组织机构类型名称");
        //    InitReport("组织机构类型选择", "#", true, url);
        //    return ReportView();
        //}
        public ActionResult Org_TypeChoose_Common(string ReportID, string Params, string AllParams, int pageIndex = 1, int perCount = 10)
        {
            if (!ReportID.HasValue())
            {
                return RedirectToAction("Org_TypeChoose_Common", new { AllParams = AllParams, ReportID = "ecampus.Twxt.组织机构类型选择_公共", Params = ";", pageIndex = 1, perCount = 10 });
            }
            // InitReport("思想汇报（积极分子）", "#", "", true, "ecampus.join_party");//#添加按钮的路由，“”额外参数，TRUE查询按钮显示，“”
            Search.Add("组织机构类型名称");
            InitReport("组织机构类型选择", "#", true, AllParams);
            return ReportView();
        }
        public ActionResult Org_FatherChoose(string ReportID, string Params, string AllParams, int pageIndex = 1, int perCount = 10)
        {
            if (!ReportID.HasValue())
            {
                return RedirectToAction("Org_FatherChoose", new { AllParams = AllParams, ReportID = "ecampus.Twxt.选择父组织机构", Params = ";", pageIndex = 1, perCount = 10 });
            }
            // InitReport("思想汇报（积极分子）", "#", "", true, "ecampus.join_party");//#添加按钮的路由，“”额外参数，TRUE查询按钮显示，“”
            Search.Add("父组织机构名称");
            InitReport("选择父组织机构", "#", true, AllParams);
            return ReportView();
        }
        public ActionResult Org_TypeChoose_OneToALL(string ReportID, string Params, string AllParams, int pageIndex = 1, int perCount = 10)
        {
            if (!ReportID.HasValue())
            {
                return RedirectToAction("Org_TypeChoose_OneToALL", new { AllParams = AllParams, ReportID = "ecampus.Twxt.组织机构类型选择_非根节点使用", Params = ";", pageIndex = 1, perCount = 10 });
            }
            // InitReport("思想汇报（积极分子）", "#", "", true, "ecampus.join_party");//#添加按钮的路由，“”额外参数，TRUE查询按钮显示，“”
            Search.Add("组织机构类型名称");
            InitReport("组织机构类型选择", "#", true, AllParams);
            return ReportView();
        }
        public ActionResult Org_TypeChoose_OneEdit(string ReportID, string Params, string orgnization_id, int pageIndex = 1, int perCount = 10)
        {
            if (!ReportID.HasValue())
            {
                return RedirectToAction("Org_TypeChoose_OneEdit", new { orgnization_id = orgnization_id, ReportID = "ecampus.Twxt.组织机构类型选择_leveloneEdit", Params = ";", pageIndex = 1, perCount = 10 });
            }
            // InitReport("思想汇报（积极分子）", "#", "", true, "ecampus.join_party");//#添加按钮的路由，“”额外参数，TRUE查询按钮显示，“”
            Search.Add("组织机构类型名称");
            InitReport("组织机构类型选择", "#", true, orgnization_id);
            return ReportView();
        }
        public ActionResult Org_TypeChoose_TwoEdit(string ReportID, string Params, string orgnization_id, int pageIndex = 1, int perCount = 10)
        {
            if (!ReportID.HasValue())
            {
                return RedirectToAction("Org_TypeChoose_TwoEdit", new { orgnization_id = orgnization_id, ReportID = "ecampus.Twxt.组织机构类型选择_leveltwoEdit", Params = ";", pageIndex = 1, perCount = 10 });
            }
            // InitReport("思想汇报（积极分子）", "#", "", true, "ecampus.join_party");//#添加按钮的路由，“”额外参数，TRUE查询按钮显示，“”
            Search.Add("组织机构类型名称");
            InitReport("组织机构类型选择", "#", true, orgnization_id);
            return ReportView();
        }
        public ActionResult Org_TypeChoose_ThreeEdit(string ReportID, string Params, string orgnization_id, int pageIndex = 1, int perCount = 10)
        {
            if (!ReportID.HasValue())
            {
                return RedirectToAction("Org_TypeChoose_ThreeEdit", new { orgnization_id = orgnization_id, ReportID = "ecampus.Twxt.组织机构类型选择_levelthreeEdit", Params = ";", pageIndex = 1, perCount = 10 });
            }
            // InitReport("思想汇报（积极分子）", "#", "", true, "ecampus.join_party");//#添加按钮的路由，“”额外参数，TRUE查询按钮显示，“”
            Search.Add("组织机构类型名称");
            InitReport("组织机构类型选择", "#", true, orgnization_id);
            return ReportView();
        }
        public ActionResult Org_LevelChoose(string ReportID, string Params, string AllParams, int pageIndex = 1, int perCount = 10)
        {
            if (!ReportID.HasValue())
            {
                return RedirectToAction("Org_LevelChoose", new { AllParams = AllParams, ReportID = "ecampus.Twxt.选择组织机构级别", Params = ";", pageIndex = 1, perCount = 10 });
            }
            // InitReport("思想汇报（积极分子）", "#", "", true, "ecampus.join_party");//#添加按钮的路由，“”额外参数，TRUE查询按钮显示，“”
            Search.Add("级别名称");
            InitReport("选择组织机构级别", "#", true, AllParams);
            return ReportView();
        }
        public ActionResult Org_LevelChoose_Common(string ReportID, string Params, string AllParams, int pageIndex = 1, int perCount = 10)
        {
            if (!ReportID.HasValue())
            {
                return RedirectToAction("Org_LevelChoose_Common", new { AllParams = AllParams, ReportID = "ecampus.Twxt.选择组织机构级别_公共", Params = ";", pageIndex = 1, perCount = 10 });
            }
            // InitReport("思想汇报（积极分子）", "#", "", true, "ecampus.join_party");//#添加按钮的路由，“”额外参数，TRUE查询按钮显示，“”
            Search.Add("级别名称");
            InitReport("选择组织机构级别", "#", true, AllParams);
            return ReportView();
        }
        #region 更改父节点
        //QxJzxt/Org/ChangeFatherOrg 组织机构类型
        public ActionResult ChangeFatherOrg(string ReportID,string orgnization_id, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!ReportID.HasValue())
            {
                return RedirectToAction("ChangeFatherOrg",
                    new
                    {
                        orgnization_id= orgnization_id,
                        ReportID = "Qx.Jzxt.ChangeFatherOrg",
                        Params = ";",
                        pageIndex = 1,
                        perCount = 10
                    });
            }
            // InitReport("思想汇报（积极分子）", "#", "", true, "ecampus.join_party");//#添加按钮的路由，“”额外参数，TRUE查询按钮显示，“”
            Search.Add("父组织机构名称");
            InitReport("选择父组织机构", "#",true, orgnization_id);
            return ReportView();
        }
        #endregion
        public ActionResult Position(string ReportID, string Params=";" )
        {
            if (!ReportID.HasValue())
            {
                return RedirectToAction("Position",
                    new
                    {
                        ReportID = "Qx.Jzxt.职位列表",
                        Params = Params,
                         pageIndex = 1,
                         perCount = 10
                    });
            }
            Search.Add("职位名称");
            InitReport("职位列表", "/QxJzxt/OrgCRUD/PositionAdd");
            return ReportView();
        }

        //QxJzxt/Org/OrgType 组织机构类型
        public ActionResult OrgType(string reportId, string Params)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("OrgType",
                    new
                    {
                        reportId = "Qx.Jzxt.组织机构类型",
                        Params = ";",// Params.IsFixedParam(),
                        pageIndex = 1,
                        perCount = 10
                    });
            }
            Search.Add("类型名");
            InitReport("组织机构类型", "/QxJzxt/OrgCRUD/AddOrgType", "", true, "ecampus.jzxt");
            return ReportView();
        }

        //QxJzxt/Org/OrgLevel 组织机构级别
        public ActionResult OrgLevel(string reportId, string Params)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("OrgLevel",
                    new
                    {
                        reportId = "Qx.Jzxt.组织机构级别",
                        Params = ";",// Params.IsFixedParam(),
                        pageIndex = 1,
                        perCount = 10
                    });
            }
            Search.Add("级别");
            InitReport("组织机构级别", "/QxJzxt/OrgCRUD/AddOrgLevel", "", true, "ecampus.jzxt");
            return ReportView();
        }

        //QxJzxt/Org/PositionType 组织机构类型
        public ActionResult PositionType(string reportId, string Params)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("PositionType",
                    new
                    {
                        reportId = "Qx.Jzxt.职位类型",
                        Params = ";",// Params.IsFixedParam(),
                        pageIndex = 1,
                        perCount = 10
                    });
            }
            Search.Add("职位类型");
            InitReport("职位类型", "/QxJzxt/OrgCRUD/PositionTypeAdd", "", true, "ecampus.jzxt");
            return ReportView();
        }

        //QxJzxt/Org/Org_Position_User 组织机构相关职员
        public ActionResult Org_Position_User(string reportId, string Params)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("Org_Position_User",
                    new
                    {
                        reportId = "Qx.Jzxt.组织机构职位相关职员",
                        Params = Params.IsFixedParam(),// Params.IsFixedParam(),
                        pageIndex = 1,
                        perCount = 10
                    });
            }
            Search.Add("用户编号");
            Search.Add("用户名");
            Search.Add("下载模板", FormControlType.Button, "#", "bt_download");
            Search.Add("导入", FormControlType.Button, "#", "bt_import");
            InitReport("职位类型", "/QxJzxt/Org/UserList?orgnization_position_id=" + Params, true, "ecampus.jzxt");
            ViewData["orgnization_position_id"] = Params;
            return View();
        }

        //QxJzxt/Org/UserList 用户列表
        public ActionResult UserList(string reportId, string Params,string orgnization_position_id)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("UserList",
                    new
                    {
                        reportId = "Qx.Jzxt.用户列表",
                        Params = ";",// Params.IsFixedParam(),
                        orgnization_position_id= orgnization_position_id,
                        pageIndex = 1,
                        perCount = 10
                    });
            }
            Search.Add("用户编号");
            Search.Add("用户名");
            InitReport("职位类型", "#", "orgnization_position_id="+orgnization_position_id, true, "ecampus.jzxt");
            return ReportView();
        }


    }
}