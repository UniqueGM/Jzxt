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
    public class material_valuesRepository: BaseRepository, IRepository<material_values>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            return Db.material_values.ToItems(v => v.marterialvaluesid, t => t.materialtypeattrid);
        }

        public string Add(material_values model)
        {
            model.marterialvaluesid = Pk;
            return Find(model.marterialvaluesid) == null ? (Db.SaveAdd(model) ? Pk : null) : "";
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(Find(id));
        }

        public bool Update(material_values model, string note = "")
        {
            Db.material_values.AddOrUpdate(model);
            return Db.Saved();
        }

        public material_values Find(object id)
        {
            return Db.material_values.NoTrackingFind(a => a.marterialvaluesid == (string)id);
        }

        public List<material_values> All()
        {
            return Db.material_values.NoTrackingToList();
        }

        public List<material_values> All(Func<material_values, bool> filter)
        {
            return Db.material_values.NoTrackingWhere(filter);
        }
    }
}
