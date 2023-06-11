using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace HeraclesWeb
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
        }

        //ROUTING
        private void RegisterRoutes(RouteCollection routes)
        {
            //Index
            routes.MapPageRoute("Default", "default", "~/Default.aspx");

            //Membresies
            routes.MapPageRoute("Membresies", "views/membresies", "~/Views/MembresiesViews/ShowMembresies.aspx");
            routes.MapPageRoute("NewMembresy", "views/newmembresy", "~/Views/MembresiesViews/New.aspx");
            routes.MapPageRoute("EditMembresy", "views/editmembresy", "~/Views/MembresiesViews/Edit.aspx");
            routes.MapPageRoute("DeleteMembresy", "views/deletemembresy", "~/Views/MembresiesViews/Delete.aspx");
            
            //Coachs
            routes.MapPageRoute("Coachs", "views/coachs", "~/Views/CoachsViews/ShowCoachs.aspx");
            routes.MapPageRoute("NewCoach", "views/newcoach", "~/Views/CoachsViews/New.aspx");
            routes.MapPageRoute("EditCoach", "views/editcoach", "~/Views/CoachsViews/Edit.aspx");
            routes.MapPageRoute("DeleteCoach", "views/deletecoach", "~/Views/CoachsViews/Delete.aspx");
        }
    }
}