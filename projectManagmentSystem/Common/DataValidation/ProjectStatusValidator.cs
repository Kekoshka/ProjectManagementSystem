using FluentValidation;
using projectManagmentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectManagmentSystem.Common.DataValidation
{
    internal class ProjectStatusValidator : AbstractValidator<ProjectStatus>
    {
        public ProjectStatusValidator()
        {
            RuleFor(ps => ps.Name)
                .NotEmpty()
                .WithMessage("Укажите название статуса");
        }
    }
}
