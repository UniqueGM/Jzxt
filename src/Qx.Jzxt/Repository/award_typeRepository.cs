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
    public class award_typeRepository: BaseRepository, IRepository<award_type>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            return Db.award_type.ToItems(v => v.awardtypeid, t => t.awardname);
        }

        public string Add(award_type model)
        {
            model.awardtypeid = Pk;
            return Find(model.awardtypeid) == null ? (Db.SaveAdd(model) ? Pk : null) : "";
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(Find(id));
        }

        public bool Update(award_type model, string note = "")
        {
            Db.award_type.AddOrUpdate(model);
            return Db.Saved();
        }

        public award_type Find(object id)
        {
            return Db.award_type.NoTrackingFind(a => a.awardtypeid == (string)id);
        }

        public List<award_type> All()
        {
            return Db.award_type.NoTrackingToList();
        }

        public List<award_type> All(Func<award_type, bool> filter)
        {
            return Db.award_type.NoTrackingWhere(filter);
        }
    }
}
