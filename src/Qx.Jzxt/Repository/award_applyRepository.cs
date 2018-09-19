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
    public class award_applyRepository: BaseRepository, IRepository<award_apply>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            return Db.award_apply.ToItems(v => v.applyid, t => t.applyid);
        }

        public string Add(award_apply model)
        {
            model.applyid = Pk;
            return Find(model.applyid) == null ? (Db.SaveAdd(model) ? Pk : null) : "";
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(Find(id));
        }

        public bool Update(award_apply model, string note = "")
        {
            Db.award_apply.AddOrUpdate(model);
            return Db.Saved();
        }

        public award_apply Find(object id)
        {
            return Db.award_apply.NoTrackingFind(a => a.applyid == (string)id);
        }

        public List<award_apply> All()
        {
            return Db.award_apply.NoTrackingToList();
        }

        public List<award_apply> All(Func<award_apply, bool> filter)
        {
            return Db.award_apply.NoTrackingWhere(filter);
        }
    }
}
