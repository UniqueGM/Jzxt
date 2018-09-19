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
    public class award_materialRepository: BaseRepository, IRepository<award_material>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            return Db.award_material.ToItems(v => v.awardmaterialid, t => t.materialtypeid);
        }

        public string Add(award_material model)
        {
            model.awardmaterialid = Pk;
            return Find(model.awardmaterialid) == null ? (Db.SaveAdd(model) ? Pk : null) : "";
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(Find(id));
        }

        public bool Update(award_material model, string note = "")
        {
            Db.award_material.AddOrUpdate(model);
            return Db.Saved();
        }

        public award_material Find(object id)
        {
            return Db.award_material.NoTrackingFind(a => a.awardmaterialid == (string)id);
        }

        public List<award_material> All()
        {
            return Db.award_material.NoTrackingToList();
        }

        public List<award_material> All(Func<award_material, bool> filter)
        {
            return Db.award_material.NoTrackingWhere(filter);
        }
    }
}
