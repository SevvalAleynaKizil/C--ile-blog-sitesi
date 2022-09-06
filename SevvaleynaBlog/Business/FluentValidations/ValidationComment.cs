
using DataAccsess.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.FluentValidations
{
    public class ValidationComment:AbstractValidator<Comments>
    {
        public ValidationComment()
        {
            RuleFor(x => x.Commenter).MaximumLength(150).WithMessage("Max 150 Karakter girilmeli");
            RuleFor(x => x.Commenter).MinimumLength(5).WithMessage("Minimum 5 Karakter giriniz");

            RuleFor(x => x.Email).MaximumLength(50).WithMessage("Max 50 Karakter girilmeli");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email adresi formatı yanlış");

        }

    }
}
