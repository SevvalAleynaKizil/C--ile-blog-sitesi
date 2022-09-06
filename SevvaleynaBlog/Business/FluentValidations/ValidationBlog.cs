
using DataAccsess.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.FluentValidations
{
    public class ValidationBlog:AbstractValidator<Blogs>
    {
        public ValidationBlog()
        {
            RuleFor(x => x.Name).MaximumLength(150).WithMessage("Maximum 150 Karakter girebilirsiniz");

            //hiç bilgi girmediği zaman kabul etmeyen
            //RuleFor(x => x.Name).NotEmpty().WithMessage("Blog adı girmelisniz");

            RuleFor(x => x.Name).MinimumLength(20).WithMessage("Minimum 20 Karakter girmelisniz");

            RuleFor(x => x.Name).EmailAddress().WithMessage("Doğru EMail giriniz");
            RuleFor(x => x.Name).CreditCard().WithMessage("Doğru kredi kartı bilgisi giriniz");



        }
    }
}
