using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TennisTournament.DataBaseContext;

namespace TennisTournament.Repository
{
	public abstract class BaseRepository<T> : IRepository<T> where T : class
	{
		private readonly TennisTournamentDbContext _context;

		protected BaseRepository(TennisTournamentDbContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Adds the received entity to the DB context.
		/// </summary>
		/// <param name="entity">
		///		<para>The entity.</para>
		/// </param>
		/// <returns>The <see cref="Task"/> that represents the asynchronous operation.</returns>
		public virtual async Task CreateAsync(T entity)
		{
			await _context.Set<T>().AddAsync(entity);
		}

		/// <summary>
		/// Commits the changes in the DB.
		/// </summary>
		/// <returns>The <see cref="Task"/> that represents the asynchronous operation.</returns>
		public async Task SaveChangesAsync()
		{
			await _context.SaveChangesAsync();
		}

		/// <summary>
		/// Gets all record from the database.
		/// </summary>
		/// <returns>An entity list.</returns>
		public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
		{
			return await _context.Set<T>()
				.Where(predicate)
				.AsNoTracking()
				.ToListAsync();
		}
	}
}
