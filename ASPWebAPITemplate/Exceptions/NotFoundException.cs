// <copyright file="NotFoundException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ASPWebAPITemplate.Exceptions
{
#pragma warning disable SA1600
    public class NotFoundException : ToDoException
    {
        public NotFoundException(string entityName)
            : this(entityName, null)
        {
        }

        public NotFoundException(string entityName, string? msg)
            : base(msg)
        {
            this.EntityName = entityName;
        }

        public string EntityName { get; set; }
    }

#pragma warning restore SA1600
}
