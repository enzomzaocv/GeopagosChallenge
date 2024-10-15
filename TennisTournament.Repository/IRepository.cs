namespace TennisTournament.Repository
{
	public interface IRepository<T>
	{
		Task CreateAsync(T entity);
		Task SaveChangesAsync();
	}
}
