using Microsoft.AspNetCore.Components;
using IBGE_Blazor.Models;
using IBGE_Blazor.Services.Localidades;
using IBGE_Blazor.Shared.ViewModel;

namespace IBGE_Blazor.Components.Pages.Localidades;

public class LocalidadeIndexCode : ComponentBase
{
    public LocalidadeIndexCode(LocalidadeService localidadeService)
    {
        _service = localidadeService;
    }
    protected ListaPaginada<Localidade> Model = new();
    [Inject]
    private LocalidadeServices _service { get; set; }
    private PaginationModel<EnumLocalidadeOrdenarPor> pagination { get; set; } = new();
    public Localidade Search { get; set; } = new();
    protected List<string> Estados { get; set; } = new List<string>();

    protected override async Task OnInitializedAsync()
    {
        pagination.OrdenarPor = EnumLocalidadeOrdenarPor.Cidade;

        Estados = await _service.ObterEstados();
        Model = await _service.ObterLocalidades(pagination.PaginaAtual, pagination.TamanhoPagina, pagination.OrdenarPor);
        pagination.TotalPaginas = Model.TotalPaginas;
    }
    private async Task TrocarPagina(int novaPagina)
    {
        Model = await _service.ObterLocalidades(
            novaPagina,
            pagination.TamanhoPagina,
            pagination.OrdenarPor,
            Search.Id,
            Search.State,
            Search.City);
    }
    protected async Task Pesquisar()
    {
        pagination.PaginaAtual = 1;
        Model = await _service.ObterLocalidades(
            pagination.PaginaAtual,
            pagination.TamanhoPagina,
            pagination.OrdenarPor,
            Search.Id,
            Search.State,
            Search.City);
    }
}