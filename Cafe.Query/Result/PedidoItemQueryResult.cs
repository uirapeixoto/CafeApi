﻿using Cafe.Contract;
using System;

namespace Cafe.Query.Result
{
    public sealed class PedidoItemQueryResult : IQueryResult
    {
        public int Id { get; }
        public string Descricao { get; }
        public int Quantidade { get; }
        public decimal AjustePreco { get; }
        public DateTime? AServir { get; }
        public DateTime? EmPreparacao { get; }
        public DateTime? Servido { get; }
        public MenuItemQueryResult MenuItem { get; }

        public PedidoItemQueryResult(int id, MenuItemQueryResult menuItem, int quantidade, DateTime? aServir, DateTime? emPreparacao, DateTime? servido, string descricao = "")
        {
            Id = id;
            MenuItem = menuItem;
            Quantidade = quantidade;
            AServir = aServir;
            EmPreparacao = emPreparacao;
            Servido = servido;
            Descricao = descricao;
        }
    }
}
