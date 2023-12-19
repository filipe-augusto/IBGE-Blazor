using System.Collections;

namespace IBGE_Blazor.Shared.ViewModels
{
    public interface IPagedList<T> : IList<T>
    {
        int TotalPaginas { get; }
        int PaginaAtual { get; }

    }
}
