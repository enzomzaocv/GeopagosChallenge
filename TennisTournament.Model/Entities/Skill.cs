using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisTournament.Model.Entities
{
	public class Skill
	{
		[Key]
		public long IdSkill { get; set; }

		public string Description { get; set; }
		public double Value { get; set; }
	}
}
