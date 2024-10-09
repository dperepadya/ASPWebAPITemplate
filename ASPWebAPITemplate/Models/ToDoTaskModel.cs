// <copyright file="ToDoTaskModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ASPWebAPITemplate.Models
{
    using Newtonsoft.Json;

#pragma warning disable SA1600
#pragma warning disable SA1402
    public class ToDoTaskModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("taskid")]
        public string? TaskID { get; set; }

        [JsonProperty("taskname")]
        public string? TaskName { get; set; }

        [JsonProperty("startDate")]

        public DateTime? StartDate { get; set; }

        [JsonProperty("endDate")]
        public DateTime? EndDate { get; set; }

        [JsonProperty("status")]
        public string? Status { get; set; }
    }

    public class DbParseObject
    {
        [JsonProperty("tasks")]
        public ToDoTaskModel[]? Tasks { get; set; }
    }
#pragma warning restore SA1600
#pragma warning restore SA1402
}
