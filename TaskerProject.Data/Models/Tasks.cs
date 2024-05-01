using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskerProject.Data.Models
{
	public class Tasks
	{
		public int Id { get; set; }

		public string TaskName { get; set; } = null!;
		public string TaskDescription { get; set; } = null!;

		public bool IsCompleted { get; set; } = false;
	}
}
