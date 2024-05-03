using Microsoft.AspNetCore.Mvc;
using TaskerProject.Data.Models;
using TaskerProject.Business.Services.Interfaces;
using Serilog;

namespace TaskerProject.Main.Controllers
{
	[Route("api/tasker")]
	public class TaskerController : ControllerBase
	{
		private readonly ITaskerService _taskerService;
		public TaskerController(ITaskerService taskerService)
		{
			_taskerService = taskerService;
		}

		[HttpGet]
		[Route("getall")]
		public IActionResult GetAllTasks()
		{
			try
			{
				var tasks = _taskerService.GetAllTasks();
				return Ok(tasks);
			}
			catch (Exception ex)
			{
				// Log the exception
				Log.Error(ex, "An error occurred while retrieving all tasks.");
				return StatusCode(500, "An unexpected error occurred while retrieving all tasks.");
			}
		}

		[HttpGet]
		[Route("get/{id}")]
		public IActionResult GetTasktById(int id)
		{
			try
			{
				var task = _taskerService.GetTasktById(id);
				if (task == null)
				{
					Log.Information("Couldn't find task with id:{@id}", id);
					return NotFound();
				}
				return Ok(task);
			}
			catch (Exception ex)
			{
				// Log the exception or handle it appropriately
				Log.Error(ex, "An error occurred while updating the task with ID {TaskId}", id);
				return StatusCode(500, "An unexpected error occurred.");
			}
		}

		[HttpPost]
		[Route("add")]
		public IActionResult AddTask([FromBody] Tasks task)
		{
			try
			{
				var addedTask = _taskerService.AddTask(task);
				return CreatedAtAction(nameof(GetTasktById), new { id = addedTask.Id }, addedTask);
			}
			catch (Exception ex)
			{
				// Log the exception
				Log.Error(ex, "An error occurred while adding a new task.");
				return StatusCode(500, "An unexpected error occurred while adding a new task.");
			}
		}

		[HttpPut]
		[Route("update/{id}")]
		public IActionResult UpdateTask(int id, [FromBody] Tasks task)
		{
			try
			{
				var updatedTask = _taskerService.UpdateTask(id, task);
				if (updatedTask == null)
				{
					Log.Information("Couldn't find and update task with id:{@id}", id);
					return NotFound();
				}
				return Ok(updatedTask);
			}
			catch (Exception ex)
			{
				// Log the exception
				Log.Error(ex, "An error occurred while updating the task with ID {TaskId}", id);
				return StatusCode(500, "An unexpected error occurred while updating the task.");
			}
		}

		[HttpDelete]
		[Route("delete/{id}")]
		public IActionResult DeleteTask(int id)
		{
			try
			{
				_taskerService.DeleteTask(id);
				return NoContent();
			}
			catch (Exception ex)
			{
				// Log the exception
				Log.Error(ex, "An error occurred while deleting the task with ID {TaskId}", id);
				return StatusCode(500, "An unexpected error occurred while deleting the task.");
			}
		}
	}
}
