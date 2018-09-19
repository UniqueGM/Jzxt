using Qx.Jzxt.Entity;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Qx.Jzxt.Interfaces;
using Qx.Jzxt.Model;
using Qx.Tools.Exceptions.Form;
using Web.Areas.QxJzxt.ViewModels.CRUD;

namespace Web.Areas.QxJzxt.Controllers
{
    public class CRUDController : BaseQxJzxtController
    {
        // GET: QxJzxt/CRUD
        private IRepository<award_type> _award_type;
        private IRepository<award_baseInfo> _award_baseInfo;
        private IRepository<award_type_baseInfo> _award_type_baseInfo;
        private IRepository<award_batch> _award_batch;
        private IRepository<material_attrs> _material_attrs;
        private IRepository<material_type> _material_type;
        private IRepository<material_type_attrs> _material_type_attrs;
        private IRepository<award_material> _award_material;
        private IRepository<award_instance> _award_instance;
        private IRepository<award_batch_instance> _award_batch_instance;
        private IRepository<award_materia_instance> _award_materia_instance;
        private IRepository<award_instance_baseInfo> _award_instance_baseInfo;
        private IRepository<user_material> _user_material;
        private IRepository<org_award_instance> _org_award_instance;
        private IRepository<org> _org;
        private IRepository<award_apply> _award_apply;
        private QxIJzxtService _qxIJzxtService;
        public CRUDController(
            IRepository<award_type> award_type, 
            IRepository<award_baseInfo> award_baseInfo,
            IRepository<award_type_baseInfo> award_type_baseInfo,
            IRepository<award_batch> award_batch,
            IRepository<material_attrs> material_attrs,
            IRepository<material_type> material_type,
            IRepository<material_type_attrs> material_type_attrs,
            IRepository<award_material> award_material,
            IRepository<award_instance> award_instance,
            IRepository<award_batch_instance> award_batch_instance,
            IRepository<award_materia_instance> award_materia_instance,
            IRepository<award_instance_baseInfo> award_instance_baseInfo,
            IRepository<user_material> user_material,
            IRepository<org_award_instance> org_award_instance,
            IRepository<org> org,
            IRepository<award_apply> award_apply,
            QxIJzxtService qxIJzxtService
            )
        {
            _award_type = award_type;
            _award_baseInfo = award_baseInfo;
            _award_batch = award_batch;
            _material_attrs = material_attrs;
            _material_type = material_type;
            _award_type_baseInfo = award_type_baseInfo;
            _qxIJzxtService = qxIJzxtService;
            _material_type_attrs = material_type_attrs;
            _award_material = award_material;
            _award_instance = award_instance;
            _award_batch_instance = award_batch_instance;
            _award_materia_instance = award_materia_instance;
            _award_instance_baseInfo = award_instance_baseInfo;
            _user_material = user_material;
            _org_award_instance = org_award_instance;
            _org = org;
            _award_apply = award_apply;
        }
        public ActionResult Index()
        {
            return View();
        }

        #region AwardType 奖项类型
        // QxJzxt/CRUD/AddAwardType
        public ActionResult AddAwardType()
        {
            InitForm("添加奖项类型");
            return View();
        }
        [HttpPost]
        public ActionResult AddAwardType(AddAwardType_M model)
        {
            try
            {
               var result= _award_type.Add(model.ToModel(DateTime.Now.Random()));
                return result.HasValue()?RedirectToAction("AwardTypeList", "AutoReport", new { area = "QxJzxt", reportId = "Qx.Jzxt.奖项类型", Params = ";" }):Alert("添加失败");
            }
            catch (FormValitationException  ex)
            {
                FormValitation = ex;
                InitForm("添加奖项类型");
                return View(model);
            }       
        }
        // QxJzxt/CRUD/DeleteAwardType
        public ActionResult DeleteAwardType(string awardtypeid)
        {
            if (awardtypeid.HasValue())
            {
                if (!_qxIJzxtService.FindAwardInstanceAboutAwardType(awardtypeid))
                {
                    return awardtypeid.HasValue() ? Alert(_award_type.Delete(awardtypeid) ? "删除成功" : "删除失败") : Alert("删除失败");
                }
                else
                {
                    return Alert("该奖项类型已经有相应的实施奖项，不能删除");
                }
            }
            else
            {
                return Alert("参数请求错误");
            }
        }
        // QxJzxt/CRUD/EditAwardType
        public ActionResult EditAwardType(string awardtypeid)
        {
            InitForm("编辑奖项");
            var awardtype = _award_type.Find(awardtypeid);
            return View(EditAwardType_M.ToViewModel(awardtype));
        }
        [HttpPost]
        public ActionResult EditAwardType(EditAwardType_M model)
        {
            try
            {
                var result = _award_type.Update(model.ToModel(model.awardtypeid));
                return result
                    ? RedirectToAction("AwardTypeList", "AutoReport",
                        new {area = "QxJzxt", ReportID = "Qx.Jzxt.奖项类型", Params = ";"})
                    : Alert("更新失败");
            }
            catch (FormValitationException ex)
            {
                FormValitation = ex;
                InitForm("编辑奖项");
                return View(model);
            }
        }
        // QxJzxt/CRUD/DetailAwardType
        public ActionResult DetailAwardType(string awardtypeid)
        {
            if (awardtypeid.HasValue())
            {
                InitForm("奖项详情");
                var awardtype = _award_type.Find(awardtypeid);
                return View(DetailAwardType_M.ToViewModel(awardtype));
            }
            else
            {
                return Alert("参数请求错误");
            }
        }
        #endregion

        #region BaseInfo 奖项基本信息
        // QxJzxt/CRUD/AddBaseInfoToAward 添加奖项的基本信息项
        public ActionResult AddBaseInfoToAward(string awardtypeid)
        {
            //return (baseinfoid.HasValue())? View(AddToAward_M.ToViewModel(_award_type.ToSelectItems(), baseinfoid)) : Alert("请求出错");
            if (awardtypeid.HasValue())
            {

                var baseinfo = _award_baseInfo.ToSelectItems();
                InitForm("添加奖项基本信息项");
                return View(AddBaseInfoToAward_M.ToViewModel(baseinfo, awardtypeid));
            }
            else
            {
                return Alert("请求出错");
            }
        }

        [HttpPost]
        public ActionResult AddBaseInfoToAward(AddBaseInfoToAward_M model)
        {
            try
            {
                var index = model.awardtypeid.IndexOf('!');
                    model.awardtypeid = model.awardtypeid.Substring(0, index);
                var old = _qxIJzxtService.FindATBI(model.baseinfoid, model.awardtypeid);
                if (!old)//不存在该条记录
                {
                  
                    //  /QxJzxt/AutoReport/AwardBaseInfoList?Params={ 0}   RedirectToAction("AwardBaseInfoList", "AutoReport",new { area = "QxJzxt", reportId = "Qx.Jzxt.奖项基本信息", Params = model.awardtypeid })
                    var result = _award_type_baseInfo.Add(model.ToModel());
                    return (result.HasValue())
                        ? Redirect("/QxJzxt/AutoReport/AwardBaseInfoList?Params=" + model.awardtypeid)
                        : Alert("添加失败");
                }
                else
                {
                    return Alert("已添加过该条基本信息,请重新选择添加");
                }
            }
            catch (FormValitationException ex)
            {
                FormValitation = ex;
                var awardtype = _award_type.ToSelectItems();
                InitForm("添加奖项基本信息项");
                return View(AddBaseInfoToAward_M.ToViewModel(awardtype, model.baseinfoid));
            }        
        }

        // QxJzxt/CRUD/AddBaseInfo

        public ActionResult AddBaseInfo()
        {
            InitForm("添加基本信息项");           
            return View(AddBaseInfo_M.ToViewModel(_qxIJzxtService.BaseInfoTypeList()));
        }
        [HttpPost]
        public ActionResult AddBaseInfo(AddBaseInfo_M model)
        {
            try
            {
                var result = _award_baseInfo.Add(model.ToModel(DateTime.Now.Random()));
                return result.HasValue() ? RedirectToAction("BaseInfoList", "AutoReport",
                    new { area = "QxJzxt", reportId = "Qx.Jzxt.基本信息", Params = ";" }) : Alert("添加失败");
            }
            catch (FormValitationException ex)
            {
                FormValitation = ex;
                InitForm("添加基本信息项");
                return View(AddBaseInfo_M.ToViewModel(_qxIJzxtService.TypeList()));
            }       
        }
        // QxJzxt/CRUD/DeleteBaseInfo
        public ActionResult DeleteBaseInfo(string baseinfoid)
        {
            try
            {
                return baseinfoid.HasValue()
                    ? (Alert(_award_baseInfo.Delete(baseinfoid) ? "删除成功" : "删除失败"))
                    : (Alert("删除失败"));            
            }
            catch (FormValitationException ex)
            {
                FormValitation = ex;
                return RedirectToAction("BaseInfoList", "AutoReport",
                    new { area = "QxJzxt", reportId = "Qx.Jzxt.基本信息", Params = ";" });
            }

        }
        // QxJzxt/CRUD/EditBaseInfo
        public ActionResult EditBaseInfo(string baseinfoid)
        { 
            InitForm("编辑基本信息项");
            var baseinfo = _award_baseInfo.Find(baseinfoid);
            var typelist = _qxIJzxtService.BaseInfoTypeList();
            return View(EditBaseInfo_M.ToViewModel(baseinfo, typelist));
        }

