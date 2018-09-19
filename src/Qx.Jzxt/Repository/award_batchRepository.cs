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
    public class award_batchRepository: BaseRepository, IRepository<award_batch>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            return Db.award_batch.ToItems(v => v.batchid, t => t.batchname);
        }

        public string Add(award_batch model)
        {
            model.batchid = Pk;
            return Find(model.batchid) == null ? (Db.SaveAdd(model) ? Pk : null) : "";
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(Find(id));
        }

        public bool Update(award_batch model, string note = "")
        {
            Db.award_batch.AddOrUpdate(model);
            return Db.Saved();
        }

        public award_batch Find(object id)
        {
            return Db.award_batch.NoTrackingFind(a => a.batchid == (string)id);
        }

        public List<award_batch> All()
        {
            return Db.award_batch.NoTrackingToList();
        }

        public List<award_batch> All(Func<award_batch, bool> filter)
        {
            return Db.award_batch.NoTrackingWhere(filter);
        }
    }
}
