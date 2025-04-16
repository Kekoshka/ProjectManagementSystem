using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectManagmentSystem.Common.DataValidation
{
    internal class TaskValidator : AbstractValidator<Models.Task>
    {
        public TaskValidator() 
        {
            RuleFor(t => t.Name)
                .NotEmpty()
                .WithMessage("Укажите название задачи");
        }
    }
}
