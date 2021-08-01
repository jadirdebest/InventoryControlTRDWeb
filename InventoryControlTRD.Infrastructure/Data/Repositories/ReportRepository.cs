using InventoryControlTRD.Domain.Core.Interfaces.Repositories;
using InventoryControlTRD.Domain.Models;
using InventoryControlTRD.Infrastructure.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControlTRD.Infrastructure.Data.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private IDataCore<Report> _data;
        public ReportRepository(IDataCore<Report> data)
        {
            _data = data;
        }

        public IEnumerable<Report> GetRequestReport(DateTime startDate, DateTime finalDate)
        {
            return _data.Query(@"select xc.Name, SUM(xb.Amount) as Amount, SUM(xb.SubTotalCostPrice) CostTotal, SUM(xb.SubTotalSalePrice) SaleTotal  
                                    from Moviment xa 
                                    join MovimentProduct xb on xa.Id = xb.Id
                                    join Product xc on xc.Id = xb.ProductId
                                    group by Name", 
                            new { StartDate = startDate, FinalDate = finalDate });
        }

        public IEnumerable<Report> InventoryOutReport(DateTime startDate, DateTime finalDate)
        {
            return _data.Query(@"
             select x.Name, SUM(x.Amount) Amount, SUM(CostTotal) CostTotal , SUM(SaleTotal) SaleTotal from (
                select xd.Name, xb.amount * xc.Amount as Amount, (xb.amount * xc.Amount) * xd.CostPrice CostTotal, 
                  (xb.amount * xc.Amount) * xd.SalePrice SaleTotal 
                  from Moviment xa
                  join MovimentProduct xb on xa.Id = xb.Id
                  join SubProduct xc on xc.ProductId = xb.ProductId
                  join Product xd on xd.Id = xc.SubProductId
                union
                select xc.Name, xb.Amount, xb.SubTotalCostPrice CostTotal, xb.SubTotalSalePrice SaleTotal
                   from Moviment xa
                   join MovimentProduct xb on xa.Id = xb.Id
                   join Product xc on xc.Id = xb.ProductId
                   where xc.Composite = 0
              ) x group by x.Name
        ", new { StartDate = startDate, FinalDate = finalDate });
        }
    }
}
