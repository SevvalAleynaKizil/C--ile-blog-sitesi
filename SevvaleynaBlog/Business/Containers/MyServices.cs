using Business.Abstract;
using Business.Concrete;
using Business.FluentValidations;
using DataAccsess.Concrete;
using DataAccsess.Models;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Containers
{
    public static class MyServices
    {
        public static IServiceCollection MyServiceInstance(this IServiceCollection services)
        {
            services.AddDbContext<BlogContext>();
            services.AddScoped<IBlogService, BlogService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IInteractionService, InteractionService>();
            services.AddScoped<IUserService, UserService>();

            services.AddSingleton<IValidator<Blogs>, ValidationBlog >();
            services.AddSingleton<IValidator< Comments>, ValidationComment>();
            services.AddSingleton<IValidator<Users>, ValidationUsers>();



            return services;

        }
    }
}
