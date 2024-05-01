﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskerProject.Data.Models;
using TaskerProject.Business.Services.Interfaces;
using TaskerProject.Data.Gateways.Interfaces;

namespace TaskerProject.Business.Services
{
	public class TaskerService : ITaskerService
	{
		private readonly ITaskerGateway _context;
		public TaskerService(ITaskerGateway context)
		{
			_context = context;
		}
		
		public IEnumerable<Tasks> GetAllTasks()
		{
			return _context.GetAllTasks();
		}

		public Tasks GetTasktById(int id)
		{
			return _context.GetTasktById(id);
		}
		public Tasks AddTask(Tasks task)
		{
			_context.AddTask(task);
			return task;
		}

		public Tasks UpdateTask(int id, Tasks task)
		{
			var existingTask = _context.GetTasktById(id);
			if (existingTask != null)
			{
				_context.UpdateTask(id, task);
				return existingTask;
			}
			return null;
		}
		public void DeleteTask(int id)
		{
			_context.DeleteTask(id);
		}
	}
}
