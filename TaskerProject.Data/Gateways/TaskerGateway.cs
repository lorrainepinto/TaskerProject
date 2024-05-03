using TaskerProject.Data.Models;
using TaskerProject.Data.Data;
using TaskerProject.Data.Gateways.Interfaces;

namespace TaskerProject.Data.Gateways
{
	public class TaskerGateway : ITaskerGateway
	{   
		TasksContext context = new TasksContext();
		public Tasks AddTask(Tasks task)
		{
			context.Tasks.Add(task);
			context.SaveChanges();
			return task;
		}

		public void DeleteTask(int id)
		{
			var taskById = GetTasktById(id);
			context.Remove(taskById);
			context.SaveChanges();
		}

		public IEnumerable<Tasks> GetAllTasks()
		{
			var tasks = from task in context.Tasks
						select task;
			return tasks;
		}

		public Tasks GetTasktById(int id)
		{
			var taskById = (from task in context.Tasks
							 where task.Id == id
							 select task).FirstOrDefault();
			return taskById;
		}

		public Tasks UpdateTask(int id, Tasks newTask)
		{
			var taskById = GetTasktById(id);
			if (taskById is Tasks)
			{
				taskById.Id = newTask.Id;
				taskById.TaskName = newTask.TaskName;
				taskById.TaskDescription = newTask.TaskDescription;
				taskById.IsCompleted = newTask.IsCompleted;
				context.SaveChanges();
				return newTask;
			}
			return null;
		}
	}
}