        [HttpPost]
        public ActionResult EditBaseInfo(EditBaseInfo_M model)
        {
            try
            {
                var result = _award_baseInfo.Update(model.ToModel(model.baseinfoid));
                return result
                    ? RedirectToAction("BaseInfoList", "AutoReport",
                        new { area = "QxJzxt", reportId = "Qx.Jzxt.基本信息", Params = ";" })
                    : Alert("更新失败");           
            }
            catch (FormValitationException ex)
            {
                FormValitation = ex;
                InitForm("编辑基本信息项");
                var baseinfo = _award_baseInfo.Find(model.baseinfoid);
                var typelist = _qxIJzxtService.TypeList();
                return View(EditBaseInfo_M.ToViewModel(baseinfo, typelist));
            }
        }
        #endregion

        #region AwardBatch 奖项批次
        // QxJzxt/CRUD/AddAwardBatch
        public ActionResult AddAwardBatch()
        {
            InitForm("添加奖项批次");
            return View();
        }
        [HttpPost]
        public ActionResult AddAwardBatch(AddAwardBatch_M model)
        {
            try
            {
                var result = _award_batch.Add(model.ToModel(DateTime.Now.Random()));
                return result.HasValue() ? RedirectToAction("BatchList", "AutoReport",
                    new { area = "QxJzxt", reportId = "Qx.Jzxt.奖项批次", Params = ";" }) : Alert("添加失败");
            }
            catch (FormValitationException ex)
            {
                FormValitation = ex;
                InitForm("添加奖项批次");
                return View();
            }        
        }
        // QxJzxt/CRUD/DeleteAwardBatch
        public ActionResult DeleteAwardBatch(string batchid)
        {
            if (batchid.HasValue())
            {
                if (!_qxIJzxtService.FindBatchAboutAwardInstance(batchid))
                {
                    return batchid.HasValue() ? Alert(_award_batch.Delete(batchid) ? "删除成功" : "删除失败") : Alert("删除失败");
                }
                else
                {
                    return Alert("该批次已经有具体的实施奖项，不能删除，若想要删除，请把该批次下的所有有关实施奖项全部删除");
                }
            }
            else
            {
                return Alert("参数请求错误");
            }
        }
        // QxJzxt/CRUD/EditAwardBatch
        public ActionResult EditAwardBatch(string batchid)
        {
            InitForm("编辑基本信息项");
            var batch = _award_batch.Find(batchid);
            return View(EditAwardBatch_M.ToViewModel(batch));
        }

        [HttpPost]
        public ActionResult EditAwardBatch(EditAwardBatch_M model)
        {
            try
            {
                var result = _award_batch.Update(model.ToModel(model.batchid));
                return result
                    ? RedirectToAction("BatchList", "AutoReport",
                        new { area = "QxJzxt", reportId = "Qx.Jzxt.奖项批次", Params = ";" })
                    : Alert("更新失败");
            }
            catch (FormValitationException ex)
            {
                FormValitation = ex;
                InitForm("编辑基本信息项");
                var batch = _award_batch.Find(model.batchid);
                return View(EditAwardBatch_M.ToViewModel(batch));
            }       
        }
        // QxJzxt/CRUD/DetailAwardBatch
        public ActionResult DetailAwardBatch(string batchid)
        {
            InitForm("基本信息项详情");
            var batch = _award_batch.Find(batchid);
            return View(DetailAwardBatch_M.ToViewModel(batch));
        }
        // QxJzxt/CRUD/SetCurrentBatch 设置当前批次
        public ActionResult SetCurrentBatch(string batchid)
        {
            return batchid.HasValue()
                ? (_qxIJzxtService.SetCurrentBatch(batchid) ? Redirect("/QxJzxt/AutoReport/BatchList") : Alert("操作错误"))
                : Alert("参数出错");
        }
        //QxJzxt/CRUD/OffCurrentBatch 关闭当前批次
        public ActionResult OffCurrentBatch(string batchid)
        {
            return batchid.HasValue()
                ? (_qxIJzxtService.OffCurrentBatch(batchid) ? Redirect("/QxJzxt/AutoReport/BatchList") : Alert("操作错误"))
                : Alert("参数出错");
        }

        #endregion

        #region MaterialType 材料类型
        // QxJzxt/CRUD/AddMaterialToAward 添加材料类型到奖励类型
        public ActionResult AddMaterialToAward(string id)
        {
            if (id.HasValue())
            {
                InitForm("添加到奖励类型");
                var awardtype = _award_type.ToSelectItems();
                return View(AddMaterialToAward_M.ToViewModel(awardtype, id));
            }
            else
            {
                return Alert("参数请求错误");
            }
        }
        [HttpPost]
        public ActionResult AddMaterialToAward(AddMaterialToAward_M model)
        {
            try
            {
                var record = _qxIJzxtService.FindAM(model.materialtypeid, model.awardtypeid);
                if (!record)
                {
                    var result = _award_material.Add(model.ToModel(DateTime.Now.Random()));
                    return result.HasValue()
                        ? Redirect("/QxJzxt/AutoReport/AwardMaterialList?Params=" + model.awardtypeid)
                        : Alert("添加失败");
                }
                else
                {
                   return  Alert("已将该材料类型添加到奖励类型中，请重新添加！");
                }
            }
            catch (FormValitationException ex)
            {
                FormValitation = ex;
                InitForm("添加到奖励类型");
                var awardtype = _award_type.ToSelectItems();
                return View(AddMaterialToAward_M.ToViewModel(awardtype, model.materialtypeid));
            }         
        }

        // QxJzxt/CRUD/AddMaterialType
        public ActionResult AddMaterialType()
        {
            InitForm("添加材料类型");
            return View();
        }
        [HttpPost]
        public ActionResult AddMaterialType(AddMaterialType_M model)
        {
            try
            {
                var result = _material_type.Add(model.ToModel(DateTime.Now.Random()));
                return result.HasValue() ? RedirectToAction("MaterialTypeList", "AutoReport",
                    new { area = "QxJzxt", reportId = "Qx.Jzxt.材料类型", Params = ";" }) : Alert("添加失败");
            }
            catch (FormValitationException ex)
            {
                FormValitation = ex;
                InitForm("添加材料类型");
                return View();
            }
        }
        // QxJzxt/CRUD/DeleteMaterialType
        public ActionResult DeleteMaterialType(string materialtypeid)
        {
            if (materialtypeid.HasValue())
            {
                if(!_qxIJzxtService.FindMaterialAboutAwardInstance(materialtypeid))
                {
                    return materialtypeid.HasValue()
                                      ? Alert(_material_type.Delete(materialtypeid) ? "删除成功" : "删除失败")
                                      : Alert("删除失败");
                }
                else
                {
                    return Alert("该材料类型已经跟某一个具体的实施奖项相关联，不能删除");
                }
            }
            else
            {
                return Alert("参数请求错误");
            }
              
        }
        // QxJzxt/CRUD/EditMaterialType
        public ActionResult EditMaterialType(string materialtypeid)
        {
            InitForm("编辑材料类型");
            var materialtype = _material_type.Find(materialtypeid);
            return View(EditMaterialType_M.ToViewModel(materialtype));
        }

        [HttpPost]
        public ActionResult EditMaterialType(EditMaterialType_M model)
        {
            try
            {
                var result = _material_type.Update(model.ToModel(model.materialtypeid));
                return result
                    ? RedirectToAction("MaterialTypeList", "AutoReport",
                        new { area = "QxJzxt", reportId = "Qx.Jzxt.材料类型", Params = ";" })
                    : Alert("更新失败");
            }
            catch (FormValitationException ex)
            {
                FormValitation = ex;
                InitForm("编辑材料类型");
                var materialtype = _material_type.Find(model.materialtypeid);
                return View(EditMaterialType_M.ToViewModel(materialtype));
            }          
        }
        // QxJzxt/CRUD/DetailMaterialType
        public ActionResult DetailMaterialType(string materialtypeid)
        {
            InitForm("材料类型详情");
            var materialtype = _material_type.Find(materialtypeid);
            return View(DetailMaterialType_M.ToViewModel(materialtype));
        }
        #endregion

