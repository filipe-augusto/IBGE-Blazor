using Microsoft.AspNetCore.Components;
using IBGE_Blazor.Models;
using IBGE_Blazor.Services.Localidades;
using IBGE_Blazor.Shared.ViewModel;

namespace IBGE_Blazor.Components.Pages.Localidades;

public class LocalidadeIndexCode : ComponentBase

    private ListaPaginada<Localidade> Model = new();
    [Inject]
    private LocalidadeServices _service { get; set; }
    private PaginationModel<EnumLocalidadeOrdenarPor> pagination { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {

        //PAGINAÇÃO ...

        //COMPONENTES
        Model = await _service.ObterLocalidades(pagination.c,pagination.t,pagination.ob);
    }
    private async Task TrocarPagina(int novaPagina)
    {
        
    }

}
