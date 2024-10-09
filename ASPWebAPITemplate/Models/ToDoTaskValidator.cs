// <copyright file="ToDoTaskValidator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ASPWebAPITemplate.Models
{
#pragma warning disable SA1600
    using FluentValidation;

    public class ToDoTaskValidator : AbstractValidator<ToDoTask>
    {
        public ToDoTaskValidator()
        {
            this.RuleFor(x => x.Id).NotEmpty().WithMessage("Primary Key should be not empty");
            this.RuleFor(x => x.TaskID).NotEmpty().WithMessage("Task ID should be not empty");
            this.RuleFor(x => x.TaskName).NotEmpty().WithMessage("Task Name should be not empty");
            this.RuleFor(x => x.StartDate).NotEmpty().WithMessage("Start Date should be not empty");
            this.RuleFor(x => x.EndDate).NotEmpty().WithMessage("End Date should be not empty");
            this.RuleFor(x => x.Status).NotEmpty().WithMessage("Status should be not empty");
        }
    }
#pragma warning restore SA1600
}