        #region MaterialAttrs 材料属性
        // QxJzxt/CRUD/AddAttrsToMaterialType  将材料的属性加入到材料类型里面
        public ActionResult AddAttrsToMaterialType(string id)
        {
            InitForm("添加到材料类型");
            var material = _material_type.ToSelectItems();
            return View(AddAttrsToMaterialType_M.ToViewModel(material,id));
        }
        [HttpPost]
        public ActionResult AddAttrsToMaterialType(AddAttrsToMaterialType_M model)
        {
            try
            {
                var record = _qxIJzxtService.FindMTA(model.materialtypeid, model.materialattrid);
                if (!record)//不存在该条记录
                {
                    var result = _material_type_attrs.Add(model.ToModel(DateTime.Now.Random()));
                    return result.HasValue()? Redirect("/QxJzxt/AutoReport/MaterialTypeAttrsList?Params=" + model.materialtypeid) : Alert("添加失败");
                }
                else
                {
                    return Alert("已添加过该属性，请重新选择添加");
                }
            }
            catch (FormValitationException ex)
            {
                FormValitation = ex;
                InitForm("添加到材料类型");
                var material = _material_type.ToSelectItems();
                return View(AddAttrsToMaterialType_M.ToViewModel(material, model.materialattrid));
            }
        }
        // QxJzxt/CRUD/AddMaterialAttrs
        public ActionResult AddMaterialAttrs()
        {
            InitForm("添加材料属性");
            return View(AddMaterialAttrs_M.ToViewModel(_qxIJzxtService.TypeList()));
        }
        [HttpPost]
        public ActionResult AddMaterialAttrs(AddMaterialAttrs_M model)
        {
            try
            {
                var result = _material_attrs.Add(model.ToModel(DateTime.Now.Random()));
                return result.HasValue() ? RedirectToAction("MaterialAttrsList", "AutoReport",
                    new { area = "QxJzxt", reportId = "Qx.Jzxt.材料属性", Params = ";" }) : Alert("添加失败");
            }
            catch (FormValitationException ex)
            {
                FormValitation = ex;
                InitForm("添加材料属性");
                return View(AddMaterialAttrs_M.ToViewModel(_qxIJzxtService.TypeList()));
            }
        }
        // QxJzxt/CRUD/DeleteMaterialAttrs
        public ActionResult DeleteMaterialAttrs(string attrid)
        {
            try
            {
                return attrid.HasValue() ? Alert(_material_attrs.Delete(attrid) ? "删除成功" : "删除失败") : Alert("删除失败,传入参数出错");
            }
            catch (FormValitationException ex)
            {
                FormValitation = ex;
                return RedirectToAction("MaterialAttrsList", "AutoReport",
                    new { area = "QxJzxt", reportId = "Qx.Jzxt.材料属性", Params = ";" });
            }
        }
        // QxJzxt/CRUD/EditMaterialAttrs
        public ActionResult EditMaterialAttrs(string attrid)
        {
            InitForm("编辑材料属性");
            var attr = _material_attrs.Find(attrid);
            var typelist = _qxIJzxtService.TypeList();
            return View(EditMaterialAttrs_M.ToViewModel(attr, typelist));
        }

        [HttpPost]
        public ActionResult EditMaterialAttrs(EditMaterialAttrs_M model)
        {
            try
            {
                var result = _material_attrs.Update(model.ToModel(model.materialattrid));
                return result
                    ? RedirectToAction("MaterialAttrsList", "AutoReport",
                        new { area = "QxJzxt", reportId = "Qx.Jzxt.材料属性", Params = ";" })
                    : Alert("更新失败");
            }
            catch (FormValitationException ex)
            {
                FormValitation = ex;
                InitForm("编辑材料属性");
                var attr = _material_attrs.Find(model.materialattrid);
                var typelist = _qxIJzxtService.TypeList();
                return View(EditMaterialAttrs_M.ToViewModel(attr, typelist));
            }
        }
        #endregion

        #region AwardTypeBaseInfo 奖项类型基本信息
        // QxJzxt/CRUD/DeleteATBI 删除奖项类型基本信息
        public ActionResult DeleteATBI(string id)
        {
            return id.HasValue() ? Alert(_award_type_baseInfo.Delete(id) ? "删除成功" : "删除失败") : Alert("删除失败，传入参数出错");
        }

        // QxJzxt/CRUD/EditATBI 编辑奖项类型基本信息（次序）
        public ActionResult EditATBI(string id)
        {
            if (id.HasValue())
            {
                var data = _award_type_baseInfo.Find(id);
                InitForm("编辑次序");
                return View(EditATBI_M.ToViewModel(data));
            }
            else
            {
                return Alert("参数请求错误");
            }
        }
        [HttpPost]
        public ActionResult EditATBI(EditATBI_M model)
        {
            try
            {
                var result = _award_type_baseInfo.Update(model.ToModel());
                return result
                    ? Redirect("/QxJzxt/AutoReport/AwardBaseInfoList?Params=" + model.awardtypeid)
                    : Alert("更新失败");
            }
            catch (FormValitationException ex)
            {
                FormValitation = ex;
                var data = _award_type_baseInfo.Find(model.awardtypebaseinfoid);
                return View(EditATBI_M.ToViewModel(data));
            }
        }
        #endregion

        #region material_type_attrs 材料类型属性
        // QxJzxt/CRUD/DeleteMTA 删除材料类型属性
        public ActionResult DeleteMTA(string id)
        {
            return Alert(_material_type_attrs.Delete(id) ? "删除成功" : "删除失败");
        }
        // QxJzxt/CRUD/EditMTA 编辑材料类型属性  只能改顺序
        public ActionResult EditMTA(string id)
        {
            InitForm("编辑材料属性项");
            var mta = _material_type_attrs.Find(id);
            var materialtype = mta.material_type.typename;
            var attrname = mta.material_attrs.attrname;
            return View(EditMTA_M.ToViewModel(materialtype, attrname, mta));
        }

        [HttpPost]
        public ActionResult EditMTA(EditMTA_M model)
        {
            try
            {
                var result = _material_type_attrs.Update(model.ToModel(model.materialtypeattrid));
                return result
                    ? Redirect("/QxJzxt/AutoReport/MaterialTypeAttrsList?Params=" + model.materialtypeid)
                    : Alert("更新失败");
            }
            catch (FormValitationException ex)
            {
                FormValitation = ex;
                InitForm("编辑材料属性项");
                var mta = _material_type_attrs.Find(model.materialtypeattrid);
                var materialtype = mta.material_type.typename;
                var attrname = mta.material_attrs.attrname;
                return View(EditMTA_M.ToViewModel(materialtype, attrname, mta));
            }
        }

        #endregion

        #region AwardMaterial 奖项材料

        public ActionResult DeleteAwardMaterial(string id)
        {
             return id.HasValue() ? Alert(_award_material.Delete(id) ? "删除成功" : "删除失败") : Alert("删除失败");
        }

        #endregion

        #region award_instance 奖项实例
        // QxJzxt/CRUD/AddAwardInstance
        public ActionResult AddAwardInstance(string awardtypeid)
        {
            if (awardtypeid.HasValue())
            {
                InitForm("添加实施奖项");
                var data = _award_type.Find(awardtypeid);
                var awardtypebaseInfolist = _qxIJzxtService.FindATBList(awardtypeid);
                if (awardtypebaseInfolist.Count == 0)
                    return Alert("该奖项暂无基本信息，请先去“查看基本信息项”添加基本信息！");
                else
                    return View(AddAwardInstance_M.ToViewModel(data, awardtypeid, awardtypebaseInfolist));
            }
            else
            {
                return Alert("参数请求错误");
            }
        }
        [HttpPost]
        public ActionResult AddAwardInstance(AddAwardInstance_M model)
        {
            try
            {
                var result= _qxIJzxtService.AddAwardInstanceAndBaseinfoAndMaterial(model.ToModel(DateTime.Now.Random()));
                    return result? RedirectToAction("AwardInstanceList", "AutoReport",
                        new { area = "QxJzxt", reportId = "Qx.Jzxt.奖项实例", Params = ";" }) : Alert("添加失败");                     
            }
            catch (FormValitationException ex)
            {
                FormValitation = ex;
                InitForm("添加实施奖项");
                return View(model);
            }
        }
        // QxJzxt/CRUD/DeleteAwardInstance
        public ActionResult DeleteAwardInstance(string instanceid)
        {
            if (instanceid.HasValue())
            {
                if (!_qxIJzxtService.FindAwardInstanceAboutBatch(instanceid))
                {
                    //  return !_qxIJzxtService.FindAwardInstanceApplyRecord(instanceid) ? Alert(_award_instance.Delete(instanceid) ? "删除成功" : "删除失败") : Alert("已有学生申请，不能删除该实施奖项");
                    return Alert(_award_instance.Delete(instanceid) ? "删除成功" : "删除失败");
                }
                else
                {
                    return Alert("该实施奖项已经跟某一个具体的奖项批次有联系，不能删除，如想要删除，请先查找到有关奖项批次里面的该实施奖项，从该奖项批次里面移除，再次删除该实施奖项，即可");
                }
            }
            else
            {
                return Alert("参数请求出错");
            }
        }
        // QxJzxt/CRUD/EditAwardInstance
        public ActionResult EditAwardInstance(string instanceid)
        {
            InitForm("编辑实施奖项");
            var instance = _award_instance.Find(instanceid);
            var awardtype = _award_type.ToSelectItems();
            return View(EditAwardInstance_M.ToViewModel(instance, awardtype));
        }

