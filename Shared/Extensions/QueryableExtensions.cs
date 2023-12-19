using IBGE_Blazor.Shared.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace IBGE_Blazor.Shared.Extensions;

public static class QueryableExtensions
{
    public static async Task<IPagedList<T>> ToListaPaginada<T>(
        this IQueryable<T> valores,
        int paginaAtual,
        int tamanhoPagina,
        bool isSomenteTotal = false)
    {
        if (valores == null)
            return new ListaPaginada<T>(new List<T>(), paginaAtual, tamanhoPagina);

        //min allowed page size is 1
        tamanhoPagina = Math.Max(tamanhoPagina, 1);

        var count = await valores.CountAsync();

        var data = new List<T>();

        if (!isSomenteTotal)
            data.AddRange(await valores.Skip(paginaAtual * tamanhoPagina).Take(tamanhoPagina).ToListAsync());

        return new ListaPaginada<T>(data, paginaAtual, tamanhoPagina, count);
    }
}
