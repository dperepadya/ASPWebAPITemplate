// <copyright file="ToDoJsonDbRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ASPWebAPITemplate.Repository
{
    using ASPWebAPITemplate.DataBase;
    using ASPWebAPITemplate.Models;

#pragma warning disable SA1600
    public class ToDoJsonDbRepository : IToDoRepository
    {
        private readonly ToDoJsonDbContext dbContext;

        public ToDoJsonDbRepository(ToDoJsonDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<ToDoTask>?> GetAllAsync()
        {
            if (this.dbContext == null || await this.dbContext.LoadDataModel() == false)
            {
                return null;
            }

            return this.dbContext.Tasks;
        }

        public async Task<ToDoTask?> GetAsync(string id)
        {
            if (this.dbContext == null || await this.dbContext.LoadDataModel() == false)
            {
                return null;
            }

            return this.dbContext.Tasks!.FirstOrDefault(f => f.TaskID == id);
        }

        public async Task<bool> AddAsync(ToDoTask task)
        {
            if (this.dbContext == null || this.dbContext.Tasks == null || task == null || await this.dbContext.LoadDataModel() == false)
            {
                return false;
            }

            this.dbContext.Tasks.Add(task);

            return await this.dbContext.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(ToDoTask task)
        {
            if (this.dbContext.Tasks == null || this.dbContext.Tasks.Count == 0 || task == null || await this.dbContext.LoadDataModel() == false)
            {
                return false;
            }

            int index = this.dbContext.Tasks.FindIndex(f => f.TaskID == task.TaskID);

            if (index < 0)
            {
                return false;
            }

            this.dbContext.Tasks[index] = task;

            return await this.dbContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var task = await this.GetAsync(id);

            if (this.dbContext.Tasks == null || this.dbContext.Tasks.Count == 0 || task == null || await this.dbContext.LoadDataModel() == false)
            {
                return false;
            }

            this.dbContext.Tasks.Remove(task);

            return await this.dbContext.SaveChangesAsync();
        }
    }

#pragma warning restore SA1600
}
