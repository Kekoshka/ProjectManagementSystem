using FluentValidation;
using projectManagmentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectManagmentSystem.Common.DataValidation
{
    internal class SubtaskValidator : AbstractValidator<Subtask>
    {
        public SubtaskValidator() 
        {
            RuleFor(s => s.Name)
                .NotEmpty()
                .WithMessage("Укажите название подзадачи");
        }
    }
}
