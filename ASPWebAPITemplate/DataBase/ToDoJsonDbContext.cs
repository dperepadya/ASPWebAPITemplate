// <copyright file="ToDoJsonDbContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ASPWebAPITemplate.DataBase
{
    using ASPWebAPITemplate.Exceptions;
    using ASPWebAPITemplate.Mapping;
    using ASPWebAPITemplate.Models;
    using Newtonsoft.Json;

#pragma warning disable SA1600

    public class ToDoJsonDbContext : ToDoContext
    {
        private const string DefaultFileName = @"ToDoDB.json";

        private readonly IMapper? mapper;

        private readonly string? fileName;

        private bool modelIsLoaded;

        public ToDoJsonDbContext(IConfiguration configuration, IMapper mapper)
            : base(configuration)
        {
            this.mapper = mapper;

            string fileName = this.Configuration.GetValue<string>("Parameters:JsonStorageFile");

            if (fileName == null || fileName.Length == 0)
            {
                fileName = DefaultFileName;
            }

            this.fileName = System.IO.Path.Combine(Directory.GetCurrentDirectory(), fileName);
        }

        public List<ToDoTask>? Tasks { get; set; } = new();

        public async Task<bool> LoadDataModel()
        {
            if (this.modelIsLoaded)
            {
                return true;
            }

            this.Tasks = await this.LoadAsync();

            if (this.Tasks == null || this.Tasks.Count == 0)
            {
                return false;
            }

            this.modelIsLoaded = true;

            return true;
        }

        public override async Task<bool> SaveChangesAsync()
        {
            if (this.Tasks == null || this.Tasks.Count == 0)
            {
                return false;
            }

            try
            {
                if (string.IsNullOrEmpty(this.fileName))
                {
                    throw new IsNullOrEmptyException("Please define a JSON file to store data in the Configuration file");
                }

                if (System.IO.File.Exists(this.fileName) == false)
                {
                    using System.IO.FileStream fs = System.IO.File.Create(this.fileName);
                }

                var data = new DbParseObject() { Tasks = this.mapper!.Map(this.Tasks)!.ToArray() };

                string json = JsonConvert.SerializeObject(data, new JsonSerializerSettings
                {
                    DateFormatString = "dd/MM/yyyy HH:mm:ss",
                });

                if (json.Length > 0)
                {
                    using StreamWriter writer = new(this.fileName, false);
                    await writer.WriteAsync(json);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("SaveChangesAsync method common exception ", ex);
            }

            return true;
        }

        public async Task<List<ToDoTask>?> LoadAsync()
        {
            List<ToDoTask>? result = null;
            try
            {
                _ = this.Tasks ?? throw new IsNullOrEmptyException("Tasks list is empty");

                if (string.IsNullOrEmpty(this.fileName))
                {
                    throw new IsNullOrEmptyException("Please define a JSON file to store data in the Configuration file");
                }

                if (System.IO.File.Exists(this.fileName) == false)
                {
                    return null;
                }

                DbParseObject? parseResult = null;

                using StreamReader reader = new(this.fileName);

                string json = await reader.ReadToEndAsync();

                if (json.Length > 0)
                {
                    parseResult = JsonConvert.DeserializeObject<DbParseObject>(json, new JsonSerializerSettings
                    {
                        DateFormatString = "dd/MM/yyyy HH:mm:ss",
                    });
                }

                if (parseResult == null || parseResult.Tasks == null || parseResult.Tasks.Length == 0)
                {
                    return result;
                }

                result = this.mapper!.Map(parseResult.Tasks.ToList());
            }
            catch (Exception ex)
            {
                throw new Exception("LoadAsync method common exception ", ex);
            }

            return result;
        }
    }
#pragma warning restore SA1600
}
