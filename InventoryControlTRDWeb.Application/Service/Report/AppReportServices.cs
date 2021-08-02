using InventoryControlTRD.Domain.Core.Interfaces.Services;
using InventoryControlTRDWeb.Application.Dto;
using InventoryControlTRDWeb.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControlTRDWeb.Application.Service
{
    public class AppReportServices : IAppReportService
    {
        private readonly IReportService _reportService;

        public AppReportServices(IReportService reportService)
        {
            _reportService = reportService;
        }
        public IEnumerable<RequestReportDto> GetRequestReport(DateTime startDate, DateTime finalDate)
        {
            var listMoviments = _reportService.GetRequestReport(startDate, finalDate);
            foreach (var report in listMoviments) yield return new RequestReportDto(report.Date,report.Name,report.Amount,report.CostTotal,report.SaleTotal);
        }

        public IEnumerable<InventoryOutReportDto> GetInventoryOutReport(DateTime startDate, DateTime finalDate)
        {
            var listMoviments = _reportService.GetInventoryOutReport(startDate, finalDate);
            foreach (var report in listMoviments) yield return new InventoryOutReportDto(report.Date, report.Name, report.Amount, report.CostTotal);
        }

        

    }
}
