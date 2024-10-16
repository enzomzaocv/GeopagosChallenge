using System.Linq.Expressions;

namespace TennisTournament.Repository
{
	public interface IRepository<T>
	{
		Task CreateAsync(T entity);
		Task SaveChangesAsync();
		Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
	}
}
