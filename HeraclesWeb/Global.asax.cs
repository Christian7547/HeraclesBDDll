using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;

namespace HeraclesWeb
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
        }

        //ROUTING
        private void RegisterRoutes(RouteCollection routes)
        {
            //Login
            routes.MapPageRoute("Login", "views/login", "~/Views/LoginViews/Login.aspx");
            //Index
            routes.MapPageRoute("Default", "views/default", "~/Views/Default.aspx");
            routes.MapPageRoute("MenuCoach", "views/menucoach", "~/Views/MenuCoach.aspx");
            routes.MapPageRoute("MenuReceptionist", "views/menureceptionist", "~/Views/MenuReceptionist.aspx");
            routes.MapPageRoute("ChangePassword", "views/changePassword", "~/Views/LoginViews/ChangePassword.aspx");

            //Membresies
            routes.MapPageRoute("Membresies", "views/membresies", "~/Views/MembresiesViews/ShowMembresies.aspx");
            routes.MapPageRoute("NewMembresy", "views/newmembresy", "~/Views/MembresiesViews/New.aspx");
            routes.MapPageRoute("EditMembresy", "views/editmembresy", "~/Views/MembresiesViews/Edit.aspx");
            
            //Coachs
            routes.MapPageRoute("Coachs", "views/coachs", "~/Views/CoachsViews/ShowCoachs.aspx");
            routes.MapPageRoute("NewCoach", "views/newcoach", "~/Views/CoachsViews/New.aspx");
            routes.MapPageRoute("EditCoach", "views/editcoach", "~/Views/CoachsViews/Edit.aspx");

            //Members
            routes.MapPageRoute("Members", "views/members", "~/Views/MembersViews/ShowMembers.aspx");
            routes.MapPageRoute("NewMember", "views/newmember", "~/Views/MembersViews/New.aspx");
            routes.MapPageRoute("EditMember", "views/editmember", "~/Views/MembersViews/Edit.aspx");

            //Branch Office 
            routes.MapPageRoute("BranchOffices", "views/branchOffices", "~/Views/BranchViews/ShowOffice.aspx");
            routes.MapPageRoute("NewOffice", "views/newoffice", "~/Views/BranchViews/New.aspx");
            routes.MapPageRoute("EditOffice", "views/editoffice", "~/Views/BranchViews/Edit.aspx");
        }
    }
}