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
    public class user_materialRepository: BaseRepository, IRepository<user_material>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            return Db.user_material.ToItems(v => v.usermaterialid, t => t.name);
        }

        public string Add(user_material model)
        {
            model.materialtypeid = Pk;
            return Find(model.usermaterialid) == null ? (Db.SaveAdd(model) ? Pk : null) : "";
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(Find(id));
        }

        public bool Update(user_material model, string note = "")
        {
            Db.user_material.AddOrUpdate(model);
            return Db.Saved();
        }

        public user_material Find(object id)
        {
            return Db.user_material.NoTrackingFind(a => a.usermaterialid == (string)id);
        }

        public List<user_material> All()
        {
            return Db.user_material.NoTrackingToList();
        }

        public List<user_material> All(Func<user_material, bool> filter)
        {
            return Db.user_material.NoTrackingWhere(filter);
        }
    }
}
