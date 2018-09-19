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
    public class award_baseInfoRepository: BaseRepository, IRepository<award_baseInfo>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            return Db.award_baseInfo.ToItems(v => v.baseinfoid, t => t.infoname);
        }

        public string Add(award_baseInfo model)
        {
            model.baseinfoid = Pk;
            return Find(model.baseinfoid) == null ? (Db.SaveAdd(model) ? Pk : null) : "";
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(Find(id));
        }

        public bool Update(award_baseInfo model, string note = "")
        {
            Db.award_baseInfo.AddOrUpdate(model);
            return Db.Saved();
        }

        public award_baseInfo Find(object id)
        {
            return Db.award_baseInfo.NoTrackingFind(a => a.baseinfoid == (string)id);
        }

        public List<award_baseInfo> All()
        {
            return Db.award_baseInfo.NoTrackingToList();
        }

        public List<award_baseInfo> All(Func<award_baseInfo, bool> filter)
        {
            return Db.award_baseInfo.NoTrackingWhere(filter);
        }
    }
}
