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
    public class award_type_baseInfoRepository: BaseRepository, IRepository<award_type_baseInfo>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            return Db.award_type_baseInfo.ToItems(v => v.awardtypebaseinfoid, t => t.baseinfoid);
        }

        public string Add(award_type_baseInfo model)
        {
            model.awardtypebaseinfoid = Pk;
            return Find(model.awardtypebaseinfoid) == null ? (Db.SaveAdd(model) ? Pk : null) : "";
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(Find(id));
        }

        public bool Update(award_type_baseInfo model, string note = "")
        {
            Db.award_type_baseInfo.AddOrUpdate(model);
            return Db.Saved();
        }

        public award_type_baseInfo Find(object id)
        {
            return Db.award_type_baseInfo.NoTrackingFind(a => a.awardtypebaseinfoid == (string)id);
        }

        public List<award_type_baseInfo> All()
        {
            return Db.award_type_baseInfo.NoTrackingToList();
        }

        public List<award_type_baseInfo> All(Func<award_type_baseInfo, bool> filter)
        {
            return Db.award_type_baseInfo.NoTrackingWhere(filter);
        }
    }
}
