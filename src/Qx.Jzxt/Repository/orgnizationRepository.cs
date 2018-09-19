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
    public class orgnizationRepository: BaseRepository, IRepository<orgnization>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            return Db.orgnization.ToItems(v => v.orgnization_id, t => t.name);
        }

        public string Add(orgnization model)
        {
            model.orgnization_id = Pk;
            return Find(model.orgnization_id) == null ? (Db.SaveAdd(model) ? Pk : null) : "";
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(Find(id));
        }

        public bool Update(orgnization model, string note = "")
        {
            Db.orgnization.AddOrUpdate(model);
            return Db.Saved();
        }

        public orgnization Find(object id)
        {
            return Db.orgnization.NoTrackingFind(a => a.orgnization_id == (string)id);
        }

        public List<orgnization> All()
        {
            return Db.orgnization.NoTrackingToList();
        }

        public List<orgnization> All(Func<orgnization, bool> filter)
        {
            return Db.orgnization.NoTrackingWhere(filter);
        }
    }
}
