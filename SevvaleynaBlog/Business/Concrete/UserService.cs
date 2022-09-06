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
    public class UserService:Repository<Users>, IUserService
    {
        public UserService(BlogContext contex):base(contex)
        {

        }
    }
}
