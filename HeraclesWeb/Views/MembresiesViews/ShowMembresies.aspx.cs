using HeraclesDAO.Logic;
using HeraclesDAO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HeraclesWeb.Views.MembresiesViews
{
    public partial class ShowMembresies : System.Web.UI.Page
    {

        MembresyImpl membresyImpl;
        Membresy membresy;

        protected void Page_Load(object sender, EventArgs e)
        {
            Select();
        }

        void Select()
        {
            membresyImpl = new MembresyImpl();
            gridData.DataSource = membresyImpl.Select();
            gridData.DataBind();
        }

        protected void gridData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int row;
            GridViewRow dates;
            switch (e.CommandName)
            {
                case "update":
                    row = Convert.ToInt32(e.CommandArgument);

                    dates = gridData.Rows[row];

                    membresy = new Membresy()
                    {
                        Id = byte.Parse(dates.Cells[0].Text),
                        TypeMembresy = dates.Cells[1].Text,
                        Price = float.Parse(dates.Cells[2].Text)
                    };

                    Session["MembresyEdit"] = membresy;
                    Response.Redirect("EditMembresy");
                    break;

                case "delete":
                    row = Convert.ToInt32(e.CommandArgument);

                    dates = gridData.Rows[row];

                    membresy = new Membresy()
                    {
                        Id = byte.Parse(dates.Cells[0].Text),
                        TypeMembresy = dates.Cells[1].Text,
                        Price = float.Parse(dates.Cells[2].Text)
                    };

                    Session["DeleteMembresy"] = membresy;
                    Response.Redirect("DeleteMembresy");
                    break;
            }
        }

        protected void gridData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Cells[0].Visible = false; //Hidden column 0
        }
    }
}