using Qx.Jzxt.Entity;
using Qx.Jzxt.Services;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Qx.Jzxt.Interfaces;
using Qx.Jzxt.Model;
using Qx.Tools.Exceptions.Form;
using Web.Areas.QxJzxt.ViewModels.CRUD;
using Web.Areas.QxJzxt.ViewModels.Org.OrgCRUD;
using Web.Areas.QxJzxt.ViewModels.Org.ROOT;
namespace Web.Areas.QxJzxt.Controllers
{
    public class OrgCRUDController : BaseQxJzxtController
    {
        // GET: QxJzxt/OrgCRUD
        private QxIJzxtService _qxIJzxtService;
        private IOrgService _IOrgService;
        private IRepository<organization_level> _organization_level;
        private IRepository<organization_relation> _organization_relation;
        private IRepository<orgnization_position> _orgnization_position;
        private IRepository<orgnization_type> _orgnization_type;
        private IRepository<orgnization> _orgnization;
        private IRepository<position_type> _position_type;
        private IRepository<position> _position;
        private IRepository<user_position> _user_position;

        public OrgCRUDController(
            IRepository<organization_level> organization_level,
            IRepository<organization_relation> organization_relation,
            IRepository<orgnization_position> orgnization_position,
            IRepository<orgnization_type> orgnization_type,
            IRepository<orgnization> orgnization,
            IRepository<position_type> position_type,
            IRepository<position> position,
            IRepository<user_position> user_position,
            QxIJzxtService qxIJzxtService,
            IOrgService IOrgService)
        {
            _organization_level = organization_level;
            _organization_relation = organization_relation;
            _orgnization_position = orgnization_position;
            _orgnization_type = orgnization_type;
            _orgnization = orgnization;
            _position_type = position_type;
            _position = position;
            _user_position = user_position;
            _qxIJzxtService = qxIJzxtService;
            _IOrgService = IOrgService;
        }
        public ActionResult Index()
        {
            return View();
        }
        #region ROOT（0级）的添加 编辑 删除
        //public ActionResult LevelZeroAdd()
        //{
        //    InitForm("添加新的根节点");
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult LevelZeroAdd(OrgnizationAdd_M model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _orgnization.Add(model.ToModel(DateTime.Now.Random()));
        //        return RedirectToAction("OrgnizationList", "Org", new { area = "Twxt", ReportID = "ecampus.Twxt.组织机构列表", Params = ";" });
        //    }
        //    else
        //    {
        //        InitForm("添加根节点");
        //        return View(model);
        //    }
        //}
        //public ActionResult LevelZeroEdit(string orgnization_id, string orgnization_type_id)
        //{
        //    InitForm("编辑根节点");
        //    string orgnization_id_ = orgnization_id.Trim(' ');
        //    var org = _orgnization.Find(orgnization_id_);
        //    var org_type = _orgnization_type.Find(org.orgnization_type_id);
        //    var org_level = _organization_level.Find(org.organization_level_id);
        //    if (orgnization_id.HasValue() && orgnization_type_id.HasValue())
        //    {
        //        var org_type2 = _orgnization_type.Find(orgnization_type_id);
        //        return View(OrgnizationEdit_M.ToViewModel(org, org_type2, org_level));
        //    }
        //    else
        //    {
        //        return View(OrgnizationEdit_M.ToViewModel(org, org_type, org_level));
        //    }

        //}
        //[HttpPost]
        //public ActionResult LevelZeroEdit(OrgnizationEdit_M model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _orgnization.Update(model.ToModel());
        //        return RedirectToAction("OrgnizationList", "Org", new { area = "Twxt", ReportID = "ecampus.Twxt.组织机构列表", Params = ";" });
        //    }
        //    else
        //    {
        //        InitForm("编辑根节点");
        //        return View(model);
        //    }
        //}
        //public ActionResult LevelZeroDelete(string orgnization_id)
        //{
        //    if (orgnization_id != null)
        //    {
        //        _orgnization.Delete(orgnization_id);
        //        return Alert("删除成功");
        //    }
        //    else
        //        return Alert("删除失败");
        //}
        #endregion

        //#region 组织机构（1级）的添加 编辑 删除
        //public ActionResult LevelOneAdd(string AllParams,string father_id,string orgnization_type_id, string organization_level_id)
        //{
        //    InitForm("添加");
        //    if (AllParams.HasValue())
        //    {
        //        father_id = _IOrgService.SplitAllParams(AllParams)[1];
        //        if (orgnization_type_id.HasValue())
        //        {
        //            return View(OrgnizationAdd_M.ToViewModel(_IOrgService.SplitAllParams(AllParams), orgnization_type_id, father_id));
        //        }
        //        else if (organization_level_id.HasValue())
        //        {
        //            return View(OrgnizationAdd_M.ToViewModel(_IOrgService.SplitAllParams(AllParams), organization_level_id, father_id, ""));
        //        }
        //        else
        //        {
        //            return Alert("出问题了");
        //        }
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}
        //[HttpPost]
        //public ActionResult LevelOneAdd(OrgnizationAdd_M model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _orgnization.Add(model.ToModel(DateTime.Now.Random(),""));
        //        return RedirectToAction("RootChild", "Org", new { area = "Twxt", ReportID = "ecampus.Twxt.ROOTChild", orgnization_id=model.orgnization_id,Params = ";" });
        //    }
        //    else
        //    {
        //        InitForm("添加");
        //        return View(model);
        //    }
        //}
        //public ActionResult LevelOneEdit(string orgnization_id,string orgnization_type_id)
        //{
        //    InitForm("编辑");
        //    string orgnization_id_ = orgnization_id.Trim(' ');
        //    var org = _orgnization.Find(orgnization_id_);
        //    var org_type = _orgnization_type.Find(org.orgnization_type_id);
        //    var org_level = _organization_level.Find(org.organization_level_id);
        //    if (orgnization_id.HasValue() && orgnization_type_id.HasValue())
        //    {
        //        var org_type2 = _orgnization_type.Find(orgnization_type_id);
        //        return View(OrgnizationEdit_M.ToViewModel(org, org_type2, org_level));
        //    }
        //    else
        //    {
        //        return View(OrgnizationEdit_M.ToViewModel(org, org_type, org_level));
        //    }
        //}
        //[HttpPost]
        //public ActionResult LevelOneEdit(OrgnizationEdit_M model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _orgnization.Update(model.ToModel());
        //        return RedirectToAction("RootChild", "Org", new { area = "Twxt", ReportID = "ecampus.Twxt.ROOTChild", orgnization_id=model.orgnization_id, Params = ";" });
        //    }
        //    else
        //    {
        //        InitForm("编辑");
        //        return View(model);
        //    }
        //}
        //public ActionResult LevelOneDelete(string orgnization_id)
        //{
        //    if (orgnization_id != null)
        //    {
        //        _orgnization.Delete(orgnization_id);
        //        return Alert("删除成功");
        //    }
        //    else
        //        return Alert("删除失败");
        //}
        //#endregion

