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
    public class award_materia_instanceRepository: BaseRepository, IRepository<award_materia_instance>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            return Db.award_materia_instance.ToItems(v => v.awardmaterialinstanceid, t => t.materialtypeid);
        }

        public string Add(award_materia_instance model)
        {
            model.awardmaterialinstanceid = Pk;
            return Find(model.awardmaterialinstanceid) == null ? (Db.SaveAdd(model) ? Pk : null) : "";
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(Find(id));
        }

        public bool Update(award_materia_instance model, string note = "")
        {
            Db.award_materia_instance.AddOrUpdate(model);
            return Db.Saved();
        }

        public award_materia_instance Find(object id)
        {
            return Db.award_materia_instance.NoTrackingFind(a => a.awardmaterialinstanceid == (string)id);
        }

        public List<award_materia_instance> All()
        {
            return Db.award_materia_instance.NoTrackingToList();
        }

        public List<award_materia_instance> All(Func<award_materia_instance, bool> filter)
        {
            return Db.award_materia_instance.NoTrackingWhere(filter);
        }
    }
}
