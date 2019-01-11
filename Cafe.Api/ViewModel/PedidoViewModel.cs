using Cafe.Api.Helper;
using System.Collections.Generic;

namespace Cafe.Api.ViewModel
{
    public class PedidoViewModel : EnumerableHelper
    {
        public int Id { get; set; }
        public int MesaId { get; set; }
        public int NumMesa { get; set; }
        public PedidoItemViewModel PedidoItem { get; set; }
        public IList<PedidoItemViewModel> PedidoBebidaItens { get; set; }
        public IList<PedidoItemViewModel> PedidoComidaItens { get; set; }
        public IList<PedidoItemViewModel> Fatura { get; set; }

        public PedidoViewModel()
        {
            PedidoBebidaItens = new List<PedidoItemViewModel>();
            PedidoComidaItens = new List<PedidoItemViewModel>();
            Fatura = new List<PedidoItemViewModel>();
        }
    }
}
