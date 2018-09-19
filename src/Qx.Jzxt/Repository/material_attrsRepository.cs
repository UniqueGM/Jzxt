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
    public class material_attrsRepository: BaseRepository, IRepository<material_attrs>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            return Db.material_attrs.ToItems(v => v.materialattrid, t => t.attrname);
        }

        public string Add(material_attrs model)
        {
            model.materialattrid = Pk;
            return Find(model.materialattrid) == null ? (Db.SaveAdd(model) ? Pk : null) : "";
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(Find(id));
        }

        public bool Update(material_attrs model, string note = "")
        {
            Db.material_attrs.AddOrUpdate(model);
            return Db.Saved();
        }

        public material_attrs Find(object id)
        {
            return Db.material_attrs.NoTrackingFind(a => a.materialattrid == (string)id);
        }

        public List<material_attrs> All()
        {
            return Db.material_attrs.NoTrackingToList();
        }

        public List<material_attrs> All(Func<material_attrs, bool> filter)
        {
            return Db.material_attrs.NoTrackingWhere(filter);
        }
    }
}
