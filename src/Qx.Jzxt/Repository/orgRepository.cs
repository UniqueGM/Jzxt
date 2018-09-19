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
    public class orgRepository: BaseRepository, IRepository<org>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            return Db.org.ToItems(v => v.orgid, t => t.orgname);
        }

        public string Add(org model)
        {
            model.orgid = Pk;
            return Find(model.orgid) == null ? (Db.SaveAdd(model) ? Pk : null) : "";
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(Find(id));
        }

        public bool Update(org model, string note = "")
        {
            Db.org.AddOrUpdate(model);
            return Db.Saved();
        }

        public org Find(object id)
        {
            return Db.org.NoTrackingFind(a => a.orgid == (string)id);
        }

        public List<org> All()
        {
            return Db.org.NoTrackingToList();
        }

        public List<org> All(Func<org, bool> filter)
        {
            return Db.org.NoTrackingWhere(filter);
        }
    }
}
