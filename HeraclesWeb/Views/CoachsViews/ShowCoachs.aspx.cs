using HeraclesDAO.Logic;
using HeraclesDAO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HeraclesWeb.Views.CoachsViews
{
    public partial class ShowCoachs : Page
    {
        CoachImpl coachImpl;
        Coach _coach;

        protected void Page_Load(object sender, EventArgs e)
        {
            Select();
        }

        void Select()
        {
            coachImpl = new CoachImpl();
            gridData.DataSource = coachImpl.Select();
            gridData.DataBind();
        }

        protected void gridData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int row;
            GridViewRow gridView;
            switch (e.CommandName)
            {
                case "update":
                    row = Convert.ToInt32(e.CommandArgument);
                    gridView = gridData.Rows[row];

                    _coach = new Coach()
                    {
                        Id = byte.Parse(gridView.Cells[0].Text),
                        Name = gridView.Cells[1].Text,
                        LastName = gridView.Cells[2].Text,
                        SecondLastName = gridView.Cells[3].Text,
                        CI = gridView.Cells[4].Text,
                        Phone = gridView.Cells[5].Text
                    };

                    Session["EditCoach"] = _coach;
                    Response.Redirect("EditCoach");
                    break;
                case "delete":
                    //ModalPopup.Show();
                    row = Convert.ToInt32(e.CommandArgument);
                    gridView = gridData.Rows[row];

                    _coach = new Coach()
                    {
                        Id = byte.Parse(gridView.Cells[0].Text),
                        Name = gridView.Cells[1].Text,
                        LastName = gridView.Cells[2].Text,
                        SecondLastName = gridView.Cells[3].Text,
                        CI = gridView.Cells[4].Text,
                        Phone = gridView.Cells[5].Text
                    };

                    Session["DeleteCoach"] = _coach;
                    Response.Redirect("DeleteCoach");
                    break;
            }
        }

        protected void gridData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Cells[0].Visible = false;
        }
    }
}