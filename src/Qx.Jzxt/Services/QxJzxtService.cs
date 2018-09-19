using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Qx.Jzxt.Entity;
using Qx.Jzxt.Interfaces;
using Qx.Jzxt.Model;
using Qx.Tools;
using Qx.Tools.CommonExtendMethods;

namespace Qx.Jzxt.Services
{
    public class QxJzxtService : BaseRepository, QxIJzxtService
    {
      
        //查看该奖项所分配的各学院名额
        public List<org_award_instance> GetDistributionList(string batchinstanceid)
        {
            return
                Db.org_award_instance.Where(o => o.batchinstanceid == batchinstanceid).ToList()
                    .Select(b => new org_award_instance()
                    {
                        orgawardinstanceid=b.orgawardinstanceid,
                        orgid = b.orgid,
                        batchinstanceid = b.batchinstanceid,
                        count = b.count
                    })
                    .ToList();
        }

        //所有学院组织机构
        public List<orgnization> GetAllCollege()
        {
            //查找学院级别的levelId
            var organizationLevel = Db.organization_level.FirstOrDefault(o => o.name.Contains("学院"));
            if (organizationLevel != null)
            {
                var levelid = organizationLevel.organization_level_id;
            }
            return
                Db.orgnization.Where(o => o.organization_level_id == organizationLevel.organization_level_id).ToList();
        }

        //所有奖项类型
        public List<SelectListItem> SearchAwardTypeSelect()
        {
            return Db.award_type.Select(b => new SelectListItem()
            {
                Value = b.awardtypeid,
                Text = b.awardname
            }).ToList();
        }

        //所有批次
        public List<SelectListItem> SearchBatchSelect()
        {
            return Db.award_batch.Select(b => new SelectListItem()
            {
                Value = b.batchid,
                Text = b.batchname
            }).ToList();
        }
        //所有的材料类型
        public List<SelectListItem> SearchMaterialTypeSelect()
        {
            return Db.material_type.Select(b => new SelectListItem()
            {
                Value = b.materialtypeid,
                Text = b.typename
            }).ToList();
        }

        //查找该奖项实例是否已经跟某一个具体的奖项批次有联系
        public bool FindAwardInstanceAboutBatch(string instanceid)
        {
            var data = Db.award_batch_instance.FirstOrDefault(o => o.instanceid == instanceid);
            return data != null ? true : false;
        }

        //查找该批次下面是否已经有相关的实施奖项
        public bool FindBatchAboutAwardInstance(string batchid)
        {
            var data = Db.award_batch_instance.FirstOrDefault(o => o.batchid == batchid);
            return data != null ? true : false;
        }
        
        //查看该材料类型是否已经加到相关的实施奖项里面
        public bool FindMaterialAboutAwardInstance(string materialtypeid)
        {
            var data = Db.award_materia_instance.FirstOrDefault(o => o.materialtypeid == materialtypeid);
            return data != null ? true : false;
        }

        //查找该奖项类型是否已经有创建相应的奖项实例
        public bool FindAwardInstanceAboutAwardType(string awardtypeid)
        {
            var data = Db.award_instance.FirstOrDefault(o => o.awardtypeid == awardtypeid);
            return data != null ? true : false;
        }

        //查找用户是否已经申请过该奖项
        public bool FindUserApplyRecord(string uid, string batchinstanceid)
        {
            var data = Db.award_apply.FirstOrDefault(o => o.userid == uid && o.batchinstanceid == batchinstanceid);
            return data != null ? true : false;
        }