        [HttpPost]
        public ActionResult EditAwardInstance(EditAwardInstance_M model)
        {
            try
            {
                var result = _award_instance.Update(model.ToModel(model.instanceid));
                return result
                    ? RedirectToAction("AwardInstanceList", "AutoReport",
                        new { area = "QxJzxt", reportId = "Qx.Jzxt.奖项实例", Params = ";" })
                    : Alert("更新失败");
            }
            catch (FormValitationException ex)
            {
                FormValitation = ex;
                InitForm("编辑实施奖项");
                var instance = _award_instance.Find(model.instanceid);
                var awardtype = _award_type.ToSelectItems();
                return View(EditAwardInstance_M.ToViewModel(instance, awardtype));
            }
        }

        // QxJzxt/CRUD/DetailAwardInstance
        public ActionResult DetailAwardInstance(string instanceid)
        {
            InitForm("实施奖项详情");
            var instance = _award_instance.Find(instanceid);
            return View(DetailAwardInstance_M.ToViewModel(instance));
        }

        // QxJzxt/CRUD/ChangeStatus
        public ActionResult ChangeStatus(string instanceid, string flag)
        {
            if (instanceid.HasValue() && flag.HasValue())
            {
                var result = _qxIJzxtService.ChangeAwardInstanceStatus(instanceid, flag);
                return Alert(result ? "操作成功" : "操作失败");
            }
            else
            {
                return Alert("参数请求错误");
            }
        }

        #endregion

        #region AwardBatchInstance 奖项批次实例
        // QxJzxt/CRUD/AddAwardInstanceToBatch
        public ActionResult AddAwardInstanceToBatch(string id)
        {
            InitForm("添加实施奖项到批次");
            var batch = _award_batch.ToSelectItems();
            return View(AddAwardInstanceToBatch_M.ToViewModel(id, batch));
        }
        [HttpPost]
        public ActionResult AddAwardInstanceToBatch( AddAwardInstanceToBatch_M model)
        {
            try
            {
                //return _qxIJzxtService.FindABI(model.batchid, model.instanceid)
                //    ? Alert("已经添加过该条记录，请重新选择！")
                //    : Alert(_award_batch_instance.Add(model.ToModel(DateTime.Now.Random())).HasValue() ? "添加成功" : "添加失败");
                var record = _qxIJzxtService.FindABI(model.batchid, model.instanceid);
                if (!record)
                {
                    var result = _award_batch_instance.Add(model.ToModel(DateTime.Now.Random()));
                    return result.HasValue() ? Alert("添加成功") : Alert("添加失败");
                }
                else
                {
                    return Alert("已经添加过该条记录，请重新选择！");
                }
            }
            catch (FormValitationException ex)
            {
                FormValitation = ex;
                InitForm("添加实施奖项到批次");
                var list = _award_batch.ToSelectItems();
                return View(AddAwardInstanceToBatch_M.ToViewModel(model.instanceid, list));
            }
        }

        // QxJzxt/CRUD/AddAwardInstanceFromBatch
        public ActionResult AddAwardInstanceFromBatch(string id)
        {
            InitForm("添加实施奖项到批次");
            int index = id.IndexOf('!');
            if (index > 0)
            {
                id = id.Substring(0, index);
            }
            var instance = _award_instance.ToSelectItems();
            return View(AddAwardInstanceFromBatch_M.ToViewModel(instance, id));
        }

        [HttpPost]
        public ActionResult AddAwardInstanceFromBatch(AddAwardInstanceFromBatch_M model)
        {
            try
            {
                //return _qxIJzxtService.FindABI(model.batchid, model.instanceid)
                //    ? Alert("已经添加过该条记录，请重新选择！")
                //    : Alert(_award_batch_instance.Add(model.ToModel(DateTime.Now.Random())).HasValue() ? "添加成功" : "添加失败");
                var record = _qxIJzxtService.FindABI(model.batchid, model.instanceid);
                if (!record)
                {
                    var result = _award_batch_instance.Add(model.ToModel(DateTime.Now.Random()));
                    return result.HasValue() ? Redirect("/QxJzxt/AutoReport/BatchAwardInstanceList?Params="+model.batchid) : Alert("添加失败");
                }
                else
                {
                    return Alert("已经添加过该条记录，请重新选择！");
                }
            }
            catch (FormValitationException ex)
            {
                FormValitation = ex;
                InitForm("添加实施奖项到批次");
                var instance = _award_batch.ToSelectItems();
                return View(AddAwardInstanceFromBatch_M.ToViewModel(instance, model.batchid));
            }
        }
        // QxJzxt/CRUD/DeleteBatchAwardInstance
        public ActionResult DeleteBatchAwardInstance(string id)
        {
            if (id.HasValue())
            {
                return !_qxIJzxtService.FindAwardInstanceApplyRecord(id) ? Alert(_award_batch_instance.Delete(id) ? "删除成功" : "删除失败") : Alert("已有学生申请，不能删除该实施奖项");
            }
            else
            {
                return Alert("参数请求错误");
            }
        }

        #endregion

        #region award_instance_material 奖项材料实例
        // QxJzxt/CRUD/AddMaterialToAwardInstance
        public ActionResult AddMaterialToAwardInstance(string id)
        {
            var index = id.IndexOf('!');
            id = id.Substring(0, index);
            InitForm("添加材料到奖项实例");
            var materialtype = _material_type.ToSelectItems();
            return View(AddMaterialToAwardInstance_M.ToViewModel(materialtype, id));
        }
        [HttpPost]
        public ActionResult AddMaterialToAwardInstance(AddMaterialToAwardInstance_M model)
        {
            try
            {
                var record=_qxIJzxtService.FindAMI(model.materialtypeid, model.instanceid);
                if (!record)
                {
                    var result = _award_materia_instance.Add(model.ToModel(DateTime.Now.Random()));
                    return result.HasValue()
                        ? Redirect("/QxJzxt/AutoReport/AwardInstanceMaterialList?Params=" + model.instanceid)
                        : Alert("返回失败");
                }
                else
                {
                    return Alert("该材料已经添加，请重新选择！");
                }             
            }
            catch (FormValitationException ex)
            {
                FormValitation = ex;
                InitForm("添加材料到奖项实例");
                var materialtype = _material_type.ToSelectItems();
                return View(AddMaterialToAwardInstance_M.ToViewModel(materialtype, model.instanceid));
            }
        }

        // QxJzxt/CRUD/EditAwardInstanceMaterial
        public ActionResult EditAwardInstanceMaterial(string awardmaterialinstanceid)
        {
            if (awardmaterialinstanceid.HasValue())
            {             
                var data = _award_materia_instance.Find(awardmaterialinstanceid);
                InitForm("编辑奖项所需材料");
                return View(EditAwardInstanceMaterial_M.ToViewModel(data, awardmaterialinstanceid));
            }
            else
            {
                return Alert("参数请求错误");
            }
        }
        [HttpPost]
        public ActionResult EditAwardInstanceMaterial(EditAwardInstanceMaterial_M model)
        {
            try
            {
                var data = _award_materia_instance.Find(model.awardmaterialinstanceid);
                data.count = model.count;
                var result = _award_materia_instance.Update(data);
                return result
                    ? Redirect("/QxJzxt/AutoReport/AwardInstanceMaterialList?Params=" + data.instanceid)
                    : Alert("返回失败");
            }
            catch (FormValitationException ex)
            {
                FormValitation = ex;
                var data = _award_materia_instance.Find(model.awardmaterialinstanceid);
                InitForm("编辑奖项所需材料");
                return View(EditAwardInstanceMaterial_M.ToViewModel(data, model.awardmaterialinstanceid));
            }
        }

