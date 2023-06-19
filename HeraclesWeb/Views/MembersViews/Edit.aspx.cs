using HeraclesDAO.Logic;
using HeraclesDAO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HeraclesWeb.Views.MembersViews
{
    public partial class Edit : Page
    {
        MemberImpl _memberImpl;
        Member _member;
        Measures _measures;

        protected void Page_Load(object sender, EventArgs e)
        {
            _member = Session["EditMember"] as Member;
            _measures = Session["EditMeasures"] as Measures;
            if(_member != null && _measures != null)
            {
                txtId.Text = _member.Id.ToString();
                txtName.Text = HttpUtility.HtmlDecode(_member.Name);
                txtLastName.Text = HttpUtility.HtmlDecode(_member.LastName);
                txtSecondLastName.Text = HttpUtility.HtmlDecode(_member.SecondLastName);
                txtWeight.Text = _measures.Weight.ToString();
                txtChest.Text = _measures.ChestMeasure.ToString();
                txtArms.Text = _measures.ArmMeasure.ToString();
                txtLeg.Text = _measures.LegMeasure.ToString();
                txtWaist.Text = _measures.Waist.ToString();
                Session.Remove("EditMember");
                Session.Remove("EditMeasures");
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            _memberImpl = new MemberImpl();

            _member = new Member()
            {
                Name = txtName.Text,
                LastName = txtLastName.Text,
                SecondLastName = txtSecondLastName.Text
            };

            _measures = new Measures()
            {
                Weight = double.Parse(txtWeight.Text),
                ChestMeasure = double.Parse(txtChest.Text),
                ArmMeasure = double.Parse(txtArms.Text),
                LegMeasure = double.Parse(txtLeg.Text),
                Waist = double.Parse(txtWaist.Text)
            };

            try
            {
                if (_memberImpl.Update(_member, _measures) > 0)
                {
                    Response.Redirect("Members");
                }
                _member = null;
                _measures = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Members");
        }
    }
}