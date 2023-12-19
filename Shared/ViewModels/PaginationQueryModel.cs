namespace IBGE_Blazor.Shared.ViewModels;
public class PaginationQueryModel
{

    /// <summary>
    /// Total de registros
    /// </summary>
    public int t { get; set; }
    /// <summary>
    /// Pagina Atual
    /// </summary>
    public int c { get; set; }
    /// <summary>
    /// Tamanho da Pagina
    /// </summary>
    public int s { get; set; }
    /// <summary>
    /// OrdenarPor
    /// </summary>
    public int ob { get; set; }
}
