using InventoryControlTRD.Domain.Core.Interfaces.Repositories;
using InventoryControlTRD.Domain.Models;
using InventoryControlTRD.Infrastructure.Data.Core;
using System;
using System.Collections.Generic;

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
                                    from Request xa 
                                    join RequestProduct xb on xa.Id = xb.Id
                                    join Product xc on xc.Id = xb.ProductId
                                    where xa.Date between @StartDate and @FinalDate
                                    group by Name",
                            new { StartDate = startDate, FinalDate = finalDate });
        }

        public IEnumerable<Report> GetInventoryOutReport(DateTime startDate, DateTime finalDate)
        {
            return _data.Query(@"
             select x.Name, SUM(x.Amount) Amount, SUM(CostTotal) CostTotal , SUM(SaleTotal) SaleTotal from (
                select xd.Name, Sum(xb.amount * xc.Amount) as Amount, Sum((xb.amount * xc.Amount) * xd.CostPrice) CostTotal, 
                  Sum((xb.amount * xc.Amount) * xd.SalePrice) SaleTotal 
                  from Request xa
                  join RequestProduct xb on xa.Id = xb.Id
                  join SubProduct xc on xc.ProductId = xb.ProductId
                  join Product xd on xd.Id = xc.SubProductId
                  where xa.Date between @StartDate and @FinalDate
                  group by xd.Name
                union
                select xc.Name, Sum(xb.Amount) Amount, Sum(xb.SubTotalCostPrice) CostTotal, Sum(xb.SubTotalSalePrice) SaleTotal
                   from Request xa
                   join RequestProduct xb on xa.Id = xb.Id
                   join Product xc on xc.Id = xb.ProductId
                   where xc.Composite = 0 and xa.Date between @StartDate and @FinalDate
                   group by xc.Name
              ) x group by x.Name
        ", new { StartDate = startDate, FinalDate = finalDate });
        }
    }
}