        //#region 组织机构（2级）的添加 编辑 删除
        //public ActionResult LevelTwoAdd(string AllParams, string father_id, string orgnization_type_id, string organization_level_id)
        //{
        //    InitForm("添加");
        //    if (AllParams.HasValue())
        //    {
        //        father_id = _IOrgService.SplitAllParams(AllParams)[1];
        //        if (orgnization_type_id.HasValue())
        //        {
        //            return View(OrgnizationAdd_M.ToViewModel(_IOrgService.SplitAllParams(AllParams), orgnization_type_id, father_id));
        //        }
        //        else if (organization_level_id.HasValue())
        //        {
        //            return View(OrgnizationAdd_M.ToViewModel(_IOrgService.SplitAllParams(AllParams), organization_level_id, father_id, ""));
        //        }
        //        else
        //        {
        //            return Alert("出问题了");
        //        }

        //    }
        //    else
        //    {

        //        return View();
        //    }

        //}
        //[HttpPost]
        //public ActionResult LevelTwoAdd(OrgnizationAdd_M model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _orgnization.Add(model.ToModel(DateTime.Now.Random(), ""));
        //        return RedirectToAction("RootChild", "Org", new { area = "Twxt", ReportID = "ecampus.Twxt.LevelTwo", orgnization_id = model.orgnization_id, Params = ";" });
        //    }
        //    else
        //    {
        //        InitForm("添加");
        //        return View(model);
        //    }
        //}
        //public ActionResult LevelTwoEdit(string orgnization_id,string orgnization_type_id)
        //{
        //    InitForm("编辑");
        //    string orgnization_id_ = orgnization_id.Trim(' ');
        //    var org = _orgnization.Find(orgnization_id_);
        //    var org_type = _orgnization_type.Find(org.orgnization_type_id);
        //    var org_level = _organization_level.Find(org.organization_level_id);
        //    if (orgnization_id.HasValue() && orgnization_type_id.HasValue())
        //    {
        //        var org_type2 = _orgnization_type.Find(orgnization_type_id);
        //        return View(OrgnizationEdit_M.ToViewModel(org, org_type2, org_level));
        //    }
        //    else
        //    {
        //        return View(OrgnizationEdit_M.ToViewModel(org, org_type, org_level));
        //    }
        //}
        //[HttpPost]
        //public ActionResult LevelTwoEdit(OrgnizationEdit_M model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _orgnization.Update(model.ToModel());
        //        return RedirectToAction("LevelTwo", "Org", new { area = "Twxt", ReportID = "ecampus.Twxt.LevelTwo", orgnization_id = model.father_id, Params = ";" });
        //    }
        //    else
        //    {
        //        InitForm("编辑");
        //        return View(model);
        //    }
        //}
        //public ActionResult LevelTwoDelete(string orgnization_id)
        //{
        //    if (orgnization_id != null)
        //    {
        //        _orgnization.Delete(orgnization_id);
        //        return Alert("删除成功");
        //    }
        //    else
        //        return Alert("删除失败");
        //}
        //#endregion

