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
    public class award_instanceRepository: BaseRepository, IRepository<award_instance>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            return Db.award_instance.ToItems(v => v.instanceid, t => t.instancename);
        }

        public string Add(award_instance model)
        {
            model.instanceid = Pk;
            return Find(model.instanceid) == null ? (Db.SaveAdd(model) ? Pk : null) : "";
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(Find(id));
        }

        public bool Update(award_instance model, string note = "")
        {
            Db.award_instance.AddOrUpdate(model);
            return Db.Saved();
        }

        public award_instance Find(object id)
        {
            return Db.award_instance.NoTrackingFind(a => a.instanceid == (string)id);
        }

        public List<award_instance> All()
        {
            return Db.award_instance.NoTrackingToList();
        }

        public List<award_instance> All(Func<award_instance, bool> filter)
        {
            return Db.award_instance.NoTrackingWhere(filter);
        }
    }
}
