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
    public class user_positionRepository: BaseRepository, IRepository<user_position>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            return Db.user_position.ToItems(v => v.user_position_id, t => t.user_id);
        }

        public string Add(user_position model)
        {
            model.user_position_id = Pk;
            return Find(model.user_position_id) == null ? (Db.SaveAdd(model) ? Pk : null) : "";
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(Find(id));
        }

        public bool Update(user_position model, string note = "")
        {
            Db.user_position.AddOrUpdate(model);
            return Db.Saved();
        }

        public user_position Find(object id)
        {
            return Db.user_position.NoTrackingFind(a => a.user_position_id == (string)id);
        }

        public List<user_position> All()
        {
            return Db.user_position.NoTrackingToList();
        }

        public List<user_position> All(Func<user_position, bool> filter)
        {
            return Db.user_position.NoTrackingWhere(filter);
        }
    }
}
