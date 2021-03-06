﻿using System.Collections.Generic;

namespace Cafe.Api.ViewModel
{
    public class GarcomTarefasViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public IEnumerable<MesaAbertaViewModel> Mesas { get; set; }

        public GarcomTarefasViewModel()
        {
            Mesas = new List<MesaAbertaViewModel>();
        }
    }
}
