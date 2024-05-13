using Karta.Model;
using System.Linq.Expressions;

namespace Karta.Extensions.Selectors
{
    public static class AutocestaSort
    {
        public static IQueryable<Autocesta> ApplySort(this IQueryable<Autocesta> query, int sort, bool ascending)
        {
            Expression<Func<Autocesta, object>> orderSelector = sort switch
            {
                1 => a => a.IdKoncesionarNavigation.NazivKoncesionar,
                2 => a => a.NazivAutocesta,
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