        //用户申请奖项
        public bool AddUserApplyAward(string uid,string instanceid,string batchinstanceid,List<string> instancebaseinfoid, List<string> baseinfoValue,List<string> usermaterialid)
        {
            var applyid = DateTime.Now.Random();
            Db.award_apply.Add(new award_apply()
            {
                applyid= applyid,
                userid=uid,
                instanceid= instanceid,
                statusid=0,//草稿
                apply_time=DateTime.Now,
                batchinstanceid= batchinstanceid,
            });
            for (int i = 0; i < instancebaseinfoid.Count; i++)
            {
                var instancebaseinfoid1 = instancebaseinfoid[i];
                var value = baseinfoValue[i];
                Db.award_instance_value.Add(new award_instance_value()
                {
                    awardinstancevalueid = DateTime.Now.Random() + 1,
                    applyid = applyid,
                    instancebaseinfoid= instancebaseinfoid1,
                    value= value
                });
            }
            for (int i = 0; i < usermaterialid.Count; i++)
            {
                var usermaterialid1 = usermaterialid[i];
                Db.user_apply_material.Add(new user_apply_material()
                {
                    applymaterialid = DateTime.Now.Random() + 1,
                    applyid = applyid,
                    usermaterialid = usermaterialid1,
                });
            }
            return Db.Saved() ? true : false;
        }

        //用户已经申请过的资料（审核通过）
        public List<UserMaterial> UserMaterialList(string uid)
        {
            //查找审核通过的材料
            return  Db.user_material.Where(o => o.userid == uid&&o.statusid==2).Select(b => new UserMaterial()
            {
                materialtypeid = b.materialtypeid,
                userid = b.userid,
                usermaterialid = b.usermaterialid,
                material_name = b.name,
                typename = b.material_type.typename
            }).ToList();
        }

        //用户申请奖项所填写的资料(不包括材料的值)
        public List<UserMaterial> UserAwardMaterialList(string applyid)
        {
            return Db.user_apply_material.Where(o => o.applyid == applyid).Select(b => new UserMaterial()
            {
                applyid=b.applyid,
                applymaterialid=b.applymaterialid,
                materialtypeid = b.user_material.materialtypeid,
                userid = b.user_material.userid,
                usermaterialid = b.usermaterialid,
                material_name = b.user_material.name,
                typename = b.user_material.material_type.typename,
            }).ToList();
        }

        //用户申请奖项所填写的资料(包括材料的值)
        public List<List<UserMaterial>> UserAwardMaterialAndVauleList(string applyid)
        {
            List<List<UserMaterial>> userMaterials = new List<List<UserMaterial>>();
           var data = Db.user_apply_material.Where(o => o.applyid == applyid).ToList();
            foreach (var item in data)
            {
                var userMaterial = Db.material_values.Where(o => o.usermaterialid == item.usermaterialid).Select(b => new UserMaterial()
                {
                    applyid = item.applyid,
                    applymaterialid = item.applymaterialid,
                    materialtypeid = item.user_material.materialtypeid,
                    userid = item.user_material.userid,
                    usermaterialid = item.usermaterialid,
                    material_name = item.user_material.name,
                    typename = item.user_material.material_type.typename,
                    marterialvaluesid = b.marterialvaluesid,
                    materialvalue = b.materialvalue,
                    attrname = b.material_type_attrs.material_attrs.attrname,
                    materialtypeattrid = b.materialtypeattrid     
                }).ToList();
                userMaterials.Add(userMaterial);
            }
            return userMaterials;
        }

        //学校奖项审核搜索下拉框（学校管理员，只有全部，待学校审核，学校审核通过，学校审核不通过这几项）
        //原因：在学校审核方面来讲，只是需要再次审核由学院审核通过提交上来的学生名单，由学院淘汰的不出现在学校审核的列表里面
        ///奖项申请状态如下：
        ///0：草稿
        ///1：待学院审核
        ///2：学院审核通过
        ///3：学院审核不通过
        ///4：待学校审核
        ///5：学校审核通过
        ///6：学校审核不通过
        public List<SelectListItem> SearchSchoolAwardSelect()
        {
            return Db.apply_status.Where(o => o.statusid >= 4).Select(b => new SelectListItem()
            {
                Value = b.statusid.ToString(),
                Text = b.statusname
            }).ToList();
        }

