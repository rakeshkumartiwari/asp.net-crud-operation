using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Domain;
namespace Infrastructure
{
   public interface IUserRepository
    {
       void Save(User user);
       User GetUser(string userId);
       object GetAllUsers();
    }
}
