
using IBGE_Blazor.Data;
using IBGE_Blazor.Models;
using IBGE_Blazor.Shared.Extensions;
using IBGE_Blazor.Shared.ViewModels;

namespace IBGE_Blazor.Services.Localidades;

public class LocalidadeServices
{
    private readonly ApplicationDbContext _context;
    public LocalidadeServices(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<IPagedList<Localidade>> ObterLocalidades(int pagina, int tamanhoPagina, EnumLocalidadeOrdenarPor ordenarPor)
    {
        if(pagina > 0) pagina -= 1;
        if (tamanhoPagina == 0) tamanhoPagina = 10;

        var localidades = await _context.Cidades
                .OrderBy(ordenarPor)
                .ToListaPaginada(pagina, tamanhoPagina);
        return localidades;
    }
}
