// <copyright file="ToDoContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ASPWebAPITemplate.DataBase
{
    using Microsoft.EntityFrameworkCore;

#pragma warning disable SA1600
    public class ToDoContext : DbContext
    {
        public ToDoContext(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        protected IConfiguration? Configuration { get; set; }

        public virtual async Task<bool> SaveChangesAsync() => await Task.Run(() => { return false; });
    }
#pragma warning restore SA1600
}