        //#region 组织机构（3级）的添加 编辑 删除
        //public ActionResult LevelThreeAdd(string AllParams, string father_id, string orgnization_type_id, string organization_level_id)
        //{
        //    InitForm("添加");
        //    if (AllParams.HasValue())
        //    {
        //        father_id = _IOrgService.SplitAllParams(AllParams)[1];
        //        if (orgnization_type_id.HasValue())
        //        {
        //            return View(OrgnizationAdd_M.ToViewModel(_IOrgService.SplitAllParams(AllParams), orgnization_type_id, father_id));
        //        }
        //        else if (organization_level_id.HasValue())
        //        {
        //            return View(OrgnizationAdd_M.ToViewModel(_IOrgService.SplitAllParams(AllParams), organization_level_id, father_id, ""));
        //        }
        //        else
        //        {
        //            return Alert("出问题了");
        //        }

        //    }
        //    else
        //    {
        //        return View();
        //    }

        //}
        //[HttpPost]
        //public ActionResult LevelThreeAdd(OrgnizationAdd_M model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _orgnization.Add(model.ToModel(DateTime.Now.Random(), ""));
        //        return RedirectToAction("LevelThree", "Org", new { area = "Twxt", ReportID = "ecampus.Twxt.LevelThree", orgnization_id = model.orgnization_id, Params = ";" });
        //    }
        //    else
        //    {
        //        InitForm("添加");
        //        return View(model);
        //    }
        //}
        //public ActionResult LevelThreeEdit(string orgnization_id, string orgnization_type_id)
        //{
        //    InitForm("编辑");
        //    string orgnization_id_ = orgnization_id.Trim(' ');
        //    var org = _orgnization.Find(orgnization_id_);
        //    var org_type = _orgnization_type.Find(org.orgnization_type_id);
        //    var org_level = _organization_level.Find(org.organization_level_id);
        //    if (orgnization_id.HasValue() && orgnization_type_id.HasValue())
        //    {
        //        var org_type2 = _orgnization_type.Find(orgnization_type_id);
        //        return View(OrgnizationEdit_M.ToViewModel(org, org_type2, org_level));
        //    }
        //    else
        //    {
        //        return View(OrgnizationEdit_M.ToViewModel(org, org_type, org_level));
        //    }
        //}
        //[HttpPost]
        //public ActionResult LevelThreeEdit(OrgnizationEdit_M model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _orgnization.Update(model.ToModel());
        //        return RedirectToAction("LevelThree", "Org", new { area = "Twxt", ReportID = "ecampus.Twxt.LevelThree", orgnization_id = model.father_id, father_id=model.father_id,Params = ";" });
        //    }
        //    else
        //    {
        //        InitForm("编辑");
        //        return View(model);
        //    }
        //}
        //public ActionResult LevelThreeDelete(string orgnization_id)
        //{
        //    if (orgnization_id != null)
        //    {
        //        _orgnization.Delete(orgnization_id);
        //        return Alert("删除成功");
        //    }
        //    else
        //        return Alert("删除失败");
        //}
        //#endregion

