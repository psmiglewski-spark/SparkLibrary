using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SparkLibrary.Web;

namespace Spark.Invoice.Data.Models
{
    public enum UserRoles
    {
        Administrator = 0,
        SuperAdmin = -1,
        User = 1
    }

    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value.Hash();
            }
        }
        public UserRoles UserRole { get; set; }
    }
}
