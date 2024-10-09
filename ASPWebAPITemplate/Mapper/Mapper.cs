// <copyright file="Mapper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ASPWebAPITemplate.Mapping
{
    using ASPWebAPITemplate.Models;

#pragma warning disable SA1600
    public class Mapper : IMapper
    {
        public ToDoTask Map(ToDoTaskModel model)
        {
            return new ToDoTask()
            {
                Id = model.Id,
                TaskID = model.TaskID,
                TaskName = model.TaskName,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Status = model.Status,
            };
        }

        public List<ToDoTaskModel> Map(List<ToDoTask> tasks)
        {
            var result = new List<ToDoTaskModel>();
            foreach (var task in tasks)
            {
                result.Add(this.Map(task));
            }

            return result;
        }

        public ToDoTaskModel Map(ToDoTask task)
        {
            return new ToDoTaskModel()
            {
                Id = task.Id,
                TaskID = task.TaskID,
                TaskName = task.TaskName,
                StartDate = task.StartDate,
                EndDate = task.EndDate,
                Status = task.Status,
            };
        }

        public List<ToDoTask> Map(List<ToDoTaskModel> models)
        {
            var result = new List<ToDoTask>();
            foreach (var model in models)
            {
                result.Add(this.Map(model));
            }

            return result;
        }
    }
#pragma warning restore SA1600
}
