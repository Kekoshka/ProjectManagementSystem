using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectManagmentSystem.Common.DataValidation
{
    internal class UserValidator : AbstractValidator<Models.User>
    {
        public UserValidator() 
        {
            RuleFor(u => u.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Укажите имя пользователя")
                .Matches(@"^[A-Яа-яA-Za-z]+$")
                .WithMessage("Имя пользователя должно содержать только буквы");
            RuleFor(u => u.Surname)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Укажите имя пользователя")
                .Matches(@"^[A-Яа-яA-Za-z]+$")
                .WithMessage("Имя пользователя должно содержать только буквы");
            RuleFor(u => u.Patronumic)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Укажите имя пользователя")
                .Matches(@"^[A-Яа-яA-Za-z]+$")
                .WithMessage("Имя пользователя должно содержать только буквы");
            RuleFor(u => u.Mail)
                .EmailAddress()
                .WithMessage("Почта должна соответствовать формату example@mail.com");
            RuleFor(u => u.Password)
                .Matches(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$")
                .WithMessage("Пароль должен содержать минимум одну цифру, строчную и заглавную буквы, специальный символ и быть длинной не менее восьми символов и состоять из букв латинского алфавита");
        }
    }
}
