using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Assistent
{
    class User
    {
        public string Username { get; }
        public string Password { get; }
        public string Id { get; }
        public User(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }
        public User() { }
        public override string ToString()
        {
            return Username;
        }
    }
}
