using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace machine_test_application_mvc.Models
{
    public class User
    {
        public int Id { get; set; }
        public string EmployeeId{ get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string State { get; set; }
    }
}