// <copyright file="TaskController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ASPWebAPITemplate.Controllers
{
    using System.Threading.Tasks;
    using ASPWebAPITemplate.CQRSModel;
    using ASPWebAPITemplate.Exceptions;
    using ASPWebAPITemplate.JWT;
    using ASPWebAPITemplate.Models;
    using ASPWebAPITemplate.Resources;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Localization;

#pragma warning disable SA1600

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IAuthService jWTManager;
        private readonly IStringLocalizer<Resource>? localizer;

        public TaskController(IMediator mediator, IAuthService jWTManager, IStringLocalizer<Resource> localizer)
        {
            this.mediator = mediator;
            this.jWTManager = jWTManager;
            this.localizer = localizer;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public ActionResult<string> GetToken([FromBody] User user)
        {
            try
            {
                var token = this.jWTManager.TryToLogin(user);

                if (!string.IsNullOrEmpty(token))
                {
                    return this.Ok(token);
                }
            }
            catch
            {
                // return this.BadRequest($"{{\"errror\": \"cannot get the JWT token\"}}");
                throw new AuthenticationException("Login", "cannot get the JWT token");
            }

            return this.Unauthorized();
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<GetAllResponse>> GetAll()
        {
            var result = await this.mediator!.Send(new GetAllRequest());
            if (result.Tasks == null)
            {
                // return this.StatusCode(StatusCodes.Status500InternalServerError);
                throw new IsNullOrEmptyException("GetAll", this.localizer!["EmptyTaskList"]);
            }

            return result;
        }

        [AllowAnonymous]
        [HttpGet("{taskId}")]
        public async Task<ActionResult<GetResponse>> Get(string taskId)
        {
            var result = await this.mediator!.Send(new GetRequest() { Id = taskId });
            if (result.Task == null)
            {
                // return this.BadRequest($"{{\"errror\": \"cannot get the task with id {taskId}\"}}");
                throw new NotFoundException("Get", $"{this.localizer!.GetString("CannotGetTask").Value} {taskId}");
            }

            return result;
        }

        [HttpPost]
        public async Task<ActionResult<AddResponse>> Add([FromBody] ToDoTask task)
        {
            var result = await this.mediator!.Send(new AddRequest() { Task = task });

            if (!result.Result)
            {
                // return this.BadRequest($"{{\"errror\": \"cannot add the task {task.TaskID}\"}}");
                throw new RepositoryAccessException("Add", $"cannot Add the task {task.TaskID}");
            }

            return this.Ok($"{{\"result\": \"the task with Id {task.TaskID} was successfully added\"}}");
        }

        [HttpPut]
        public async Task<ActionResult<UpdateResponse>> Update([FromBody] ToDoTask task)
        {
            var result = await this.mediator!.Send(new UpdateRequest() { Task = task });

            if (!result.Result)
            {
                // return this.BadRequest($"{{\"errror\": \"cannot update the task with id {task.TaskID}\"}}");
                throw new NotFoundException("Get", $"cannot Update the task with id {task.TaskID}");
            }

            return this.Ok($"{{\"result\": \"the task with Id {task.TaskID} was successfully updated\"}}");
        }

        [HttpDelete("{taskId}")]
        public async Task<ActionResult<DeleteResponse>> Delete(string taskId)
        {
            var result = await this.mediator!.Send(new DeleteRequest() { Id = taskId });

            if (!result.Result)
            {
                // return this.BadRequest($"{{\"errror\": \"cannot delete the task with id {taskId}\"}}");
                throw new NotFoundException("Get", $"cannot Delete the task with id {taskId}");
            }

            return this.Ok($"{{\"result\": \"the task with Id {taskId} was successfully removed\"}}");
        }
    }
#pragma warning restore SA1600
}
