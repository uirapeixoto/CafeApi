﻿using Cafe.Contract;
using Cafe.Infra.Data;
using Cafe.Query.Query;
using Cafe.Query.Result;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cafe.Query.Handler
{
    public class CozinhaTarefasQueryHandler : IDisposable
    {
        public void Dispose()
        {
        }

        public IEnumerable<CozinhaTarefasQueryResult> Handle(CozinhaTarefasQuery query)
        {
            try
            {
                using (var _context = new CafeDbContext())
                {
                    var result = _context.TbOrderedItem
                        .AsNoTracking()
                        .Include(i => i.IdMenuItemNavigation)
                        .Include(i => i.IdOrderedNavigation)
                        .Include(i => i.IdOrderedNavigation.IdTabOpenedNavigation)
                        .Where(x => !x.IdMenuItemNavigation.StIsDrink)
                        .Where(x => x.DtInPreparation.HasValue)
                        .AsParallel()
                        .Select(o => new CozinhaTarefasQueryResult(
                               o.IdOrderedNavigation.IdTabOpenedNavigation.Id,
                               o.IdOrderedNavigation.Id,
                               o.Id,
                               new MenuItemQueryResult(
                                   o.IdMenuItemNavigation.Id,
                                   o.IdMenuItemNavigation.NuMenuItem,
                                   o.IdMenuItemNavigation.DsDescription,
                                   o.IdMenuItemNavigation.NuPrice,
                                   o.IdMenuItemNavigation.StIsDrink,
                                   o.IdMenuItemNavigation.StActive
                                ),
                               o.NuAmount,
                               o.DtToServe,
                               o.DtInPreparation,
                               o.DtServed,
                               o.DsDescription
                        )).ToList();

                    return result.OrderBy(x => x.PedidoId);
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
