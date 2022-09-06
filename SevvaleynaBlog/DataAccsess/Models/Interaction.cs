using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsess.Models
{
    public class Interaction
    {
        public int Id { get; set; }
        public int BlogsId { get; set; }
        public bool Status { get; set; } 
        public string IpAddress { get; set; }
        public Blogs Blogs { get; set; } 
    }
}
