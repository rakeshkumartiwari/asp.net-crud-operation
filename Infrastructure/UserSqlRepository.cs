using System.Data;
using System.Data.SqlClient;
using Domain;
namespace Infrastructure
{
    public class UserSqlRepository
    {
        const string ConnectionString = @"Data Source=DESKTOP-I6O9RHK\SQLEXPRESS;Initial Catalog=GridViewDataBase;Integrated Security=true";

        public void Save(User user)
        {
            using (var objConnection = new SqlConnection(ConnectionString))
            {
                objConnection.Open();
                SqlCommand objCommand = new SqlCommand("sp_Save",objConnection);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@EmployeeId", user.Id);
                objCommand.Parameters.AddWithValue("@Name", user.Name);
                objCommand.Parameters.AddWithValue("@Gender", user.Gender);
                objCommand.Parameters.AddWithValue("@State", user.State);
                

                //objCommand.Connection = objConnection;
                //objCommand.CommandText = "insert into EmployeeTable values('" + user.Id + "','" + user.Name + "','" + user.Gender + "','" + user.State + "')";
                objCommand.ExecuteNonQuery();
            }

        }

        public DataSet GetUser(string usertId)
        {
            using (var objConnection = new SqlConnection(ConnectionString))
            {
                objConnection.Open();
                SqlCommand objCommand = new SqlCommand("sp_GetSingleEmployee", objConnection);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@EmployeeId", usertId);
                DataSet objdataSet = new DataSet();
                SqlDataAdapter objAdapter = new SqlDataAdapter(objCommand);
                objAdapter.Fill(objdataSet);
                return objdataSet;
            }
        }
        public DataSet GetAllUsers()
        {
            using (var objConnection = new SqlConnection(ConnectionString))
            {
                objConnection.Open();
                SqlCommand objCommand = new SqlCommand("sp_GetEmployees", objConnection);
                objCommand.CommandType = CommandType.StoredProcedure;
                DataSet objdataSet = new DataSet();
                SqlDataAdapter objAdapter = new SqlDataAdapter(objCommand);
                objAdapter.Fill(objdataSet);
                return objdataSet;
            }
        }

        public void UpdateUser(User user)
        {
            using (var objConnection = new SqlConnection(ConnectionString))
            {
                objConnection.Open();
                SqlCommand objCommand = new SqlCommand("sp_Update",objConnection);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@EmployeeId", user.Id);
                objCommand.Parameters.AddWithValue("@Name", user.Name);
                objCommand.Parameters.AddWithValue("@Gender", user.Gender);
                objCommand.Parameters.AddWithValue("@State", user.State);
                //objCommand.Connection = objConnection;
                //objCommand.CommandText = "update EmployeeTable set Name='" + user.Name + "',Gender='" + user.Gender +
                //                         "',State='" + user.State + "' where EmployeeId='" + user.Id + "'";
                objCommand.ExecuteNonQuery();
            }
        }

        public void DeleteUser(string userId)
        {
            using (var objConnection = new SqlConnection(ConnectionString))
            {
                objConnection.Open();
                SqlCommand objCommand = new SqlCommand("sp_Delete", objConnection);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@EmployeeId", userId);
                //SqlCommand objCommand = new SqlCommand();
                //objCommand.Connection = objConnection;
                //objCommand.CommandText = "delete EmployeeTable where EmployeeId='" + userId +
                //"'";
                objCommand.ExecuteNonQuery();
            }
        }

    }
}
