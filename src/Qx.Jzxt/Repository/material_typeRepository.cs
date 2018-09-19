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
    public class material_typeRepository: BaseRepository, IRepository<material_type>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            return Db.material_type.ToItems(v => v.materialtypeid, t => t.typename);
        }

        public string Add(material_type model)
        {
            model.materialtypeid = Pk;
            return Find(model.materialtypeid) == null ? (Db.SaveAdd(model) ? Pk : null) : "";
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(Find(id));
        }

        public bool Update(material_type model, string note = "")
        {
            Db.material_type.AddOrUpdate(model);
            return Db.Saved();
        }

        public material_type Find(object id)
        {
            return Db.material_type.NoTrackingFind(a => a.materialtypeid == (string)id);
        }

        public List<material_type> All()
        {
            return Db.material_type.NoTrackingToList();
        }

        public List<material_type> All(Func<material_type, bool> filter)
        {
            return Db.material_type.NoTrackingWhere(filter);
        }
    }
}
