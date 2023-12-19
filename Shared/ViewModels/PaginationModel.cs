namespace IBGE_Blazor.Shared.ViewModels;
public class PaginationModel<TEnum> : IPagination where TEnum : Enum
{
    public PaginationModel()
    {
        TamanhoPagina = 10;
        PaginaAtual = 1;
    }
    public int TotalPaginas { get; set; }
    public int PaginaAtual { get; set; }
    public int TamanhoPagina { get; set; }
    public TEnum OrdenarPor { get; set; }
}
