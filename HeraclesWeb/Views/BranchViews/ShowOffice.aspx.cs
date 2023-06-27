using HeraclesDAO.Logic;
using HeraclesDAO.Models;
using System;
using System.Web.UI.WebControls;

namespace HeraclesWeb.Views.BranchViews
{
    public partial class ShowOffice : System.Web.UI.Page
    {
        OfficeImpl officeImpl;
        Office office;
        static Office aux;

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
                    row = Convert.ToInt32(e.CommandArgument);
                    gridViewRow = gridData.Rows[row];
                    office = new Office()
                    {
                        Id = byte.Parse(gridViewRow.Cells[0].Text),
                        Name = gridViewRow.Cells[1].Text,
                        Latitude = double.Parse(gridViewRow.Cells[2].Text),
                        Longitude = double.Parse(gridViewRow.Cells[3].Text)
                    };
                    aux = office;
                    ModalPopup.Show();
                    break;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            officeImpl = new OfficeImpl();
            try
            {
                if (officeImpl.Delete(aux) > 0)
                {
                    aux = null;
                    ModalPopup.Hide();
                    Select();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ModalPopup.Hide();
        }

        protected void gridData_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}