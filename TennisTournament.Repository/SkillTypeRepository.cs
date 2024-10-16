using Microsoft.EntityFrameworkCore;
using TennisTournament.DataBaseContext;
using TennisTournament.Model.Dtos;
using TennisTournament.Model.Entities;

namespace TennisTournament.Repository
{
	public class SkillTypeRepository : BaseRepository<SkillType>, ISkillTypeRepository
	{
		private readonly TennisTournamentDbContext _context;

		public SkillTypeRepository(TennisTournamentDbContext context) : base(context)
		{
			_context = context;
		}

		public async Task<List<DtoSkillInfo>> GetAllAsync()
		{
			try
			{
				return await _context.SkillType.Select(p => new DtoSkillInfo
				{
					Denomination = p.Description,
					Id = p.IdSkillType
				})
					.AsNoTracking()
					.ToListAsync();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}

			return null;
		}

		public async Task<bool> CheckIdsAsync(List<long> list)
		{
			var ids = await _context.SkillType.Select(p => p.IdSkillType).ToListAsync();

			return list.Except(ids).Any();
		}
	}
}
