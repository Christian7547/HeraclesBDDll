using HeraclesDAO.Logic;
using HeraclesDAO.Models;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HeraclesWeb.Views.MembresiesViews
{
    public partial class ShowMembresies : Page
    {

        MembresyImpl membresyImpl;
        Membresy membresy;
        static Membresy aux;

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
                    aux = membresy;
                    ModalPopup.Show();
                    break;
            }
        }

        protected void gridData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Cells[0].Visible = false; //Hidden column 0
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            switch ((string)Session["Role"])
            {
                case "Administrador":
                    Response.Redirect(ResolveUrl("~/Views/Default"));
                    break;
                case "Recepcionista":
                    Response.Redirect(ResolveUrl("~/Views/MenuReceptionist"));
                    break;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            membresyImpl = new MembresyImpl();
            try
            {
                if(membresyImpl.Delete(aux) > 0)
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