        //学院奖项审核搜索下拉框（学院管理员，没有草稿这一项）
        public List<SelectListItem> SearchCollegeAwardSelect()
        {
            return Db.apply_status.Where(o => o.statusid != 0).Select(b => new SelectListItem()
            {
                Value = b.statusid.ToString(),
                Text = b.statusname
            }).ToList();
        }

        //查找该用户是否已经申请过该奖项
        public bool FindUserAwardApplyRecord(string uid, string batchinstanceid)
        {
            var data = Db.award_apply.FirstOrDefault(o => o.userid == uid && o.batchinstanceid == batchinstanceid);
            return data != null ? true : false;
        }

        //查找奖项基本信息表里面是否已经存在该条记录
        public bool FindATBI(string baseinfoid, string awardtypeid)
        {
            var result =
                Db.award_type_baseInfo.FirstOrDefault(a => a.baseinfoid == baseinfoid && a.awardtypeid == awardtypeid);
            return (result != null) ? true : false;
        }

        //查找材料属性表里面是否已经存在该条记录
        public bool FindMTA(string materialtypeid, string materialattrid)
        {
            var result =
                Db.material_type_attrs.FirstOrDefault(
                    a => a.materialtypeid == materialtypeid && a.materialattrid == materialattrid);
            return (result != null) ? true : false;
        }

        //查找奖励材料联系表里面是否已经存在该条记录
        public bool FindAM(string materialtypeid, string awardtypeid)
        {
            var result =
                Db.award_material.FirstOrDefault(a => a.materialtypeid == materialtypeid && a.awardtypeid == awardtypeid);
            return (result != null) ? true : false;
        }

        //查找奖项批次实例表里面是否已经存在该条记录
        public bool FindABI(string batchid, string instanceid)
        {
            var result = Db.award_batch_instance.FirstOrDefault(a => a.batchid == batchid && a.instanceid == instanceid);
            return (result != null) ? true : false;
        }

        //改变奖项实例的状态
        public bool ChangeAwardInstanceStatus(string instanceid, string flag)
        {
            //flag=1是开放状态，0是关闭状态
            var instance = Db.award_instance.FirstOrDefault(o => o.instanceid == instanceid);
            if (instance != null)
            {
                if (flag == "1")
                {
                    instance.state = 0;
                    return Db.SaveModified(instance);
                }
                else
                {
                    instance.state = 1;
                    return Db.SaveModified(instance);
                }
            }
            else
            {
                return false;
            }
        }

        //查找奖项实例材料表里面是否已经存在该条记录
        public bool FindAMI(string materialtypeid, string instanceid)
        {
            var result =
                Db.award_materia_instance.FirstOrDefault(
                    a => a.materialtypeid == materialtypeid && a.instanceid == instanceid);
            return (result != null) ? true : false;
        }

        //查找奖项实例基本信息表里面是否已经存在该条记录
        public bool FindAIB(string baseInfoid, string instanceid)
        {
            var result =
                Db.award_instance_baseInfo.FirstOrDefault(a => a.baseInfoid == baseInfoid && a.instanceid == instanceid);
            return (result != null) ? true : false;
        }

        //该奖项类型的所有基本信息项
        public List<award_type_baseInfo> FindATBList(string awardtypeid)
        {
            return Db.award_type_baseInfo.Where(a => a.awardtypeid == awardtypeid).ToList().Select(b => new award_type_baseInfo()
                {
                    sequence = b.sequence,
                    baseinfoid = b.baseinfoid,
                    awardtypebaseinfoid=b.awardtypebaseinfoid,
                    awardtypeid=b.awardtypeid
                }).ToList();
        }

        //该奖项类型的所有相关的材料
        public List<SelectListItem> FindAwardTypeAboutMaterialList(string awardtypeid)
        {
            var result =
                Db.award_material.Where(a => a.awardtypeid == awardtypeid).Select(b => new SelectListItem()
                {
                    Text = b.awardmaterialid,
                    Value = b.materialtypeid
                }).ToList();
            return result;
        }