        #region 组织机构下设的职位增、删、改（机构增/删/改职位，只是添加一条机构与职位的关系记录，与职位的维护不同）
        public ActionResult Org_PositionAdd(string orgnization_id, string position_id)
        {
            if (position_id.HasValue() & orgnization_id.HasValue())
            {
                _orgnization_position.Add(Org_PositionAdd_M.ToModel(DateTime.Now.Random().ToString(), orgnization_id, position_id));
                return Alert("添加成功");
            }
            else
                return Alert("添加失败");

        }
        /*
        public ActionResult Org_PositionEdit(string orgnization_position_id, string orgnization_id, string position_id)
        {

        }
        [HttpPost]
        public ActionResult Org_PositionEdit(Org_PositionEdit_M model)
        {
            if (ModelState.IsValid)
            {
                _position.Update(model.ToModel());
                return RedirectToAction("Position", "Org", new { area = "Twxt", ReportID = "ecampus.Twxt.编辑职位", Params = ";" });
            }
            else
            {
                InitForm("编辑");
                return View(model);
            }
        }*/
        public ActionResult Org_PositionDelete(string orgnization_position_id)
        {
            if (orgnization_position_id != null)
            {
                _orgnization_position.Delete(orgnization_position_id);
                return Alert("删除成功");
            }
            else
                return Alert("删除失败");
        }
        #endregion

        #region 组织机构关联关系的 添加，删除，不需要编辑：比如学校->校团委，它们就只是一种关系的存在
        public ActionResult Relation_OrgAdd(string orgnization_id, string other_orgnization_id)
        {
            if (other_orgnization_id.HasValue() & orgnization_id.HasValue())
            {
                _organization_relation.Add(Relation_OrgAdd_M.ToModel(DateTime.Now.Random().ToString(), orgnization_id, other_orgnization_id));
                return Alert("添加成功");
            }
            else
                return Alert("添加失败");

        }
        public ActionResult Relation_OrgDelete(string organization_relation_id)
        {
            if (organization_relation_id != null)
            {
                _organization_relation.Delete(organization_relation_id);
                return Alert("删除成功");
            }
            else
                return Alert("删除失败");
        }

        public ActionResult Relation_Org_UserDelete(string user_position_id)
        {
            if (user_position_id != null)
            {
                _user_position.Delete(user_position_id);
                return Alert("删除成功");
            }
            else
                return Alert("删除失败");
        }
        #endregion

        #region 职位对应的职员
        public ActionResult Relation_Org_UserAdd(string user_id, string orgnization_position_id)
        {
            if (user_id.HasValue() && orgnization_position_id.HasValue())
            {
                _user_position.Add(Relation_Org_UserAdd_M.ToModel(DateTime.Now.Random(), orgnization_position_id, user_id));
                return Alert("添加成功");
            }
            else
                return Alert("添加失败");
        }
        #endregion


