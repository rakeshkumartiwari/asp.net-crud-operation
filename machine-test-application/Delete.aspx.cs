using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain;
using System.Data;
using Infrastructure;

namespace machine_test_application
{
    public partial class Delete : System.Web.UI.Page
    {
        UserSqlRepository _objRepository = new UserSqlRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["SelectedId"] != null)
                {
                    string selectedUserId = Session["SelectedId"].ToString();

                    DataSet objDataSet = _objRepository.GetUser(selectedUserId);

                    foreach (DataRow row in objDataSet.Tables[0].Rows)
                    {
                        lblName.Text = row["Name"].ToString();
                        string gender = row["Gender"].ToString();
                        lblState.Text= row["State"].ToString();
                        if (gender == "Male")
                        {
                            lblGender.Text = gender;
                        }
                        if (gender == "Female")
                        {
                            lblGender.Text = gender;
                        }
                        
                    }
                }

            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string selectedId = Session["SelectedId"].ToString();
           
            _objRepository.DeleteUser(selectedId);
            Response.Redirect("~/RegisteredEmployee.aspx");
        }
    }
}