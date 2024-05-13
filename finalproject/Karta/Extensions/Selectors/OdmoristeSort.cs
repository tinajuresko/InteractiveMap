using Karta.Model;
using System.Linq.Expressions;

namespace Karta.Extensions.Selectors
{
    public static class OdmoristeSort
    {
        public static IQueryable<Odmoriste> ApplySort(this IQueryable<Odmoriste> query, int sort, bool ascending)
        {
            Expression<Func<Odmoriste, object>> orderSelector = sort switch
            {
                1 => o => o.NazivOdmoriste,
                2 => o => o.IdAutocestaNavigation.NazivAutocesta,
                3 => o => o.Smjer,
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
