using Business.Abstract;
using DataAccsess.Concrete;
using DataAccsess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BlogService:Repository<Blogs>, IBlogService
    {
        public BlogService(BlogContext context) : base(context)
        {

        }
    }
}
