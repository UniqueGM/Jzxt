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
    public class material_type_attrsRepository: BaseRepository, IRepository<material_type_attrs>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            return Db.material_type_attrs.ToItems(v => v.materialtypeattrid, t => t.materialtypeattrid);
        }

        public string Add(material_type_attrs model)
        {
            model.materialtypeattrid = Pk;
            return Find(model.materialtypeattrid) == null ? (Db.SaveAdd(model) ? Pk : null) : "";
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(Find(id));
        }

        public bool Update(material_type_attrs model, string note = "")
        {
            Db.material_type_attrs.AddOrUpdate(model);
            return Db.Saved();
        }

        public material_type_attrs Find(object id)
        {
            return Db.material_type_attrs.NoTrackingFind(a => a.materialtypeattrid == (string)id);
        }

        public List<material_type_attrs> All()
        {
            return Db.material_type_attrs.NoTrackingToList();
        }

        public List<material_type_attrs> All(Func<material_type_attrs, bool> filter)
        {
            return Db.material_type_attrs.NoTrackingWhere(filter);
        }
    }
}
