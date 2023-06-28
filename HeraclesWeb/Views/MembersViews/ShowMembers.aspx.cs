using HeraclesDAO.Logic;
using HeraclesDAO.Models;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HeraclesWeb.Views.MembersViews
{
    public partial class ShowMembers : Page
    {
        MemberImpl memberImpl;
        Measures measures;
        static Member aux;
        Member member;

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
            memberImpl = new MemberImpl();
            int row;
            GridViewRow gridView;
            switch (e.CommandName)
            {
                case "update":
                    row = Convert.ToInt32(e.CommandArgument);
                    gridView = gridData.Rows[row];

                    member = new Member()
                    {
                        Id = int.Parse(gridView.Cells[0].Text),
                        Name = gridView.Cells[1].Text,
                        LastName = gridView.Cells[2].Text,
                        SecondLastName = gridView.Cells[3].Text,
                    };
                    DataTable dataTable = memberImpl.GetMeasures(member.Id);

                    measures = new Measures()
                    {
                        Weight = double.Parse(dataTable.Rows[0][0].ToString()),
                        ChestMeasure = double.Parse(dataTable.Rows[0][1].ToString()),
                        ArmMeasure = double.Parse(dataTable.Rows[0][2].ToString()),
                        LegMeasure = double.Parse(dataTable.Rows[0][3].ToString()),
                        Waist = double.Parse(dataTable.Rows[0][4].ToString())
                    };
                    Session["EditMeasures"] = measures;
                    Session["EditMember"] = member;
                    Response.Redirect("EditMember");

                    break;
                case "delete":
                    row = Convert.ToInt32(e.CommandArgument);
                    gridView = gridData.Rows[row];

                    member = new Member()
                    {
                        Id = int.Parse(gridView.Cells[0].Text),
                        Name = gridView.Cells[1].Text,
                        LastName = gridView.Cells[2].Text,
                        SecondLastName = gridView.Cells[3].Text,
                    };
                    aux = member;
                    ModalPopup.Show();
                    break;
            }
        }

        protected void gridData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Cells[0].Visible = false;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            switch ((string)Session["Role"])
            {
                case "Administrador":
                    Response.Redirect(ResolveUrl("~/Views/Default"));
                    break;
                case "Recepcionista":
                    Response.Redirect(ResolveUrl("~/Views/MenuReceptionist.aspx"));
                    break;
            }
        }

        protected void gridData_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            memberImpl = new MemberImpl();
            try
            {
                if(memberImpl.Delete(aux) > 0)
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
    }
}