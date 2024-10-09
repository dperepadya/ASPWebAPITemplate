// <copyright file="ToDoMsSqlDbRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ASPWebAPITemplate.Repository
{
    using System.Collections.Generic;
    using System.Linq;
    using ASPWebAPITemplate.DataBase;
    using ASPWebAPITemplate.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

#pragma warning disable SA1600
    public class ToDoMsSqlDbRepository : IToDoRepository
    {
        private readonly ToDoMsSqlDbContext dbContext;

        public ToDoMsSqlDbRepository(ToDoMsSqlDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<ToDoTask>?> GetAllAsync()
        {
            if (this.dbContext == null)
            {
                return null;
            }

            var result = await this.dbContext.Tasks!.ToListAsync();
            return result;
        }

        public async Task<ToDoTask?> GetAsync(string id)
        {
            if (this.dbContext == null)
            {
                return null;
            }

            return await this.dbContext.Tasks!.FirstOrDefaultAsync(f => f.TaskID == id);
        }

        public async Task<bool> AddAsync(ToDoTask task)
        {
            if (this.dbContext == null || this.dbContext.Tasks == null || task == null)
            {
                return false;
            }

            this.dbContext.Tasks.Add(task);

            return await this.dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(ToDoTask task)
        {
            if (this.dbContext.Tasks == null || task == null)
            {
                return false;
            }

            var tasks = await this.dbContext.Tasks!.ToListAsync();

            if (tasks.Count == 0)
            {
                return false;
            }

            int index = tasks.FindIndex(f => f.TaskID == task.TaskID);

            if (index < 0)
            {
                return false;
            }

            tasks[index] = task;

            return await this.dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var task = await this.GetAsync(id);

            if (this.dbContext.Tasks == null || task == null)
            {
                return false;
            }

            var tasks = this.dbContext.Tasks.ToList();

            if (tasks.Count == 0)
            {
                return false;
            }

            this.dbContext.Tasks.Remove(task);

            return await this.dbContext.SaveChangesAsync() > 0;
        }
    }

#pragma warning restore SA1600
}
