namespace IBGE_Blazor.Shared.ViewModels;

public interface IPagination
{
    public int TotalPaginas { get; set; }
    public int PaginaAtual { get; set; }
    public int TamanhoPagina { get; set; }
}
