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
    public class org_award_instanceRepository: BaseRepository, IRepository<org_award_instance>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            return Db.org_award_instance.ToItems(v => v.orgawardinstanceid, t => t.orgid);
        }

        public string Add(org_award_instance model)
        {
            model.orgawardinstanceid = Pk;
            return Find(model.orgawardinstanceid) == null ? (Db.SaveAdd(model) ? Pk : null) : "";
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(Find(id));
        }

        public bool Update(org_award_instance model, string note = "")
        {
            Db.org_award_instance.AddOrUpdate(model);
            return Db.Saved();
        }

        public org_award_instance Find(object id)
        {
            return Db.org_award_instance.NoTrackingFind(a => a.orgawardinstanceid == (string)id);
        }

        public List<org_award_instance> All()
        {
            return Db.org_award_instance.NoTrackingToList();
        }

        public List<org_award_instance> All(Func<org_award_instance, bool> filter)
        {
            return Db.org_award_instance.NoTrackingWhere(filter);
        }
    }
}