        // QxJzxt/CRUD/DeleteAwardInstanceMaterial
        public ActionResult DeleteAwardInstanceMaterial(string id)
        {
            try
            {
                return id.HasValue() ? Alert(_award_materia_instance.Delete(id) ? "删除成功" : "删除失败") : Alert("参数出错，删除失败");
            }
            catch (FormValitationException ex)
            {
                FormValitation = ex;
                return Alert(_award_materia_instance.Delete(id) ? "删除成功" : "删除失败");
            }
           
        }

        #endregion

        #region AddAwardInstanceBaseInfo 奖项实例基本信息
        // QxJzxt/CRUD/AddAwardInstanceBaseInfo
        public ActionResult AddAwardInstanceBaseInfo(string id)
        {
            if (id.HasValue())
            {
                var index = id.IndexOf('!');
                id = id.Substring(0, index);
                var baseinfo = _award_baseInfo.ToSelectItems();
                InitForm("添加实施奖项基本信息");
                return View(AddAwardInstanceBaseInfo_M.ToViewModel(baseinfo, id));
            }
            else
            {
               return Alert("参数请求错误!");
            }
            
        }
        [HttpPost]
        public ActionResult AddAwardInstanceBaseInfo(AddAwardInstanceBaseInfo_M model)
        {
            try
            {
                var record = _qxIJzxtService.FindAIB(model.baseInfoid, model.instanceid);
                if (!record)
                {
                    var result = _award_instance_baseInfo.Add(model.ToModel(DateTime.Now.Random()));
                    return result.HasValue() ? Redirect("/QxJzxt/AutoReport/AwardInstanceBaseInfoList?Params="+model.instanceid) : Alert("添加失败");
                }
                else
                {
                    return Alert("该基本信息已经添加，请重新选择");
                }
            }
            catch (FormValitationException ex)
            {
                FormValitation = ex;
                var baseinfo = _award_baseInfo.ToSelectItems();
                InitForm("添加实施奖项基本信息");
                return View(AddAwardInstanceBaseInfo_M.ToViewModel(baseinfo, model.instanceid));
            }
        }

        //QxJzxt/CRUD/DeleteAwardInstanceBaseInfo      
        public ActionResult DeleteAwardInstanceBaseInfo(string id)
        {
            var result=_award_instance_baseInfo.Delete(id);
            if (result)
                return Alert("删除成功！");
            return Alert("删除失败！");
        }

        // QxJzxt/CRUD/EditAwardInstanceBaseInfo 编辑实施奖项基本信息的次序
        public ActionResult EditAwardInstanceBaseInfo(string id)
        {
            if (id.HasValue())
            {
                var data = _award_instance_baseInfo.Find(id);
                InitForm("编辑实施奖项基本信息次序");
                return View(EditAwardInstanceBaseInfo_M.ToViewModel(data));
            }
            else
            {
                return Alert("参数请求错误!");
            }
        }
        [HttpPost]
        public ActionResult EditAwardInstanceBaseInfo(EditAwardInstanceBaseInfo_M model)
        {
            try
            {
                var result = _award_instance_baseInfo.Update(model.ToModel());
                return result ? Redirect("/QxJzxt/AutoReport/AwardInstanceBaseInfoList?Params=" + model.instanceid) : Alert("编辑失败");
            }
            catch (FormValitationException ex)
            {
                FormValitation = ex;
                var data = _award_instance_baseInfo.Find(model.instancebaseinfoid);
                InitForm("编辑实施奖项基本信息次序");
                return View(EditAwardInstanceBaseInfo_M.ToViewModel(data));
            }
        }

        #endregion

        #region AddMyMeterial 填写用户材料
        //QxJzxt/CRUD/AddMyMeterial
        public ActionResult AddMyMaterial(string materialtypeid)
        {
            if (materialtypeid.HasValue())
            {
                InitForm("添加我的材料");
                var materialattrlist = _qxIJzxtService.FindMAList(materialtypeid);
                return View(AddMyMaterial_M.ToViewModel(materialtypeid, materialattrlist));
            }
            else
            {
                return Alert("参数请求错误");
            }
        }
        [HttpPost]
        public ActionResult AddMyMaterial(AddMyMaterial_M model, string user_material_name,List<string> materialtypeattrid,List<string> attrValue)
        {
            try
            {
                List<MaterialValue> materialValues=new List<MaterialValue>();
                for (int i = 0; i < materialtypeattrid.Count; i++)
                {
                    MaterialValue materialValue=new MaterialValue();
                    materialValue.materialtypeattrid = materialtypeattrid[i];
                    materialValue.materialvalue = attrValue[i];
                    materialValues.Add(materialValue);
                }
                var result = _qxIJzxtService.AddUserMaterialAndMaterialValue(DataContext.UserID,model.materialtypeid, user_material_name, materialValues);
                return result ? Redirect("/QxJzxt/AutoReport/MyMaterialApplyList") : Alert("添加失败，请重新添加");
            }
            catch (FormValitationException ex)
            {
                FormValitation = ex;
                InitForm("添加我的材料");
                var materialattrlist = _qxIJzxtService.FindMAList(model.materialtypeid);
                return View(AddMyMaterial_M.ToViewModel(model.materialtypeid,materialattrlist));
            }
        }
        #endregion

        #region DeleteMyMaterialApply 删除我的材料申请
        //QxJzxt/CRUD/DeleteMyMaterialApply
        public ActionResult DeleteMyMaterialApply(string id)
        {
            return id.HasValue() ? Alert(_user_material.Delete(id) ? "删除成功" : "删除失败") : Alert("删除失败");
        }

        #endregion

        #region EditMyMaterialApply 编辑我的材料申请
        //QxJzxt/CRUD/EditMyMaterialApply
        public ActionResult EditMyMaterialApply(string id)
        {
            if (id.HasValue())
            {
                var materialApply = _qxIJzxtService.MaterialAttrAndValue(id);
                InitForm("编辑材料");
                return View(EditMyMaterialApply_M.ToViewModel(id,materialApply));
            }
            else
            {
                return Alert("参数请求错误");
            }
        }
        [HttpPost]
        public ActionResult EditMyMaterialApply(EditMyMaterialApply_M model,string user_material_name,List<string> marterialvaluesid,List<string> attrValue)
        {
            try
            {
                var result = _qxIJzxtService.ReEditMaterialValue(user_material_name,model.usermaterialid,marterialvaluesid, attrValue);
                return result ? Redirect("/QxJzxt/AutoReport/MyMaterialApplyList") : Alert("编辑失败，请重新编辑");
            }
            catch (FormValitationException ex)
            {
                FormValitation = ex;
                var materialApply = _qxIJzxtService.MaterialAttrAndValue(model.usermaterialid);
                InitForm("编辑材料");
                return View(EditMyMaterialApply_M.ToViewModel(model.usermaterialid, materialApply));
            }
        }
        #endregion

        #region SubmitMaterialApply 提交材料申请
        //QxJzxt/CRUD/SubmitMaterialApply
        public ActionResult SubmitMaterialApply(string id)
        {
            return id.HasValue()?Alert(_qxIJzxtService.SubmitMyMaterialApply(id)?"提交成功，等待管理员审核":"提交失败"):
            Alert("参数错误，提交失败");
        }
        #endregion

        #region DetailMaterialApply 材料申请详情
        //QxJzxt/CRUD/DetailMaterialApply
        public ActionResult DetailMaterialApply(string id)
        {
            if (id.HasValue())
            {
                var valueDetail = _qxIJzxtService.MaterialAttrAndValue(id);
                var applydetail = _qxIJzxtService.MaterialApplyDetail(id);
                InitForm("材料申请详情",false);
                return View(DetailMaterialApply_M.ToViewModel(valueDetail, applydetail));
            }
            else
            {
                return Alert("参数请求错误");
            }
        }

        [HttpPost]
        public ActionResult DetailMaterialApply(DetailMaterialApply_M model,string usermaterialid,string opinion,string but_name)
        {
            try
            {
                if (but_name =="2") //审核通过
                {
                    var data = _user_material.Find(usermaterialid);
                    data.opinion = opinion;
                    data.statusid = 2;
                    data.examine_time = DateTime.Now;
                    data.examine_person = DataContext.UserID;
                    var result = _user_material.Update(data);
                    return result ? Alert("审核完成，审核通过") : Alert("审核失败，请重新审核");
                }
               else //审核不通过
                {
                    var data = _user_material.Find(usermaterialid);
                    data.opinion = opinion;
                    data.statusid = 3;
                    data.examine_time = DateTime.Now;
                    data.examine_person = DataContext.UserID;
                    var result = _user_material.Update(data);
                    return result ? Alert("审核完成，审核不通过") : Alert("审核失败，请重新审核");
                }
            }
            catch (FormValitationException ex)
            {
                FormValitation = ex;
                var valueDetail = _qxIJzxtService.MaterialAttrAndValue(usermaterialid);
                var applydetail = _qxIJzxtService.MaterialApplyDetail(usermaterialid);
                InitForm("材料申请详情", false);
                return View(DetailMaterialApply_M.ToViewModel(valueDetail, applydetail));
            }
        }