        //添加奖项实例表，奖项实例基本信息表，奖项材料实例表（同时添加）
        public bool AddAwardInstanceAndBaseinfoAndMaterial(award_instance award_instance_list)
        {
            var awardtypebaseInfolist = FindATBList(award_instance_list.awardtypeid);//该奖项类型的所有基本信息列表
            var awardAboutMaterial = FindAwardTypeAboutMaterialList(award_instance_list.awardtypeid);//查找该奖项类型的所有有关的材料
            Db.award_instance.Add(new award_instance()
            {
                instanceid=award_instance_list.instanceid,
                awardtypeid=award_instance_list.awardtypeid,
                state = 0,//当创建一个奖项实例的时候，默认该实例的状态是未开放
                instancename=award_instance_list.instancename,
                starttime = award_instance_list.starttime,
                endtime = award_instance_list.endtime,
                bonus = award_instance_list.bonus
            });
            foreach (var item in awardtypebaseInfolist)//讲该奖项类型的所有基本信息添加到奖项实例基本信息的表
            {
                Db.award_instance_baseInfo.Add(new award_instance_baseInfo()
                {
                    baseInfoid = item.baseinfoid,
                    instanceid = award_instance_list.instanceid,
                    instancebaseinfoid = DateTime.Now.Random(),
                    sequence=item.sequence
                });
            }
            foreach (var item in awardAboutMaterial)//将该奖项类型的所有有关材料添加到奖项实例跟材料联系的表
            {
                Db.award_materia_instance.Add(new award_materia_instance()
                {
                    materialtypeid = item.Value,
                    instanceid = award_instance_list.instanceid,
                    awardmaterialinstanceid = DateTime.Now.Random(),
                    count=0
                });
            }
            return Db.Saved()?true:false;
        }
        //添加用户申请材料和申请材料值
        public bool AddUserMaterialAndMaterialValue(string uid,string materialid,string user_material_name, List<MaterialValue> materialValue)
        {
            var usermaterialid = DateTime.Now.Random();
            Db.user_material.Add(new user_material()
            {
                usermaterialid= usermaterialid,
                userid = uid,
                materialtypeid = materialid,
                statusid = 0,//首先将用户填写的资料保存成草稿状态，以便随时可以修改
                material_apply_time = DateTime.Now,
                name = user_material_name
            });
            foreach (var item in materialValue)
            {
                Db.material_values.Add(new material_values()
                {
                    marterialvaluesid = DateTime.Now.Random(),
                    usermaterialid = usermaterialid,
                    materialtypeattrid = item.materialtypeattrid,
                    materialvalue = item.materialvalue
                });
            }
            return Db.Saved();
        }

        //查找奖项实例里面是是否已经有人申请过，如果有就不让删除
        public bool FindAwardInstanceApplyRecord(string batchinstanceid)
        {
            var record= Db.award_apply.FirstOrDefault(o => o.batchinstanceid == batchinstanceid);
            return record!=null ? true : false;
        }

        // 传入材料类型Id,查找该类型材料的属性
        public List<MaterialAttr> FindMAList(string materialtypeid)
        {
            var result =
                Db.material_type_attrs.Where(a => a.materialtypeid == materialtypeid).Select(b => new MaterialAttr()
                {
                    materialtypeattrid = b.materialtypeattrid,
                    materialattrid = b.material_type.materialtypeid,
                    attrname = b.material_attrs.attrname,
                    infodatatype=b.material_attrs.infodatatype
                }).OrderBy(b=>b.infodatatype).ToList();
            return result;
        }

        //传入奖项批次实例ID，查找该奖项实例的所有的基本信息项
        public List<AwardInstanceBaseInfo> GetAwardInstanceBaseInfo(string instanceid)
        {
            return Db.award_instance_baseInfo.Where(o => o.instanceid == instanceid).Select(b => new AwardInstanceBaseInfo {
                baseinfoid = b.baseInfoid,
                infoname = b.award_baseInfo.infoname,
                infodataytype = b.award_baseInfo.infodatatype,
                instancebaseinfoid = b.instancebaseinfoid,
                instanceid = b.instanceid
            }).ToList();
        }

