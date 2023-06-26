using HeraclesDAO.Logic;
using HeraclesDAO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HeraclesWeb.Views.BranchViews
{
    public partial class ShowOffice : System.Web.UI.Page
    {
        OfficeImpl officeImpl;
        Office office;

        protected void Page_Load(object sender, EventArgs e)
        {
            Select();
        }

        void Select()
        {
            officeImpl = new OfficeImpl();
            gridData.DataSource = officeImpl.Select();
            gridData.DataBind();
        }

        protected void gridData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Cells[0].Visible = false;
        }

        protected void gridData_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}