        #endregion

        #region WriteAwardBaseInfoValue 填写奖项基本信息
        //QxJzxt/CRUD/DetailMaterialApply
        public ActionResult WriteAwardBaseInfoValue(string instanceid,string batchinstanceid)
        {
            if (instanceid.HasValue() && batchinstanceid.HasValue())
            {
                if (!_qxIJzxtService.FindUserAwardApplyRecord(DataContext.UserID, batchinstanceid))
                {
                    var data = _qxIJzxtService.GetAwardInstanceBaseInfo(instanceid);
                    InitForm("填写基本信息");
                    return View(WriteAwardBaseInfoValue_M.ToViewModel(instanceid, batchinstanceid, data));
                }
                else
                {
                    return Alert("你已经申请过该奖项了，不能重复申请");
                }
            }
            else
            {
                return Alert("参数请求错误");
            }
        }
        [HttpPost]
        public ActionResult WriteAwardBaseInfoValue(WriteAwardBaseInfoValue_M model,List<string> instancebaseinfoid,List<string> baseinfoValue)
        {
            try
            {
                var result = _qxIJzxtService.AddAwardapplyFormBaseInfo(DataContext.UserID, model.instanceid, model.batchinstanceid, instancebaseinfoid, baseinfoValue);
                return result ? Redirect("/QxJzxt/AutoReport/MyAwardApplyList") : Alert("添加失败，请重新添加");
            }
            catch (FormValitationException ex)
            {
                FormValitation = ex;
                var data = _qxIJzxtService.GetAwardInstanceBaseInfo(model.instanceid);
                InitForm("填写基本信息");
                return View(WriteAwardBaseInfoValue_M.ToViewModel(model.instanceid, model.batchinstanceid, data));
            }
        }
        #endregion

        #region  AwardInstanceDistributionToOrg  把奖项实例分配给学院
        //QxJzxt/CRUD/AwardInstanceDistributionToOrg
        public ActionResult AwardInstanceDistributionToOrg(string batchinstanceid)
        {
            if (batchinstanceid.HasValue())
            {
                InitForm("分配实施奖项给学院",false);
                var allCollege = _qxIJzxtService.GetAllCollege();
                var DistributionList = _qxIJzxtService.GetDistributionList(batchinstanceid);
                var award_batch_instance = _award_batch_instance.Find(batchinstanceid);//奖项名额总数
                return View(AwardInstanceDistributionToOrg_M.ToViewModel(batchinstanceid, allCollege, award_batch_instance, DistributionList));
            }
            else
            {
                return Alert("参数请求错误");
            }
        }
        [HttpPost]
        public ActionResult AwardInstanceDistributionToOrg(AwardInstanceDistributionToOrg_M model,List<string> orgid,List<int> count,List<string> orgawardinstanceid)
        {
            try
            {
                int allcount = 0;
                for (int i = 0; i < count.LongCount(); i++)
                {
                    allcount += count[i];
                }
                if (allcount == model.total_count)
                {
                    if (orgawardinstanceid!=null)//更新分配
                    {
                        var result = _qxIJzxtService.AwardInstanceDistributionToOrgUpdate(count, orgawardinstanceid);
                        return result ? Alert("重新分配成功") : Alert("重新分配失败，请重新填写");
                    }
                    else//第一次分配名额
                    {
                        var result = _qxIJzxtService.AwardInstanceDistributionToOrg(model.batchinstanceid, orgid, count);
                        return result ? Alert("分配成功") : Alert("添加失败，请重新添加");
                    }
                }
                else
                {
                    return Alert("总共分配 "+allcount+" 个名额，所分配的奖项名额总数与实际的不符，请重新检查填写");
                }
            }
            catch (FormValitationException ex)
            {
                FormValitation = ex;
                InitForm("分配实施奖项给学院", false);
                var allCollege = _qxIJzxtService.GetAllCollege();
                var DistributionList = _qxIJzxtService.GetDistributionList(model.batchinstanceid);
                var award_batch_instance = _award_batch_instance.Find(model.batchinstanceid);//奖项名额总数
                return View(AwardInstanceDistributionToOrg_M.ToViewModel(model.batchinstanceid, allCollege, award_batch_instance, DistributionList));
            }
        }
        #endregion

        #region  UpdateDistributionCount 更新分配给学院的数量
        //QxJzxt/CRUD/UpdateDistributionCount
        public ActionResult UpdateDistributionCount(string orgawardinstanceid)
        {
            if (orgawardinstanceid.HasValue())
            {
                var data = _org_award_instance.Find(orgawardinstanceid);
                InitForm("更新分配名额");
                return View(UpdateDistributionCount_M.ToViewModel(orgawardinstanceid,data.count));
            }
            else
            {
                return Alert("参数请求错误");
            }
        }
        [HttpPost]
        public ActionResult UpdateDistributionCount(UpdateDistributionCount_M model)
        {
            try
            {
                var data = _org_award_instance.Find(model.orgawardinstanceid);
                data.count = model.count;
                    var result = _org_award_instance.Update(data);
                    return result ? Redirect("/QxJzxt/AutoReport/OrgAwardInstanceList?Params=" + data.orgid) : Alert("添加失败，请重新添加");        
            }
            catch (FormValitationException ex)
            {
                FormValitation = ex;
                InitForm("更新分配名额");
                return View(UpdateDistributionCount_M.ToViewModel(model.orgawardinstanceid,model.count));
            }
        }
        #endregion

        #region DeleteDistribution 删除分配
        //QxJzxt/CRUD/DeleteDistribution
        public ActionResult DeleteDistribution(string id,string batchinstanceid)
        {
            if (id.HasValue())
            {
                return !_qxIJzxtService.FindAwardInstanceApplyRecord(batchinstanceid) ? Alert(_org_award_instance.Delete(id) ? "删除成功" : "删除失败") : Alert("已有学生申请该奖项，不能删除");
            }
            else
            {
                return Alert("参数请求错误");
            }
        }
        #endregion

        #region  AddOrg 添加学院
        //QxJzxt/CRUD/AddOrg
        public ActionResult AddOrg()
        {
                InitForm("添加学院");
                return View();
        }
        [HttpPost]
        public ActionResult AddOrg(AddOrg_M model)
        {
            try
            {
                var result = _org.Add(model.ToModel());
                return result.HasValue() ? Redirect("/QxJzxt/AutoReport/OrgList") : Alert("添加失败，请重新添加");
            }
            catch (FormValitationException ex)
            {
                FormValitation = ex;
                InitForm("添加学院");
                return View(model);
            }
        }
        #endregion

        #region  EditOrg 编辑学院
        //QxJzxt/CRUD/EditOrg
        public ActionResult EditOrg(string id)
        {
            if (id.HasValue())
            {
                var data = _org.Find(id);
                InitForm("编辑学院");
                return View(EditOrg_M.ToViewModel(id,data));
            }
            else
            {
                return Alert("参数请求错误");
            }
        }
        [HttpPost]
        public ActionResult EditOrg(EditOrg_M model)
        {
            try
            {
                var data = _org.Find(model.orgid);
                data.orgname = model.orgname;
                data.description = model.description;
                var result = _org.Update(data);
                return result ? Redirect("/QxJzxt/AutoReport/OrgList") : Alert("编辑失败，请重新编辑");
            }
            catch (FormValitationException ex)
            {
                FormValitation = ex;
                InitForm("编辑学院");
                var data = _org.Find(model.orgid);
                return View(EditOrg_M.ToViewModel(model.orgid, data));
            }
        }
        #endregion

        #region  DetailOrg 学院详情
        //QxJzxt/CRUD/DetailOrg
        public ActionResult DetailOrg(string id)
        {
            if (id.HasValue())
            {
                var data = _org.Find(id);
                InitForm("学院详情");
                return View(DetailOrg_M.ToViewModel(id, data));
            }
            else
            {
                return Alert("参数请求错误");
            }
        }
        #endregion

        #region  DeleteOrg 删除学院
        //QxJzxt/CRUD/DeleteOrg
        public ActionResult DeleteOrg(string id)
        {
            if (id.HasValue())
            {
                return !_qxIJzxtService.FindOrgDistributionRecord(id) ? Alert(_org.Delete(id) ? "删除成功" : "删除失败") : Alert("该学院已经有分配的奖项，不能删除");
            }
            else
            {
                return Alert("参数请求错误");
            }          
        }
        #endregion

