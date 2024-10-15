using System.Globalization;
using TennisTournament.Resources;

namespace TennisTournament.Utils
{
	public static class DateUtils
	{
		public static DateTime ParseDateDdMmYyyy(string date)
		{
			if (string.IsNullOrWhiteSpace(date)) new Exception(Messages.InvalidDate);

			return ParseDate(date);
		}

		public static DateTime? ParseDateDdMmYyyyNullable(string date)
		{
			if (string.IsNullOrWhiteSpace(date)) return null;

			return ParseDate(date);
		}

		private static DateTime ParseDate(string date)
		{
			if (DateTime.TryParseExact(date, Formats.DateFormatDdMmYyyy, CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedDate))
			{
				return parsedDate;
			}

			throw new Exception(Messages.InvalidDate);
		}
	}
}
