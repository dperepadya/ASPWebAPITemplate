// <copyright file="ToDoTask.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ASPWebAPITemplate.Models
{
#pragma warning disable SA1600
    public class ToDoTask
    {
        public int Id { get; set; }

        public string? TaskID { get; set; }

        public string? TaskName { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string? Status { get; set; }
    }
#pragma warning restore SA1600
}
