using System.Collections;

namespace IBGE_Blazor.Shared.ViewModels
{
    public class ListaPaginada<T> : List<T>, IPagedList<T>
    {
        public int TotalPaginas { get; }

        public int PaginaAtual { get; }

        public int QuantidadeTotal { get; }

        public ListaPaginada(IList<T> valores, int paginaAtual, int tamanhoPagina, int? quantidadeTotal = null)
        {
            tamanhoPagina = Math.Max(tamanhoPagina, 1);

            QuantidadeTotal = quantidadeTotal ?? valores.Count;
            TotalPaginas = (int)Math.Ceiling(QuantidadeTotal / (double)tamanhoPagina);
            PaginaAtual = paginaAtual;

            AddRange(quantidadeTotal != null ? valores : valores.Skip((paginaAtual - 1) * tamanhoPagina).Take(tamanhoPagina));
        }


    }
}
