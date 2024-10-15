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
	}
}
