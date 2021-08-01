using InventoryControlTRDWeb.Application.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryControlTRDWeb.Areas.Manager.Models
{
    public class RequestReportViewModel
    {
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        public DateTime FinalDate { get; set; }

        public IEnumerable<RequestReportDto> RequestReportList { get; set; }

        public RequestReportViewModel(IEnumerable<RequestReportDto> requestReportList)
        {
            RequestReportList = requestReportList;
        }

        public RequestReportViewModel()
        {

        }

    }
}
