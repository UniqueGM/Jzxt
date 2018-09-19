using System.Web.Mvc;

namespace Web.Areas.QxJzxt
{
    public class QxJzxtAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "QxJzxt";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "QxJzxt_default",
                "QxJzxt/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}