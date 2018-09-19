using Qx.Jzxt.Entity;
using Qx.Jzxt.Services;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Qx.Jzxt.Repository
{
    public class award_instance_baseInfoRepository: BaseRepository, IRepository<award_instance_baseInfo>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            return Db.award_instance_baseInfo.ToItems(v => v.instancebaseinfoid, t => t.baseInfoid);
        }

        public string Add(award_instance_baseInfo model)
        {
            model.instancebaseinfoid = Pk;
            return Find(model.instancebaseinfoid) == null ? (Db.SaveAdd(model) ? Pk : null) : "";
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(Find(id));
        }

        public bool Update(award_instance_baseInfo model, string note = "")
        {
            Db.award_instance_baseInfo.AddOrUpdate(model);
            return Db.Saved();
        }

        public award_instance_baseInfo Find(object id)
        {
            return Db.award_instance_baseInfo.NoTrackingFind(a => a.instancebaseinfoid == (string)id);
        }

        public List<award_instance_baseInfo> All()
        {
            return Db.award_instance_baseInfo.NoTrackingToList();
        }

        public List<award_instance_baseInfo> All(Func<award_instance_baseInfo, bool> filter)
        {
            return Db.award_instance_baseInfo.NoTrackingWhere(filter);
        }
    }
}
