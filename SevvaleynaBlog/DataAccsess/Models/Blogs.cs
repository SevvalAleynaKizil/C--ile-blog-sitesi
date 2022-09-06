using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsess.Models
{
    public class Blogs
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Images { get; set; }

        public string Explanation { get; set; }

        public DateTime BlogDateTime { get; set; }

        public int UserId { get; set; }

        public bool Status { get; set; }

        public Users Users { get; set; }

        public IList<Comments> Comments { get; set; }

        public IList<Interaction> Interactions { get; set; }

    }
}
