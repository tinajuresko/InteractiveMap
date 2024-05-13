using Karta.Model;
using System.Linq.Expressions;

namespace Karta.Extensions.Selectors
{
	public static class DogadajSort
	{
		public static IQueryable<Dogadaj> ApplySort(this IQueryable<Dogadaj> query, int sort, bool ascending)
		{
			Expression<Func<Dogadaj, object>> orderSelector = sort switch
			{
				1 => d => d.IdDogadaj,
				2 => d => d.IdDionica,
				3 => d => d.VrijemeDogadaja,
				4 => d => d.OpisDogadaja,
				5 => d => d.MeteoroloskiUvjeti,
				_ => null
			};

			if (orderSelector != null)
			{
				query = ascending ?
					   query.OrderBy(orderSelector) :
					   query.OrderByDescending(orderSelector);
			}

			return query;
		}
	}
}
