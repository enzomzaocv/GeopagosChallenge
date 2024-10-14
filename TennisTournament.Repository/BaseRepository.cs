using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisTournament.Repository
{
	public abstract class BaseRepository<T> : IRepository<T> where T : class
	{
	}
}
