using HeraclesDAO.Logic;
using HeraclesDAO.Models;
using HeraclesDAO.Models.Session;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace HeraclesWeb.Views.BranchViews
{
    public partial class New : Page
    {
        OfficeImpl officeImpl;
        Office office;

        protected void Page_Load(object sender, EventArgs e)
        {
            FillComboBox();
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            officeImpl = new OfficeImpl();
            office = new Office()
            {
                Name = txtName.Text,
                Latitude = double.Parse(txtLatitude.Text.Replace('.', ',')),
                Longitude = double.Parse(txtLongitude.Text.Replace('.', ',')),
                CityId = byte.Parse(cmbLocation.SelectedValue),
                UserId = SessionClass.SessionId
            };
            try
            {
                if (officeImpl.Insert(office) > 0)
                    Response.Redirect("BranchOffices");
                office = null;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("BranchOffices");
        }

        void FillComboBox()
        {
            if (!IsPostBack)
            {
                officeImpl = new OfficeImpl();
                DataTable data = officeImpl.GetCities();

                for (int i = 0; i < data.Rows.Count; i++)
                {
                    ListItem listItem = new ListItem();
                    listItem.Value = data.Rows[i][0].ToString();
                    listItem.Text = data.Rows[i][1].ToString();
                    cmbLocation.Items.Add(listItem);
                }
            }
        }
    }
}