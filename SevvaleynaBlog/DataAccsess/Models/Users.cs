using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsess.Models
{
    public class Users
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }

        public string FullAdress { get; set; }

        public string Linkedin { get; set; }

        public string Instagram { get; set; }

        public string Github { get; set; }

        public string Twitter { get; set; }

        public IList<Blogs> Blogs { get; set; }
    }
}
