
using IBGE_Blazor.Data;
using IBGE_Blazor.Models;
using IBGE_Blazor.Shared.Extensions;
using IBGE_Blazor.Shared.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace IBGE_Blazor.Services.Localidades;

public class LocalidadeServices
{
    private readonly ApplicationDbContext _context;
    public LocalidadeServices(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<IPagedList<Localidade>> ObterLocalidades(int pagina, int tamanhoPagina,
        EnumLocalidadeOrdenarPor ordenarPor, string codigo = null, string estado = null, string cidade = null)
    {
        if (pagina > 0) pagina -= 1;
        if (tamanhoPagina == 0) tamanhoPagina = 10;

        if (codigo != null)
        {
            var localidade = await _context.Cidades.Where(c => c.Id == codigo)
                .ToListaPaginada(pagina, tamanhoPagina);
            return localidade;
        }
        var query = _context.Cidades.AsQueryable();

        if (estado != null)
        {
            query = query.Where(c => c.State == estado);
        }

        if (cidade != null)
        {
            query = query.Where(c => c.City.Contains(cidade));
        }

        var localidades = await query
            .OrderBy(ordenarPor)
            .ToListaPaginada(pagina, tamanhoPagina);

        return localidades;
    }
    public async Task<List<string>> ObterEstados()
    {
        return await _context.Cidades.Select(c => c.State).Distinct().ToListAsync();
    }
}
