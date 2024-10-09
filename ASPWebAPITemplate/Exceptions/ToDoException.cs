// <copyright file="ToDoException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ASPWebAPITemplate.Exceptions
{
#pragma warning disable SA1600

    public abstract class ToDoException : Exception
    {
        protected ToDoException()
        {
        }

        protected ToDoException(string? message)
            : base(message)
        {
        }
    }
#pragma warning restore SA1600
}
