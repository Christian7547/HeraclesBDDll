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
            int row;
            GridViewRow gridViewRow;
            switch (e.CommandName)
            {
                case "update":
                    row = Convert.ToInt32(e.CommandArgument);
                    gridViewRow = gridData.Rows[row];
                    office = new Office()
                    {
                        Id = byte.Parse(gridViewRow.Cells[0].Text),
                        Name = gridViewRow.Cells[1].Text,
                        Latitude = double.Parse(gridViewRow.Cells[2].Text),
                        Longitude = double.Parse(gridViewRow.Cells[3].Text)
                    };
                    string cityName = gridViewRow.Cells[4].Text;
                    Session["editOffice"] = office;
                    Session["city"] = cityName;
                    Response.Redirect("EditOffice");
                    break;
                case "delete":
                    break;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default");
        }
    }
}