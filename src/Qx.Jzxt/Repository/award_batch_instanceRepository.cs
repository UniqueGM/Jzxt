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
    public class award_batch_instanceRepository: BaseRepository, IRepository<award_batch_instance>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            return Db.award_batch_instance.ToItems(v => v.batchinstanceid, t => t.instanceid);
        }

        public string Add(award_batch_instance model)
        {
            model.batchinstanceid = Pk;
            return Find(model.batchinstanceid) == null ? (Db.SaveAdd(model) ? Pk : null) : "";
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(Find(id));
        }

        public bool Update(award_batch_instance model, string note = "")
        {
            Db.award_batch_instance.AddOrUpdate(model);
            return Db.Saved();
        }

        public award_batch_instance Find(object id)
        {
            return Db.award_batch_instance.NoTrackingFind(a => a.batchinstanceid == (string)id);
        }

        public List<award_batch_instance> All()
        {
            return Db.award_batch_instance.NoTrackingToList();
        }

        public List<award_batch_instance> All(Func<award_batch_instance, bool> filter)
        {
            return Db.award_batch_instance.NoTrackingWhere(filter);
        }
    }
}