        //传入奖项批次实例ID，查找该奖项实例的所有的基本信息项的值（具体到某一个申请）
        public List<AwardInstanceBaseInfo> GetAwardInstanceBaseInfoValue(string applyid)
        {
            return Db.award_instance_value.Where(o => o.applyid == applyid).Select(b => new AwardInstanceBaseInfo
            {
                applyid = b.applyid,
                value = b.value,
                awardinstancevalueid = b.awardinstancevalueid,
                baseinfoid = b.award_instance_baseInfo.baseInfoid,
                infoname = b.award_instance_baseInfo.award_baseInfo.infoname,
                infodataytype = b.award_instance_baseInfo.award_baseInfo.infodatatype,
                instancebaseinfoid = b.instancebaseinfoid,
                instanceid = b.award_apply.instanceid,
            }).ToList();
        }

        //添加奖项申请（先添加的基本资料）
        public bool AddAwardapplyFormBaseInfo(string uid,string instanceid,string batchinstanceid,List<string> instancebaseinfoid,List<string> value)
        {
            var record = Db.award_apply.FirstOrDefault(o => o.userid == uid && o.batchinstanceid == batchinstanceid);//还没有该记录
            var applyid = DateTime.Now.Random();
            if (record == null)
            {
                //先添加奖项申请表，再添加奖项实例值表
                Db.award_apply.Add(new award_apply
                {
                    applyid = applyid,
                    userid = uid,
                    instanceid = instanceid,
                    statusid = 0,
                    apply_time = DateTime.Now,
                    batchinstanceid = batchinstanceid
                });
                for (int i = 0; i < instancebaseinfoid.Count(); i++)
                {
                    var id1 = instancebaseinfoid[i];
                    var value2 = value[i];
                    Db.award_instance_value.Add(new award_instance_value
                    {
                        applyid = applyid,
                        instancebaseinfoid = id1,
                        value = value2,
                        awardinstancevalueid = DateTime.Now.Random()
                    });
                }
                return Db.Saved() ? true : false;
            }
            else
            {
                //已经存在该记录（在选材料的时候生成的记录），用已有的记录添加奖项实例值表
                for (int i = 0; i < instancebaseinfoid.Count(); i++)
                {
                    var id1 = instancebaseinfoid[i];
                    var value2 = value[i];
                    Db.award_instance_value.Add(new award_instance_value
                    {
                        applyid = record.applyid,
                        instancebaseinfoid = id1,
                        value = value2,
                        awardinstancevalueid = DateTime.Now.Random()
                    });
                }
                return Db.Saved() ? true : false;
            }
        }

        //添加奖项申请（先添加材料）
        public bool AddAwardapplyFormMaterial(string uid, string instanceid, string batchinstanceid, string usermaterialid)
        {
            var record = Db.award_apply.FirstOrDefault(o => o.userid == uid && o.batchinstanceid == batchinstanceid);//还没有该记录
            var applyid = DateTime.Now.Random();
            if (record == null)
            {
                //先添加奖项申请表，再添加用户申请材料表
                Db.award_apply.Add(new award_apply
                {
                    applyid = applyid,
                    userid = uid,
                    instanceid = instanceid,
                    statusid = 0,
                    apply_time = DateTime.Now,
                    batchinstanceid = batchinstanceid
                });
                    Db.user_apply_material.Add(new user_apply_material
                    {
                        applymaterialid = DateTime.Now.Random(),
                        applyid = applyid,
                        usermaterialid= usermaterialid
                    });
                return Db.Saved() ? true : false;
            }
            else
            {
                //已经存在该记录（再选材料的时候生成的记录），用已有的记录添加用户申请材料表
                Db.user_apply_material.Add(new user_apply_material
                {
                    applymaterialid = DateTime.Now.Random(),
                    applyid = applyid,
                    usermaterialid = usermaterialid
                });
                return Db.Saved() ? true : false;
            }
        }

