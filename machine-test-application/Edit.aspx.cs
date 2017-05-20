using System;
using Infrastructure;
using Domain;
using System.Data;
using  System.Data.SqlClient;

namespace machine_test_application
{
    public partial class Edit : System.Web.UI.Page
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
                        txtName.Text = row["Name"].ToString();
                        string gender = row["Gender"].ToString();
                        string state = row["State"].ToString();
                        if (gender == "Male")
                        {
                            RadioButtonMale.Checked = true;
                        }
                        if (gender == "Female")
                        {
                            RadioButtonFeamle.Checked = true;
                        }
                        DropDownList1.SelectedValue = state;
                    }
                }
           
            }
          

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            User objUser = new User();
            objUser.Id = Session["SelectedId"].ToString();
            objUser.Name = txtName.Text;
            if (RadioButtonMale.Checked)
            {
                objUser.Gender = "Male";
            }
            if (RadioButtonFeamle.Checked)
            {
                objUser.Gender = "Female";
            }
            objUser.State = DropDownList1.SelectedValue.ToString();
            _objRepository.UpdateUser(objUser);
            Clear();
            Response.Redirect("~/RegisteredEmployee.aspx");

        }
        private void Clear()
        {
            txtName.Text = "";
            RadioButtonMale.Checked = false;
            RadioButtonFeamle.Checked = false;
            DropDownList1.SelectedIndex = 0;

        }
    }
}