        #region 职位的添加 删除 编辑
        public ActionResult PositionAdd()
        {
            InitForm("添加职位");
            return View(Position_M.ToViewModel(_position_type.ToSelectItems()));
        }
        [HttpPost]
        public ActionResult PositionAdd(Position_M model)
        {
            if (ModelState.IsValid)
            {
                _position.Add(model.ToModel());
                return RedirectToAction("Position", "Org");
            }
            else
            {
                InitForm("添加职位");
                model.typeItem = _position_type.ToSelectItems();
                return View(model);
            }
        }
        public ActionResult PositionEdit(string id)
        {
            InitForm("编辑职位");
            var position = _position.Find(id);
            if (position != null)
            {
                return View(Position_M.ToViewModel(_position_type.ToSelectItems(), id, position.name, position.descripe, position.note, position.position_type_id));
            }
            else
            {
                return Alert("操作失败");
            }
        }
        [HttpPost]
        public ActionResult PositionEdit(Position_M model)
        {
            if (ModelState.IsValid)
            {
                _position.Update(model.ToModel());
                return RedirectToAction("Position", "Org");
            }
            else
            {
                InitForm("编辑职位");
                model.typeItem = _position_type.ToSelectItems();
                return View(model);
            }
        }
        public ActionResult PositionDelete(string id)
        {
            var position = _position.Find(id);
            if (position != null)
            {
                _position.Delete(id);
                return Alert("删除成功");
            }
            else
                return Alert("删除失败");
        }
        #endregion



        #region 公共的组织机构 ：添加、删除、编辑
        public ActionResult Org_CommonAdd(string father_id)
        {
            if (father_id.HasValue())
            {
                int index = father_id.IndexOf('!');
                var orgnization_id = father_id.Substring(0, index);
                InitForm("添加");
                var typeSelect = _orgnization_type.ToSelectItems();
                var levelSelect = _organization_level.ToSelectItems();
                var fatherOrg = _orgnization.Find(orgnization_id);
                return View(OrgnizationAdd_M.ToViewModel(orgnization_id, typeSelect, levelSelect, fatherOrg));
            }
            else
            {
                return Alert("参数请求错误");
            }
        }
        [HttpPost]
        public ActionResult Org_CommonAdd(OrgnizationAdd_M model)
        {
            try
            {
                var record = _orgnization.Add(model.ToModel());
                return record.HasValue()
                    ? Redirect("/QxJzxt/Org/Org_Common?Params=" + model.father_id)
                    : Alert("添加失败");
            }
            catch (FormValitationException ex)
            {
                FormValitation = ex;
                InitForm("添加");
                var typeSelect = _orgnization_type.ToSelectItems();
                var levelSelect = _organization_level.ToSelectItems();
                var fatherOrg = _orgnization.Find(model.fatherOrgName);
                return View(OrgnizationAdd_M.ToViewModel(model.father_id, typeSelect, levelSelect, fatherOrg));
            }
        }
        public ActionResult Org_CommonDelete(string orgnization_id)
        {
            return orgnization_id.HasValue()
                ? (!_IOrgService.findOrgIsRelation(orgnization_id)
                    ? (Alert(_orgnization.Delete(orgnization_id) ? "删除成功" : "删除失败"))
                    : (Alert("该组织机构包含有子机构，若需要删除则应先删除子机构")))
                : (Alert("参数错误"));
        }
        public ActionResult Org_CommonEdit(string orgnization_id)
        {
            if (orgnization_id.HasValue())
            {
                InitForm("编辑");
                var childOrg = _orgnization.Find(orgnization_id);
                var fatherOrg = _orgnization.Find(childOrg.father_id);
                var typeSelect = _orgnization_type.ToSelectItems();
                var levelSelect = _organization_level.ToSelectItems();
                return View(OrgnizationEdit_M.ToViewModel(childOrg, fatherOrg, typeSelect, levelSelect));
            }
            else
            {
                return Alert("参数请求错误");
            }
        }
        [HttpPost]
        public ActionResult Org_CommonEdit(OrgnizationEdit_M model)
        {
            try
            {
                var result = _orgnization.Update(model.ToModel());
                if (model.father_id == "0") //根节点
                {
                    return result
                 ? Redirect("/QxJzxt/Org/OrgnizationList")
                 : Alert("编辑失败");
                }
                else
                {
                    return result
                 ? Redirect("/QxJzxt/Org/Org_Common?Params=" + model.father_id)
                 : Alert("编辑失败");
                }
            }
            catch (FormValitationException ex)
            {
                FormValitation = ex;
                InitForm("编辑");
                var childOrg = _orgnization.Find(model.orgnization_id);
                var fatherOrg = _orgnization.Find(childOrg.father_id);
                var typeSelect = _orgnization_type.ToSelectItems();
                var levelSelect = _organization_level.ToSelectItems();
                return View(OrgnizationEdit_M.ToViewModel(childOrg, fatherOrg, typeSelect, levelSelect));
            }
        }
        public ActionResult ChangeFatherOrg_crud(string father_id, string orgnization_id)
        {
            if (orgnization_id.HasValue() && father_id.HasValue())
            {
                if (father_id != orgnization_id)
                {
                    var orgnization = _orgnization.Find(orgnization_id);
                    orgnization.father_id = father_id;
                    _orgnization.Update(orgnization);
                    return Alert("更改成功");
                }
                else
                {
                    return Alert("不能将上级组织机构和下级组织机构设为同一个");
                }
            }
            else
            {
                return Alert("参数请求错误");
            }
        }
        #endregion

