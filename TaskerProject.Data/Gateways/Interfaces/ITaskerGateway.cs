using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskerProject.Data.Models;

namespace TaskerProject.Data.Gateways.Interfaces
{
	public interface ITaskerGateway
	{
		IEnumerable<Tasks> GetAllTasks();
		Tasks GetTasktById(int id);
		Tasks AddTask(Tasks task);
		Tasks UpdateTask(int id, Tasks task);
		void DeleteTask(int id);
	}
}
