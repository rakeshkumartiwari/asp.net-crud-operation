using System;
using System.Web.UI.WebControls;
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

                    txtName.Text = objDataSet.Tables[0].Rows[0]["Name"].ToString();
                    string gender = objDataSet.Tables[0].Rows[0]["Gender"].ToString();
                    string state = objDataSet.Tables[0].Rows[0]["State"].ToString();
                     foreach (ListItem item in RadioButtonList1.Items)
                     {
                         if (item.Text == gender)
                         {
                             item.Selected = true;
                         }
                     }
                     DropDownList1.SelectedValue = state;
                    //foreach (DataRow row in objDataSet.Tables[0].Rows)
                    //{
                    //    txtName.Text = row["Name"].ToString();
                    //    string gender = row["Gender"].ToString();
                    //    string state = row["State"].ToString();
                    //    foreach (ListItem item in RadioButtonList1.Items)
                    //    {
                    //        if (item.Text == gender)
                    //        {
                    //            item.Selected = true;
                    //        }
                    //    }
                    //    DropDownList1.SelectedValue = state;
                    //}
                }
           
            }
          

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            User objUser = new User();
            objUser.Id = Session["SelectedId"].ToString();
            objUser.Name = txtName.Text;
            foreach (ListItem item in RadioButtonList1.Items)
            {
                if (item.Selected)
                {
                    objUser.Gender = item.Text;
                }
            }
            objUser.State = DropDownList1.SelectedValue.ToString();
            _objRepository.UpdateUser(objUser);
           
            Response.Redirect("~/RegisteredEmployee.aspx");

        }
      
    }
}