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
    public class organization_levelRepository: BaseRepository, IRepository<organization_level>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            return Db.organization_level.ToItems(v => v.organization_level_id, t => t.name);
        }

        public string Add(organization_level model)
        {
            model.organization_level_id = Pk;
            return Find(model.organization_level_id) == null ? (Db.SaveAdd(model) ? Pk : null) : "";
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(Find(id));
        }

        public bool Update(organization_level model, string note = "")
        {
            Db.organization_level.AddOrUpdate(model);
            return Db.Saved();
        }

        public organization_level Find(object id)
        {
            return Db.organization_level.NoTrackingFind(a => a.organization_level_id == (string)id);
        }

        public List<organization_level> All()
        {
            return Db.organization_level.NoTrackingToList();
        }

        public List<organization_level> All(Func<organization_level, bool> filter)
        {
            return Db.organization_level.NoTrackingWhere(filter);
        }
    }
}