        #region  MaterialExaminePass 资料审核通过
        //QxJzxt/CRUD/MaterialExaminePass
        public ActionResult MaterialExaminePass(string id)
        {
            if (id.HasValue())
            {
                var data = _user_material.Find(id);
                InitForm("审核资料");
                return View(MaterialExaminePass_M.ToViewModel(data));
            }
            else
            {
                return Alert("参数请求错误");
            }
        }
        [HttpPost]
        public ActionResult MaterialExaminePass(MaterialExaminePass_M model)
        {
            try
            {
                var data = _user_material.Find(model.usermaterialid);
                data.opinion = model.opinion;
                data.statusid = 2;
                data.examine_time = DateTime.Now;
                var result = _user_material.Update(data);
                return result ? Redirect("/QxJzxt/AutoReport/CollegeMaterialExamineList") : Alert("审核失败，请重新审核");
            }
            catch (FormValitationException ex)
            {
                FormValitation = ex;
                var data = _user_material.Find(model.usermaterialid);
                InitForm("审核资料");
                return View(MaterialExaminePass_M.ToViewModel(data));
            }
        }
        #endregion

        #region  MaterialExamineNoPass 资料审核不通过
        //QxJzxt/CRUD/MaterialExamineNoPass
        public ActionResult MaterialExamineNoPass(string id)
        {
            if (id.HasValue())
            {
                var data = _user_material.Find(id);
                InitForm("审核资料");
                return View(MaterialExamineNoPass_M.ToViewModel(data));
            }
            else
            {
                return Alert("参数请求错误");
            }
        }
        [HttpPost]
        public ActionResult MaterialExamineNoPass(MaterialExamineNoPass_M model)
        {
            try
            {
                var data = _user_material.Find(model.usermaterialid);
                data.opinion = model.opinion;
                data.statusid = 3;//审核未通过
                data.examine_time = DateTime.Now;
                var result = _user_material.Update(data);
                return result ? Redirect("/QxJzxt/AutoReport/CollegeMaterialExamineList") : Alert("审核失败，请重新审核");
            }
            catch (FormValitationException ex)
            {
                FormValitation = ex;
                var data = _user_material.Find(model.usermaterialid);
                InitForm("审核资料");
                return View(MaterialExamineNoPass_M.ToViewModel(data));
            }
        }
        #endregion

        #region AwardMaterialList 奖项所需材料
        //QxJzxt/CRUD/AwardMaterialList
        public ActionResult AwardMaterialList(string instanceid)
        {
            if (instanceid.HasValue())
            {
                InitForm("奖项所需材料");
                return View(AwardMaterialList_M.ToViewModel(_qxIJzxtService.AwardMaterialList(instanceid)));
            }
            else {
                return Alert("参数请求错误");
            }
        }
        #endregion

        #region  CollegeAwardExaminePass 学院奖项申请通过
        //QxJzxt/CRUD/CollegeAwardExaminePass
        public ActionResult CollegeAwardExaminePass(string applyid)
        {
            if (applyid.HasValue())
            {
                var data = _award_apply.Find(applyid);
                InitForm("学院审核");
                return View(CollegeAwardExaminePass_M.ToViewModel(applyid, data));
            }
            else
            {
                return Alert("参数请求错误");
            }
        }
        [HttpPost]
        public ActionResult CollegeAwardExaminePass(CollegeAwardExaminePass_M model)
        {
            try
            {
                var data = _award_apply.Find(model.applyid);
                data.statusid = 2;//学院审核通过
                data.mark = model.mark;
                data.squence = model.squence;
                data.college_opinion = model.college_opinion;
                data.college_examine_time = DateTime.Now;
                var result = _award_apply.Update(data);
                return result ? Redirect("/QxJzxt/AutoReport/CollegeAwardExamineList") : Alert("审核失败，请重新审核");
            }
            catch (FormValitationException ex)
            {
                FormValitation = ex;
                var data = _award_apply.Find(model.applyid);
                InitForm("学院审核");
                return View(CollegeAwardExaminePass_M.ToViewModel(model.applyid, data));
            }
        }
        #endregion

        #region  CollegeAwardExamineNoPass 学院奖项申请不通过
        //QxJzxt/CRUD/CollegeAwardExamineNoPass
        public ActionResult CollegeAwardExamineNoPass(string applyid)
        {
            if (applyid.HasValue())
            {
                var data = _award_apply.Find(applyid);
                InitForm("学院审核");
                return View(CollegeAwardExamineNoPass_M.ToViewModel(applyid, data));
            }
            else
            {
                return Alert("参数请求错误");
            }
        }
        [HttpPost]
        public ActionResult CollegeAwardExamineNoPass(CollegeAwardExamineNoPass_M model)
        {
            try
            {
                var data = _award_apply.Find(model.applyid);
                data.statusid = 3;//学院审核不通过
                data.mark = model.mark;
                data.squence = model.squence;
                data.college_opinion = model.college_opinion;
                data.college_examine_time = DateTime.Now;
                var result = _award_apply.Update(data);
                return result ? Redirect("/QxJzxt/AutoReport/CollegeAwardExamineList") : Alert("审核失败，请重新审核");
            }
            catch (FormValitationException ex)
            {
                FormValitation = ex;
                var data = _award_apply.Find(model.applyid);
                InitForm("学院审核");
                return View(CollegeAwardExamineNoPass_M.ToViewModel(model.applyid, data));
            }
        }
        #endregion

        #region  DetailCollegeAwardExamine 学院审核详情
        //QxJzxt/CRUD/DetailCollegeAwardExamine
        public ActionResult DetailCollegeAwardExamine(string applyid)
        {
            if (applyid.HasValue())
            {
                var data = _award_apply.Find(applyid);
                InitForm("学院审核详情");
                return View(DetailCollegeAwardExamine_M.ToViewModel(data));
            }
            else
            {
                return Alert("参数请求错误");
            }
        }
        #endregion

        #region  UptoSchool 上报学校
        //QxJzxt/CRUD/UptoSchool
        public ActionResult UptoSchool(string applyid)
        {
            if (applyid.HasValue())
            {
                var data = _award_apply.Find(applyid);
                data.statusid = 4;//上报学校（待学校审核）
                return _award_apply.Update(data) ? Alert("上报学校成功，等待学校管理员审核") : Alert("上报学校失败");
            }
            else
            {
                return Alert("参数请求错误");
            }
        }
        #endregion

        #region  SchoolAwardExaminePass 学校奖项申请通过
        //QxJzxt/CRUD/SchoolAwardExaminePass
        public ActionResult SchoolAwardExaminePass(string applyid)
        {
            if (applyid.HasValue())
            {
                var data = _award_apply.Find(applyid);
                InitForm("学校审核");
                return View(SchoolAwardExaminePass_M.ToViewModel(applyid, data));
            }
            else
            {
                return Alert("参数请求错误");
            }
        }
        [HttpPost]
        public ActionResult SchoolAwardExaminePass(SchoolAwardExaminePass_M model)
        {
            try
            {
                var data = _award_apply.Find(model.applyid);
                data.statusid = 5;//学校审核通过
                data.school_opinion = model.school_opinion;
                data.school_examine_time = DateTime.Now;
                var result = _award_apply.Update(data);
                return result ? Redirect("/QxJzxt/AutoReport/SchoolAwardExamineList") : Alert("审核失败，请重新审核");
            }
            catch (FormValitationException ex)
            {
                FormValitation = ex;
                var data = _award_apply.Find(model.applyid);
                InitForm("学校审核");
                return View(SchoolAwardExaminePass_M.ToViewModel(model.applyid, data));
            }
        }
        #endregion

        #region  SchoolAwardExamineNoPass 学校奖项申请不通过
        //QxJzxt/CRUD/SchoolAwardExamineNoPass
        public ActionResult SchoolAwardExamineNoPass(string applyid)
        {
            if (applyid.HasValue())
            {
                var data = _award_apply.Find(applyid);
                InitForm("学校审核");
                return View(SchoolAwardExamineNoPass_M.ToViewModel(applyid, data));
            }
            else
            {
                return Alert("参数请求错误");
            }
        }
        [HttpPost]
        public ActionResult SchoolAwardExamineNoPass(SchoolAwardExamineNoPass_M model)
        {
            try
            {
                var data = _award_apply.Find(model.applyid);
                data.statusid = 6;//学校审核不通过
                data.school_opinion = model.school_opinion;
                data.school_examine_time = DateTime.Now;
                var result = _award_apply.Update(data);
                return result ? Redirect("/QxJzxt/AutoReport/SchoolAwardExamineList") : Alert("审核失败，请重新审核");
            }
            catch (FormValitationException ex)
            {
                FormValitation = ex;
                var data = _award_apply.Find(model.applyid);
                InitForm("学校审核");
                return View(SchoolAwardExamineNoPass_M.ToViewModel(model.applyid, data));
            }
        }
        #endregion

