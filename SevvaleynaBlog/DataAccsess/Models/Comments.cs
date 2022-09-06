using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsess.Models
{
    public class Comments
    {
        public int Id { get; set; }
        public int BlogsId { get; set; }
        public string Commenter { get; set; } 
        public DateTime CommentDate { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        public Blogs Blogs { get; set; } 
        public string UserComment { get; set; }
    }
}
