using HeraclesDAO.Logic;
using HeraclesDAO.Models;
using HeraclesDAO.Models.Session;
using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace HeraclesWeb.Views.BranchViews
{
    public partial class Edit : Page
    {

        OfficeImpl officeImpl;
        Office office;

        protected void Page_Load(object sender, EventArgs e)
        {
            office = Session["EditOffice"] as Office;
            
            if (office != null)
            {
                txtId.Text = office.Id.ToString();
                txtName.Text = HttpUtility.HtmlDecode(office.Name);
                txtLatitude.Text = office.Latitude.ToString();
                txtLongitude.Text = office.Longitude.ToString();
                Session.Remove("EditOffice");
            }
            FillComboBox();
            LoadSelectedText(Session["city"] as string);
            Session.Remove("city");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            officeImpl = new OfficeImpl();
            office = new Office()
            {
                Id = byte.Parse(txtId.Text),
                Name = txtName.Text,
                Latitude = double.Parse(txtLatitude.Text.Replace('.', ',')),
                Longitude = double.Parse(txtLongitude.Text.Replace('.', ',')),
                CityId = byte.Parse(cmbLocation.SelectedValue),
                UserId = SessionClass.SessionId
            };
            try
            {
                if (officeImpl.Update(office) > 0)
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

        void LoadSelectedText(string item)
        {
            switch (item)
            {
                case "La Paz":
                    cmbLocation.SelectedIndex = 1;
                    break;
                case "Santa Cruz":
                    cmbLocation.SelectedIndex = 2;
                    break;
                case "Sucre":
                    cmbLocation.SelectedIndex = 3;
                    break;
                case "Trinidad":
                    cmbLocation.SelectedIndex = 4;
                    break;
                case "Cochabamba":
                    cmbLocation.SelectedIndex = 0;
                    break;
            }
        }
    }
}