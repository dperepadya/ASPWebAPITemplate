// <copyright file="AuthenticationException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ASPWebAPITemplate.Exceptions
{
#pragma warning disable SA1600
    public class AuthenticationException : ToDoException
    {
        public AuthenticationException(string entityName)
            : this(entityName, null)
        {
        }

        public AuthenticationException(string entityName, string? msg)
            : base(msg)
        {
            this.EntityName = entityName;
        }

        public string EntityName { get; set; }
    }

#pragma warning restore SA1600
}