        #region 组织机构类型

        // QxJzxt/OrgCRUD/AddOrgType 添加
        public ActionResult AddOrgType()
        {
            InitForm("添加组织机构类型");
            return View();
        }
        [HttpPost]
        public ActionResult AddOrgType(AddOrgType_M model)
        {
            try
            {
                var result = _orgnization_type.Add(model.ToModel());
                return result.HasValue() ? RedirectToAction("OrgType", "Org",
                    new { area = "QxJzxt" }) : Alert("添加失败");
            }
            catch (FormValitationException ex)
            {
                FormValitation = ex;
                InitForm("添加组织机构类型");
                return View(model);
            }
        }

        // QxJzxt/OrgCRUD/DeleteOrgType 删除
        public ActionResult DeleteOrgType(string orgnization_type_id)
        {
            if (orgnization_type_id.HasValue())
            {
                if (!_IOrgService.FindOrgTypeIsRelation(orgnization_type_id))
                {
                    return Alert(_orgnization_type.Delete(orgnization_type_id) ? "删除成功" : "删除失败");
                }
                else
                {
                    return Alert("该组织机构类型已经跟相关组织机构有关联，不能删除");
                }
            }
            else
            {
                return Alert("参数请求错误");
            }
        }

        // QxJzxt/OrgCRUD/EditOrgType  编辑
        public ActionResult EditOrgType(string orgnization_type_id)
        {
            if (orgnization_type_id.HasValue())
            {
                InitForm("编辑组织机构类型");
                var data = _orgnization_type.Find(orgnization_type_id);
                return View(EditOrgType_M.ToViewModel(data));
            }
            else
            {
                return Alert("参数请求错误");
            }
        }

        [HttpPost]
        public ActionResult EditOrgType(EditOrgType_M model)
        {
            try
            {
                var result = _orgnization_type.Update(model.ToModel());
                return result
                    ? RedirectToAction("OrgType", "Org",
                    new { area = "QxJzxt" })
                    : Alert("更新失败");
            }
            catch (FormValitationException ex)
            {
                FormValitation = ex;
                InitForm("编辑组织机构类型");
                var data = _orgnization_type.Find(model.orgnization_type_id);
                return View(EditOrgType_M.ToViewModel(data));
            }
        }
        #endregion

        #region 组织机构级别

