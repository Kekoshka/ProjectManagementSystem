using FluentValidation.Results;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Http;
using projectManagmentSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace projectManagmentSystem.Common.DataValidation
{
    internal static class CommonValidator
    {
        private static ProjectValidator ProjectValidator = new ProjectValidator();
        private static SubtaskValidator SubtaskValidator = new SubtaskValidator();
        private static TaskValidator TaskValidator = new TaskValidator();
        private static UserValidator UserValidator = new UserValidator();
        private static ProjectStatusValidator ProjectStatusValidator = new ProjectStatusValidator();
        private static FluentValidation.Results.ValidationResult ValidateData(object model)
        {
            FluentValidation.Results.ValidationResult? result = new FluentValidation.Results.ValidationResult();
            switch(model)
            {
                case Project p:
                    result = ProjectValidator.Validate(p); return result;
                case Subtask s:
                    result = SubtaskValidator.Validate(s); return result;
                case Models.Task t:
                    result = TaskValidator.Validate(t); return result;
                case User u:
                    result = UserValidator.Validate(u); return result;
                case ProjectStatus ps:
                    result = ProjectStatusValidator.Validate(ps); return result;
                default:
                    return null;
            }
        }
        public static bool Validate(object models)
        {
            var result = ValidateData(models);
            if (result != default && result.IsValid == false)
            {
                string message = "";
                foreach (var error in result.Errors)
                    message += $"{error.ErrorMessage}\r\n";
                MessageBox.Show(message);
                return false;
            }
            else if(result.IsValid == true)
                return true;
            MessageBox.Show("Ошибка");
            return false;
        }
    }
}
