using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using projectManagmentSystem.Models;
using FluentValidation;

namespace projectManagmentSystem.Common.DataValidation
{
    internal class ProjectValidator : AbstractValidator<Project>
    {
        public ProjectValidator() 
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("Укажите название проекта");
        }

    }
}
