﻿using DataAccsess.Abstract;
using DataAccsess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICommentService:IRepository<Comments>
    {
    }
}
