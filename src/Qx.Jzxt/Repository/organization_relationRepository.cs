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
    public class organization_relationRepository: BaseRepository, IRepository<organization_relation>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            return Db.organization_relation.ToItems(v => v.organization_relation_id, t => t.orgnization_id);
        }

        public string Add(organization_relation model)
        {
            model.organization_relation_id = Pk;
            return Find(model.organization_relation_id) == null ? (Db.SaveAdd(model) ? Pk : null) : "";
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(Find(id));
        }

        public bool Update(organization_relation model, string note = "")
        {
            Db.organization_relation.AddOrUpdate(model);
            return Db.Saved();
        }

        public organization_relation Find(object id)
        {
            return Db.organization_relation.NoTrackingFind(a => a.organization_relation_id == (string)id);
        }

        public List<organization_relation> All()
        {
            return Db.organization_relation.NoTrackingToList();
        }

        public List<organization_relation> All(Func<organization_relation, bool> filter)
        {
            return Db.organization_relation.NoTrackingWhere(filter);
        }
    }
}