        // QxJzxt/OrgCRUD/AddOrgLevel 添加
        public ActionResult AddOrgLevel()
        {
            InitForm("添加组织机构级别");
            return View();
        }
        [HttpPost]
        public ActionResult AddOrgLevel(AddOrgLevel_M model)
        {
            try
            {
                var result = _organization_level.Add(model.ToModel());
                return result.HasValue() ? RedirectToAction("OrgLevel", "Org",
                    new { area = "QxJzxt" }) : Alert("添加失败");
            }
            catch (FormValitationException ex)
            {
                FormValitation = ex;
                InitForm("添加组织机构级别");
                return View(model);
            }
        }

        // QxJzxt/OrgCRUD/DeleteOrgLevel 删除
        public ActionResult DeleteOrgLevel(string orgnization_level_id)
        {
            if (orgnization_level_id.HasValue())
            {
                if (!_IOrgService.FindOrgLevelRelation(orgnization_level_id))
                {
                    return Alert(_organization_level.Delete(orgnization_level_id) ? "删除成功" : "删除失败");
                }
                else
                {
                    return Alert("该组织机构级别已经跟相关组织机构有关联，不能删除");
                }
            }
            else
            {
                return Alert("参数请求错误");
            }
        }

        // QxJzxt/OrgCRUD/EditOrgLevel  编辑
        public ActionResult EditOrgLevel(string orgnization_level_id)
        {
            if (orgnization_level_id.HasValue())
            {
                InitForm("编辑组织机构级别");
                var data = _organization_level.Find(orgnization_level_id);
                return View(EditOrgLevel_M.ToViewModel(data));
            }
            else
            {
                return Alert("参数请求错误");
            }
        }

        [HttpPost]
        public ActionResult EditOrgLevel(EditOrgLevel_M model)
        {
            try
            {
                var result = _organization_level.Update(model.ToModel());
                return result
                    ? RedirectToAction("OrgLevel", "Org",
                    new { area = "QxJzxt" })
                    : Alert("更新失败");
            }
            catch (FormValitationException ex)
            {
                FormValitation = ex;
                InitForm("编辑组织机构级别");
                var data = _organization_level.Find(model.organization_level_id);
                return View(EditOrgLevel_M.ToViewModel(data));
            }
        }
        #endregion

        #region 职位类型的添加 删除 编辑
        // QxJzxt/OrgCRUD/PositionTypeAdd
        public ActionResult PositionTypeAdd()
        {
            InitForm("添加职位");
            return View();
        }
        [HttpPost]
        public ActionResult PositionTypeAdd(PositionTypeAdd_M model)
        {
            try
            {
                var result = _position_type.Add(model.ToModel());
                return result.HasValue() ? RedirectToAction("PositionType", "Org",
                    new { area = "QxJzxt" }) : Alert("添加失败");
            }
            catch (FormValitationException ex)
            {
                FormValitation = ex;
                InitForm("添加职位");
                return View(model);
            }
        }

        // QxJzxt/OrgCRUD/PositionTypeEdit
        public ActionResult PositionTypeEdit(string position_type_id)
        {
            if (position_type_id.HasValue())
            {
                InitForm("编辑职位");
                var position_type = _position_type.Find(position_type_id);
                return View(PositionTypeEdit_M.ToViewModel(position_type));
            }
            else
            {
                return Alert("参数请求错误");
            }
        }
        [HttpPost]
        public ActionResult PositionTypeEdit(PositionTypeEdit_M model)
        {
            try
            {
                var result = _position_type.Update(model.ToModel());
                return result ? RedirectToAction("PositionType", "Org",
                    new { area = "QxJzxt" }) : Alert("编辑失败");
            }
            catch (FormValitationException ex)
            {
                FormValitation = ex;
                InitForm("编辑职位");
                var position_type = _position_type.Find(model.position_type_id);
                return View(PositionTypeEdit_M.ToViewModel(position_type));
            }
        }

        // QxJzxt/OrgCRUD/PositionTypeDelete
        public ActionResult PositionTypeDelete(string position_type_id)
        {
            if (position_type_id.HasValue())
            {
                if (!_IOrgService.FindPositionTypeIsRelation(position_type_id))
                {
                    return Alert(_position_type.Delete(position_type_id) ? "删除成功" : "删除失败");
                }
                else
                {
                    return Alert("该职位类型已经有相关联的职位，不能删除，若想删除，请先将所关联的职位删除");
                }
            }
            else
                return Alert("参数请求错误");
        }
        #endregion

