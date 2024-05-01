using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TaskerProject.Data.Models;
using TaskerProject.Business.Services.Interfaces;

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
			var tasks = _taskerService.GetAllTasks();
			return Ok(tasks);
		}

		[HttpGet]
		[Route("get/{id}")]
		public IActionResult GetTasktById(int id)
		{
			var task = _taskerService.GetTasktById(id);
			if (task == null)
			{
				return NotFound();
			}
			return Ok(task);
		}

		[HttpPost]
		[Route("add")]
		public IActionResult AddTask([FromBody] Tasks task)
		{
			try
			{
				//log info - Adding new task 
				var addedTask = _taskerService.AddTask(task);
				return CreatedAtAction(nameof(GetTasktById), new { id = addedTask.Id }, addedTask);
			}
			catch(Exception ex)
			{
				//return error code
			}
		}

		[HttpPut]
		[Route("update/{id}")]
		public IActionResult UpdateTask(int id, [FromBody] Tasks task)
		{
			var updatedTask = _taskerService.UpdateTask(id, task);
			if (updatedTask == null)
			{
				return NotFound();
			}
			return Ok(updatedTask);
		}

		[HttpDelete]
		[Route("delete/{id}")]
		public IActionResult DeleteTask(int id)
		{
			_taskerService.DeleteTask(id);
			return NoContent();
		}
	}
}
