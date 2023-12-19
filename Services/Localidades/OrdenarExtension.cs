using System.Linq;
using IBGE_Blazor.Models;

namespace IBGE_Blazor.Services.Localidades
{
    public static class OrdenarExtension
    {
        public static IQueryable<Localidade> OrderBy(this IQueryable<Localidade> query, EnumLocalidadeOrdenarPor ordenarPor)
        {
            query = ordenarPor switch
            {
                EnumLocalidadeOrdenarPor.NomeAsc => from l in query
                                                    orderby l.City ascending
                                                    select l,
                EnumLocalidadeOrdenarPor.NomeDesc => from l in query
                                                     orderby l.City descending
                                                     select l,
                EnumLocalidadeOrdenarPor.SiglaAsc => from l in query
                                                     orderby l.State ascending
                                                     select l,
                EnumLocalidadeOrdenarPor.SiglaDesc => from l in query
                                                      orderby l.State descending
                                                      select l,
                _ => from l in query
                     orderby l.Id ascending
                     select l
            };
            return query;
        }
    }
}