        #region  组织机构职位
        // QxJzxt/OrgCRUD/Add_Org_Position
        public ActionResult Add_Org_Position(string orgid)
        {
            if (orgid.HasValue())
            {
                int index = orgid.IndexOf('!');
                var orgnization_id = orgid.Substring(0, index);
                InitForm("为组织机构添加职位");
                var org = _orgnization.Find(orgnization_id);
                var positionSelect = _position.ToSelectItems();
                return View(Org_Position_M.ToViewModel(orgnization_id, positionSelect, org));
            }
            else
            {
                return Alert("参数请求错误");
            }
        }

        [HttpPost]
        public ActionResult Add_Org_Position(Org_Position_M model)
        {
            try
            {
                if (!_IOrgService.FindPositionIsRelationOrg(model.orgnization_id, model.position_id))
                {
                    var result = _orgnization_position.Add(model.ToModel());
                    return result.HasValue() ? RedirectToAction("Org_Position", "Org",
                    new { area = "QxJzxt", Params = model.orgnization_id }) : Alert("添加失败");
                }
                else
                {
                    return Alert("该组织机构已经添加过该职位了，请勿重复添加");
                }
            }
            catch (FormValitationException ex)
            {
                FormValitation = ex;
                InitForm("为组织机构添加职位");
                var positionSelect = _position.ToSelectItems();
                var org = _orgnization.Find(model.orgnization_id);
                return View(Org_Position_M.ToViewModel(model.orgnization_id, positionSelect, org));
            }
        }

        // QxJzxt/OrgCRUD/Delete_Org_Position
        public ActionResult Delete_Org_Position(string orgnization_position_id)
        {
            if (orgnization_position_id.HasValue())
            {
                if (!_IOrgService.FindOrgPositionIsRelationUser(orgnization_position_id))
                {
                    return Alert(_orgnization_position.Delete(orgnization_position_id) ? "删除成功" : "删除失败");
                }
                else
                {
                    return Alert("该职位下面已经有人员了，不能删除，若想删除，请先将职位下面得所有人员删除，在删除该职位");
                }
            }
            else
            {
                return Alert("参数请求错误");
            }
        }
        #endregion

        #region 将该用户添加到职位里面
        // QxJzxt/OrgCRUD/AddUserToOrgPosition
        public ActionResult AddUserToOrgPosition(string uid, string orgnization_position_id)
        {
            if (uid.HasValue() && orgnization_position_id.HasValue())
            {
                int index = orgnization_position_id.IndexOf('!');
                var id = orgnization_position_id.Substring(0, index);
                if (!_IOrgService.FandUserIsExistOrgPosition(uid, id))
                {
                    user_position model = new user_position();
                    model.user_id = uid;
                    model.orgnization_position_id = id;
                    return Alert(_user_position.Add(model).HasValue() ? "添加成功" : "添加失败");
                }
                else
                {
                    return Alert("已添加过该用户，请勿重复添加");
                }
            }
            else
            {
                return Alert("参数请求错误");
            }
        }
        #endregion

        #region 删除职位里面的职员
        // QxJzxt/OrgCRUD/DeleteStaff
        public ActionResult DeleteStaff(string user_position_id)
        {
            return user_position_id.HasValue() ? Alert(_user_position.Delete(user_position_id) ? "删除成功" : "删除失败") :
            Alert("参数请求错误");
        }
        #endregion

        #region ImportStaff 导入职员 
        //QxJzxt/OrgCRUD/ImportStaff
        [HttpPost]
        public int ImportStaff(string data,string orgnization_position_id)
        {
            data = data.Replace("\n", "");
            var StaffList = data.Deserialize<List<Staff>>();
            return _IOrgService.ImportStaff(StaffList, orgnization_position_id);
        }

        #endregion

    }
}