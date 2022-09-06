
using DataAccsess.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.FluentValidations
{
    public class ValidationUsers:AbstractValidator<Users>
    {
        public ValidationUsers()
        {
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Max 50 Karakter Gİrilsin");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Minimum 3 Karakter girilmeli");

            RuleFor(x => x.Instagram).MaximumLength(150).WithMessage("Max 150 KArakter girebilirsiniz");
            RuleFor(x => x.Twitter).MaximumLength(150).WithMessage("Max  150 karakter");
            RuleFor(x => x.Linkedin).MaximumLength(150).WithMessage("Max  150 Karakter");
            RuleFor(x => x.Github).MaximumLength(150).WithMessage("Max 150 Karakter");

            RuleFor(x => x.Password).MaximumLength(30).WithMessage("Max 30 karakter olmalı");
            RuleFor(x => x.Password).MinimumLength(10).WithMessage("Minimum 10 karakter olmalı");

            RuleFor(x => x.Phone).MaximumLength(15).WithMessage("Max 15 karakter Olmalı");
            RuleFor(x => x.Phone).MinimumLength(11).WithMessage("Minimum 11 KAakter Olmalı");

            RuleFor(x => x.Email).MaximumLength(150).WithMessage("Max 150 Karakter olmalı");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Doğru Mail Adresi giriniz");

            RuleFor(x => x.FullAdress).MaximumLength(250).WithMessage("Max 250 Karakter girilebilir");
            RuleFor(x => x.FullAdress).MinimumLength(20).WithMessage("Minimum 20 Karakter girilmeli");

            //RuleFor(x => x.Email).Must(x => x.Equals("admin@admin.com")).WithMessage("Bu mail ile üyelik açamazsınız");



        }
    }
}