        //查找该用户是否已近申请过该奖项
        public award_apply FindAwardApply(string uid, string batchinstanceid)
        {
            return Db.award_apply.FirstOrDefault(o => o.userid == uid && o.batchinstanceid == batchinstanceid);
        }

        //设置当前批次
        public bool SetCurrentBatch(string batchid)
        {
            //只有一个当前批次
            //List<award_batch> batchs = Db.award_batch.ToList();
            ////      var old = Db.award_batch.FirstOrDefault(o => o.batchid == batchid);//查找到要改的批次
            //foreach (var item in batchs)
            //{
            //    if (item.batchid == batchid)
            //    {
            //        item.IsCurrentBatch = "1";//将要修改的批次设为当前批次
            //        Db.SaveModified(item);
            //    }
            //    else
            //    {
            //        item.IsCurrentBatch = "0";//将其他的批次都设为不是当前批次
            //        Db.SaveModified(item);
            //    }
            //}
            //return Db.Saved() ? true : false;

            //批次可以有多个，活动的批次
            var old = Db.award_batch.FirstOrDefault(o => o.batchid == batchid);//查找到要改的批次
            old.IsCurrentBatch = "1";//设为当前批次
            return Db.SaveModified(old) ? true : false;
        }

        //关闭当前批次
        public bool OffCurrentBatch(string batchid)
        {
            var old = Db.award_batch.FirstOrDefault(o => o.batchid == batchid);//查找到要改的批次
            old.IsCurrentBatch = "0";//关闭当前批次
            return Db.SaveModified(old) ? true : false;
        }
        //属性类型：文本，文本域，时间，附件
        public List<SelectListItem> TypeList()
        {
            return new List<SelectListItem>()
            {
                new SelectListItem() { Text = "文本",Value = "001",Selected = true},
                new SelectListItem() { Text = "文本域",Value = "002"},
                new SelectListItem() { Text = "时间类型",Value = "003"},
                new SelectListItem() { Text = "附件",Value = "004"},
            };
        }

        //基本信息属性类型：文本，文本域，附件
        public List<SelectListItem> BaseInfoTypeList()
        {
            return new List<SelectListItem>()
            {
                new SelectListItem() { Text = "文本",Value = "001",Selected = true},
                new SelectListItem() { Text = "文本域",Value = "002"},
                new SelectListItem() { Text = "时间类型",Value = "003"}
            };
        }
        //材料申请状态
        public List<SelectListItem> MaterialApplyStatus()
        {
            return Db.user_material_status.Select(b => new SelectListItem()
            {
                Value = b.statusid.ToString(),
                Text = b.statusname
            }).ToList();
        }

        //找出材料的属性以及属性值
        public List<MaterialValue> MaterialAttrAndValue(string usermaterialid)
        {
            return Db.material_values.Where(o => o.usermaterialid == usermaterialid).Select(b => new MaterialValue()
            {
                marterialvaluesid = b.marterialvaluesid,
                materialvalue = b.materialvalue,
                materialtypeattrid = b.materialtypeattrid,
                materialattrid = b.material_type_attrs.materialattrid,
                attrname = b.material_type_attrs.material_attrs.attrname,
                infodatatype = b.material_type_attrs.material_attrs.infodatatype,
                name = b.user_material.name,
            }).OrderBy(b=>b.infodatatype).ToList();
        }

        //编辑材料值
        public bool ReEditMaterialValue(string user_material_name,string usermaterialid,List<string> marterialvaluesid, List<string> attrValue)
        {
            bool result = false;
            var old = Db.user_material.FirstOrDefault(o => o.usermaterialid == usermaterialid);
            old.material_apply_time=DateTime.Now;
            old.name = user_material_name;
            Db.SaveModified(old);
            for (int i = 0; i < marterialvaluesid.Count; i++)
            {
                var marterialValuesId = marterialvaluesid[i];
                var attrvalue = attrValue[i];
                var oldrecord = Db.material_values.FirstOrDefault(o => o.marterialvaluesid == marterialValuesId);
                oldrecord.materialvalue = attrvalue;
                Db.SaveModified(oldrecord);
                result = true;
            }
            return result ? true : false;
        }

