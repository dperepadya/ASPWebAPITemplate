// <copyright file="IToDoRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ASPWebAPITemplate.Repository
{
    using ASPWebAPITemplate.Models;

#pragma warning disable SA1600
    public interface IToDoRepository
    {
        Task<bool> AddAsync(ToDoTask task);

        Task<bool> DeleteAsync(string id);

        Task<List<ToDoTask>?> GetAllAsync();

        Task<ToDoTask?> GetAsync(string id);

        Task<bool> UpdateAsync(ToDoTask task);
    }
#pragma warning restore SA1600
}