        #region  DetailSchoolAwardExamine 学校审核详情
        //QxJzxt/CRUD/DetailSchoolAwardExamine
        public ActionResult DetailSchoolAwardExamine(string applyid)
        {
            if (applyid.HasValue())
            {
                var data = _award_apply.Find(applyid);
                InitForm("学校审核详情");
                return View(DetailSchoolAwardExamine_M.ToViewModel(data));
            }
            else
            {
                return Alert("参数请求错误");
            }
        }
        #endregion

        #region  UserApplyAward 学生申请奖项
        //QxJzxt/CRUD/UserApplyAward
        public ActionResult UserApplyAward(string instanceid,string batchinstanceid)
        {
            if (instanceid.HasValue()&& batchinstanceid.HasValue())
            {
                if (_qxIJzxtService.FindUserApplyRecord(DataContext.UserID, batchinstanceid))
                {
                    return Alert("你已经申请过该奖项，不能重复申请");
                }
                else
                {
                    var BaseInfoList = _qxIJzxtService.GetAwardInstanceBaseInfo(instanceid);//先取该奖项的基本信息项
                    var MaterialList = _qxIJzxtService.AwardMaterialList(instanceid);//再取该奖项的所需的材料
                    var UserMaterial = _qxIJzxtService.UserMaterialList(DataContext.UserID);//用户已经审核通过的材料
                    InitForm("我要申请",false);
                    return View(UserApplyAward_M.ToViewModel(instanceid, batchinstanceid, BaseInfoList, MaterialList, UserMaterial));
                }          
            }
            else
            {
                return Alert("参数请求出错");
            }        
        }
        [HttpPost]
        public ActionResult UserApplyAward(UserApplyAward_M  model, List<string> instancebaseinfoid, List<string> baseinfoValue, List<string> usermaterialid)
        {
            try
            {
                var result = _qxIJzxtService.AddUserApplyAward(DataContext.UserID, model.instanceid, model.batchinstanceid, instancebaseinfoid, baseinfoValue, usermaterialid);
                return result ? 
                    Redirect("/QxJzxt/AutoReport/MyAwardApplyList") 
                    : Alert("审核失败，请重新审核");
            }
            catch (FormValitationException ex)
            {
                FormValitation = ex;
                var BaseInfoList = _qxIJzxtService.GetAwardInstanceBaseInfo(model.instanceid);//先取该奖项的基本信息项
                var MaterialList = _qxIJzxtService.AwardMaterialList(model.instanceid);//再取该奖项的所需的材料
                var UserMaterial = _qxIJzxtService.UserMaterialList(DataContext.UserID);//用户已经审核通过的材料
                InitForm("我要申请");
                return View(UserApplyAward_M.ToViewModel(model.instanceid, model.batchinstanceid,BaseInfoList, MaterialList, UserMaterial));
            }
        }
        #endregion

        #region SubmitAwardApply 提交奖项申请（由学院管理员审核）
        //QxJzxt/CRUD/SubmitAwardApply
        public ActionResult SubmitAwardApply(string applyid)
        {
            if (applyid.HasValue())
            {
                var data = _award_apply.Find(applyid);
                data.statusid = 1;//待学院审核
                data.apply_time = DateTime.Now;
                return  Alert(_award_apply.Update(data)?"提交成功，等待学院管理员审核":"提交失败");
            }
            else
            {
                return Alert("参数请求错误");
            }     
        }
        #endregion

        #region DeleteAwardApply 删除奖项申请
        //QxJzxt/CRUD/DeleteAwardApply
        public ActionResult DeleteAwardApply(string applyid)
        {
            return applyid.HasValue()?Alert(_award_apply.Delete(applyid) ? "删除成功" : "删除失败"): Alert("参数请求错误");
        }
        #endregion

        #region  EditUserApplyAward 编辑学生申请奖项
        //QxJzxt/CRUD/EditUserApplyAward
        public ActionResult EditUserApplyAward(string applyid)
        {
            if (applyid.HasValue())
            {
                var data = _award_apply.Find(applyid);
                var BaseInfoValueList = _qxIJzxtService.GetAwardInstanceBaseInfoValue(applyid);//先取该奖项的基本信息项
                var MaterialList = _qxIJzxtService.AwardMaterialList(data.instanceid);//再取该奖项的所需的材料              
                var UserMaterialList = _qxIJzxtService.UserMaterialList(DataContext.UserID);//用户已有的资料列表
                var UserAwardMaterialList = _qxIJzxtService.UserAwardMaterialList(applyid);//用户奖项申请里面已有的资料列表
                InitForm("编辑我的申请",false);
                return View(EditUserApplyAward_M.ToViewModel(applyid, BaseInfoValueList, MaterialList, UserMaterialList,UserAwardMaterialList));
            }
            else
            {
                return Alert("参数请求出错");
            }
        }
        [HttpPost]
        public ActionResult EditUserApplyAward(EditUserApplyAward_M model, List<string> awardinstancevalueid, List<string> baseinfoValue,List<string> applymaterialid, List<string> usermaterialid)
        {
            try
            {
                var result = _qxIJzxtService.AddUserApplyAward(DataContext.UserID, model.instanceid, model.batchinstanceid, awardinstancevalueid, baseinfoValue, usermaterialid);
                return result ? Redirect("/QxJzxt/AutoReport/MyAwardApplyList") : Alert("审核失败，请重新审核");
            }
            catch (FormValitationException ex)
            {
                FormValitation = ex;
                var BaseInfoList = _qxIJzxtService.GetAwardInstanceBaseInfo(model.instanceid);//先取该奖项的基本信息项
                var MaterialList = _qxIJzxtService.AwardMaterialList(model.instanceid);//再取该奖项的所需的材料
                var UserMaterial = _qxIJzxtService.UserMaterialList(DataContext.UserID);//用户已经审核通过的材料
                InitForm("我要申请");
                return View(UserApplyAward_M.ToViewModel(model.instanceid, model.batchinstanceid, BaseInfoList, MaterialList, UserMaterial));
            }
        }
        #endregion

        #region  DetailUserApplyAward 学生申请奖项详情
        //QxJzxt/CRUD/DetailUserApplyAward
        public ActionResult DetailUserApplyAward(string applyid)
        {
            if (applyid.HasValue())
            {
                var data = _award_apply.Find(applyid);
                var BaseInfoValueList = _qxIJzxtService.GetAwardInstanceBaseInfoValue(applyid);//先取该奖项的基本信息项
                var MaterialList = _qxIJzxtService.AwardMaterialList(data.instanceid);//再取该奖项的所需的材料              
               // var UserMaterialList = _qxIJzxtService.UserMaterialList(DataContext.UserID);//用户已有的资料列表
                var UserAwardMaterialList = _qxIJzxtService.UserAwardMaterialList(applyid);//用户奖项申请里面已有的资料列表
                InitForm("我的申请详情", false);
                return View(DetailUserApplyAward_M.ToViewModel(applyid, BaseInfoValueList, MaterialList, UserAwardMaterialList));
            }
            else
            {
                return Alert("参数请求出错");
            }
        }
        #endregion

        #region DistributionTotalCount 分配奖项总名额
        //QxJzxt/CRUD/DistributionTotalCount
        public ActionResult DistributionTotalCount(string batchinstanceid)
        {
            if (batchinstanceid.HasValue())
            {
                InitForm("分配奖项总名额");
                var batch_instance = _award_batch_instance.Find(batchinstanceid);
                var batch = _award_batch.Find(_award_batch_instance.Find(batchinstanceid).batchid);
                var award_Instance = _award_instance.Find(_award_batch_instance.Find(batchinstanceid).instanceid);
                return View(DistributionTotalCount_M.ToViewModel(batch_instance,batch, award_Instance, batchinstanceid));
            }
            else
            {
                return Alert("参数请求错误");
            }
        }

        [HttpPost]
        public ActionResult DistributionTotalCount(DistributionTotalCount_M model)
        {
            try
            {
                return _award_batch_instance.Update(model.ToModel())
                    ? RedirectToAction("BatchAwardInstanceList",  "AutoReport",new { area="QxJzxt",Params =model.batchid})
                    :Alert("分配名额失败") ;
            }
            catch (FormValitationException ex)
            {
                FormValitation = ex;
                InitForm("分配奖项总名额");
                var batch_instance = _award_batch_instance.Find(model.batchinstanceid);
                var batch = _award_batch.Find(_award_batch_instance.Find(model.batchinstanceid).batchid);
                var award_Instance = _award_instance.Find(_award_batch_instance.Find(model.batchinstanceid).instanceid);
                return View(DistributionTotalCount_M.ToViewModel(batch_instance, batch, award_Instance, model.batchinstanceid));
            }
        }

        #endregion

     
    }
}