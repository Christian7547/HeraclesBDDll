using HeraclesDAO.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HeraclesWeb.Views.MembersViews
{
    public partial class ShowMembers : System.Web.UI.Page
    {
        MemberImpl memberImpl;

        protected void Page_Load(object sender, EventArgs e)
        {
            Select();
        }

        void Select()
        {
            memberImpl = new MemberImpl();
            gridData.DataSource = memberImpl.Select();
            gridData.DataBind();
        }

        protected void gridData_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void gridData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Cells[0].Visible = false;
        }
    }
}