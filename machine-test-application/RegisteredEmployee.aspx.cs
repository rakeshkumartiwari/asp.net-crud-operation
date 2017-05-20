using System;
using System.Web.UI.WebControls;
using Infrastructure;
using Domain;

namespace machine_test_application
{
    public partial class RegisteredEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UserSqlRepository objRepository = new UserSqlRepository();
                GridView1.DataSource = objRepository.GetAllUsers();
                GridView1.DataBind();
            }
        }

        protected void GridView1_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            var dataKey = GridView1.DataKeys[e.NewEditIndex];
            if (dataKey != null)
            {
               Session["SelectedId"]  = dataKey.Value.ToString();
            }

            Response.Redirect("~/Edit.aspx");
        }

        protected void GridView1_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var dataKey = GridView1.DataKeys[e.RowIndex];
            if (dataKey != null)
            {
                Session["SelectedId"] = dataKey.Value.ToString();
            }
            Response.Redirect("~/Delete.aspx");
        }
    }
}