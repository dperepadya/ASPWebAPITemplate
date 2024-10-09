// <copyright file="IMapper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ASPWebAPITemplate.Mapping
{
    using System.Collections.Generic;
    using ASPWebAPITemplate.Models;

#pragma warning disable SA1600
    public interface IMapper
    {
        public ToDoTask Map(ToDoTaskModel model);

        public ToDoTaskModel Map(ToDoTask task);

        public List<ToDoTask>? Map(List<ToDoTaskModel> toDoTaskModels);

        public List<ToDoTaskModel>? Map(List<ToDoTask> toDoTasks);
    }
#pragma warning restore SA1600
}
