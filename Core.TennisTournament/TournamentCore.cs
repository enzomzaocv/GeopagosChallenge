using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisTournament.Model.Dtos;
using TennisTournament.Model.Entities;
using TennisTournament.Repository;

namespace TennisTournament.Core
{
	public class TournamentCore : ITournamentCore
	{
		private readonly ITournamentRepository tennisTournamentRepository;
		private readonly IPlayerRepository playerRepository;

		public TournamentCore(ITournamentRepository tennisTournamentRepository)
		{
			this.tennisTournamentRepository = tennisTournamentRepository;
		}

		public async Task<DtoPlayTournamentResponse> PlayTournamentAsync(DtoPlayTournamentRequest request)
		{
			if (request.Players.Count % 2 != 0) return null;
			if (request.Players.Count < 2) return null;

			var tournament = await GenerateTournamentAsync(request);

			return new DtoPlayTournamentResponse
			{
				Winner =  tournament.Winner.Name
			};
		}

		private async Task<Tournament> GenerateTournamentAsync(DtoPlayTournamentRequest request)
		{
			var tournament = new Tournament();
			var peers = ChunkBy(request.Players, 2);

			foreach (var peer in peers)
			{
				var match = new Match
				{
					IdPlayer1 = peer[0].IdPlayer,
					IdPlayer2 = peer[1].IdPlayer,
					IdWinner = PlayMatchAsync(peer[0], peer[1])
				};

				tournament.Matches.Add(match);
			}

			if (peers.Count > 1) PlayStage(request);

			return tournament;
		}

		private void PlayStage(List<Player> players)
		{
			var peers = ChunkBy(players, 2);

			foreach (var peer in peers)
			{
				var match = new Match
				{
					IdPlayer1 = peer[0].IdPlayer,
					IdPlayer2 = peer[1].IdPlayer,
					IdWinner = PlayMatchAsync(peer[0], peer[1])
				};

				tournament.Matches.Add(match);
			}

			if (peers.Count > 1) PlayStage();

			return PlayStage();
		}

		private async long PlayMatchAsync(Player player1, Player player2, char gender = 'M')
		{
			if (gender == 'M')
			{
				var (luck1, luck2) = GetLuckNumbers();
				var player1TotalPoints = await playerRepository.CalculateTotalPointsAsync(player1.IdPlayer) + luck1;
				var player2TotalPoints = await playerRepository.CalculateTotalPointsAsync(player2.IdPlayer) + luck2;

				if (player1TotalPoints == player2TotalPoints)
				{
					return (luck1 > luck2) ? player1.IdPlayer : player2.IdPlayer;
				}

				return player1TotalPoints > player2TotalPoints 
					? player1.IdPlayer 
					: player2.IdPlayer;
			}
		}

		private (int luck1, int luck2) GetLuckNumbers()
		{
			return (1, 2);
		}

		public static List<List<T>> ChunkBy<T>(this List<T> source, int chunkSize)
		{
			return source
				.Select((x, i) => new { Index = i, Value = x })
				.GroupBy(x => x.Index / chunkSize)
				.Select(x => x.Select(v => v.Value).ToList())
				.ToList();
		}

		public async Task<DtoSearchTournamentResponse> SearchTournamentAsync(DtoSearchTournamentRequest request)
		{

		}
	}
}
