using System.Security.Cryptography;
using TennisTournament.Exceptions;
using TennisTournament.Model.Dtos;
using TennisTournament.Model.Entities;
using TennisTournament.Repository;
using TennisTournament.Utils;

namespace TennisTournament.Core
{
	public class TournamentCore : ITournamentCore
	{
		private readonly ITournamentRepository tennisTournamentRepository;
		private readonly IPlayerRepository playerRepository;

		public TournamentCore(ITournamentRepository tennisTournamentRepository, IPlayerRepository playerRepository)
		{
			this.tennisTournamentRepository = tennisTournamentRepository;
			this.playerRepository = playerRepository;
		}

		/// <summary>
		/// Plays a tournament.
		/// </summary>
		/// <param name="request">
		///		<para>A list of players.</para>
		///	</param>
		/// <returns>A <see cref="DtoPlayTournamentResponse"/> with the winner.</returns>
		public async Task<DtoPlayTournamentResponse> PlayTournamentAsync(DtoPlayTournamentRequest request)
		{
			if (request.Players.Count % 2 != 0) throw new OddPlayersException();
			if (request.Players.Count < 2) throw new NotEnoughPlayersException();

			var tournament = await GenerateTournamentAsync(request);

			await tennisTournamentRepository.CreateAsync(tournament);
			await tennisTournamentRepository.SaveChangesAsync();

			return new DtoPlayTournamentResponse
			{
				Winner = tournament.Winner.Name
			};
		}

		/// <summary>
		/// Search Tournaments.
		/// </summary>
		/// <param name="request">
		///		<para>Parameters to search for.</para>
		///	</param>
		/// <returns>A list of tournaments.</returns>
		public async Task<DtoSearchTournamentResponse> SearchTournamentAsync(DtoSearchTournamentRequest request)
		{
			request ??= new DtoSearchTournamentRequest();

			var (count, tournaments) = await tennisTournamentRepository.SearchTournamentAsync(request);

			return new DtoSearchTournamentResponse
			{
				List = tournaments,
				Count = count
			};
		}

		#region Private Methods

		private async Task<Tournament> GenerateTournamentAsync(DtoPlayTournamentRequest request)
		{
			var tournament = new Tournament
			{
				Gender = request.GenderValue,
				Date = request.DateValue
			};

			var players = await playerRepository.GetByIdentificationNumberAsync(request.Players, request.GenderValue);

			if (players.Count < 2) throw new NotEnoughPlayersException();

			await PlayStage(players, tournament);

			return tournament;
		}

		private static async Task PlayStage(List<Player> players, Tournament tournament, int stage = 1)
		{
			//var peers = ChunkBy(players, 2);
			var peers = ListUtils.ChunkBy(players, 2);

			foreach (var peer in peers)
			{
				var winner = PlayMatchAsync(peer[0], peer[1]);

				var match = new Match
				{
					IdPlayer1 = peer[0].IdPlayer,
					IdPlayer2 = peer[1].IdPlayer,
					IdWinner = winner.IdPlayer
				};

				tournament.Matches.Add(match);

				if (peers.Count == 1)
				{
					tournament.IdWinner = winner.IdPlayer;
					tournament.Winner = winner;
				}
			}

			if (peers.Count > 1) await PlayStage(tournament.Matches.Select(p => p.Winner).ToList(), tournament, stage++);

			return;
		}

		private static Player PlayMatchAsync(Player player1, Player player2)
		{
			var (luck1, luck2) = GetLuckNumbers();
			var player1TotalPoints = player1.CalculateTotalPoints() + luck1;
			var player2TotalPoints = player2.CalculateTotalPoints() + luck2;

			if (player1TotalPoints == player2TotalPoints)
			{
				return (luck1 > luck2) ? player1 : player2;
			}

			return player1TotalPoints > player2TotalPoints
				? player1
				: player2;
		}

		private static (int luck1, int luck2) GetLuckNumbers()
		{
			var luckNumber1 = GenerateRandomNumber(1);
			var luckNumber2 = GenerateRandomNumber(1);

			while (luckNumber1 == luckNumber2)
			{
				luckNumber2 = GenerateRandomNumber(1);
			}

			return (luckNumber1, luckNumber2);
		}

		private static int GenerateRandomNumber(int length)
		{
			var random = RandomNumberGenerator.Create();
			var randomNumber = new byte[length];

			return BitConverter.ToInt32(randomNumber, 0);
		}

		private static List<List<Player>> ChunkBy(List<Player> source, int chunkSize)
		{
			return source
				.Select((x, i) => new { Index = i, Value = x })
				.GroupBy(x => x.Index / chunkSize)
				.Select(x => x.Select(v => v.Value).ToList())
				.ToList();
		}

		#endregion
	}
}