        //提交材料申请
        public bool SubmitMyMaterialApply(string usermaterialid)
        {
            var old = Db.user_material.FirstOrDefault(o => o.usermaterialid == usermaterialid);
            old.statusid = 1;//待审核
            old.material_apply_time=DateTime.Now;
            return Db.SaveModified(old);
        }

        //查找用户材料申请详情
        public user_material MaterialApplyDetail(string usermaterialid)
        {
            return Db.user_material.FirstOrDefault(o => o.usermaterialid == usermaterialid);
        }

        //奖项申请状态
        public List<SelectListItem> AwardApplyStatus()
        {
            return Db.apply_status.Select(b => new SelectListItem()
            {
                Value = b.statusid.ToString(),
                Text = b.statusname
            }).ToList();
        }

        //所有学院
        public List<SelectListItem> OrgList()
        {
            return Db.org.Select(b => new SelectListItem()
            {
                Value = b.orgid,
                Text = b.orgname
            }).ToList();
        }

        //将奖项实例分配给学院
        public bool AwardInstanceDistributionToOrg(string batchinstanceid,List<string> orgid, List<int> count)
        {
            for (int i = 0; i < orgid.Count; i++)
            {
               var  orgid1 = orgid[i];
                var count1 = count[i];
                Db.org_award_instance.Add(new org_award_instance()
                {
                    orgawardinstanceid = DateTime.Now.Random(),
                    orgid = orgid1,
                    batchinstanceid = batchinstanceid,
                    count = count1
                });
            }
            return Db.Saved() ? true : false;
        }

        //将奖项实例分配给学院(更新分配)
        public bool AwardInstanceDistributionToOrgUpdate(List<int> count,List<string> orgawardinstanceid)
        {
            for (int i = 0; i < orgawardinstanceid.Count; i++)
            {
                var count1 = count[i];
                var orgawardinstanceid1 = orgawardinstanceid[i];
                var data = Db.org_award_instance.FirstOrDefault(o => o.orgawardinstanceid == orgawardinstanceid1);
                data.count = count1;
                Db.SaveModified(data);
            }
            return Db.Saved() ? true : false;
        }

        //查找是否已经将该奖项分配给该学院
        public org_award_instance Findorg_award_instanceRecord(string orgid,string batchinstanceid)
        {
            return Db.org_award_instance.FirstOrDefault(o => o.orgid == orgid && o.batchinstanceid == batchinstanceid);
        }

        //查找该学院是否已经有分配的奖项了
        public bool FindOrgDistributionRecord(string orgid)
        {
            var data= Db.org_award_instance.Where(o => o.orgid == orgid);
            return data.Count() > 0 ? true : false;
        }

        //资料审核搜索下拉框（学院管理员，没有草稿这一项）
        public List<SelectListItem> SearchCollegeMaterialSelect()
        {
            return Db.user_material_status.Where(o => o.statusid != 0).Select(b => new SelectListItem()
            {
                Value=b.statusid.ToString(),
                Text=b.statusname
            }).ToList();
        }

        //奖项所需资料
        public List<AwardMaterialInstance> AwardMaterialList(string instanceid)
        {
            return Db.award_instance.NoTrackingFind(o => o.instanceid == instanceid).award_materia_instance.Select(b => new AwardMaterialInstance() {
                awardmaterialinstanceid=b.awardmaterialinstanceid,
                materialtypeid = b.materialtypeid,
                typename = b.material_type.typename,
                description = b.material_type.description,
                count = b.count.Value
            }).ToList();
        }
    }
}
