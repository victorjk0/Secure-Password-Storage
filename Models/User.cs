using System;
using System.Collections.Generic;
using System.Text;

namespace Secure_Password_Storage.Models
{
    class User
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public User(string uname, string passwd)
        {
            this.Username = uname;
            this.Password = passwd;
        }
    }
}
