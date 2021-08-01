﻿using InventoryControlTRDWeb.Application.Interface;
using InventoryControlTRDWeb.Areas.Manager.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryControlTRDWeb.Areas.Manager.Controllers
{
    [Area("Manager")]
    public class ReportController : Controller
    {
        private readonly IAppReportService _reportService;

        public ReportController(IAppReportService reportService)
        {
            _reportService = reportService;
        }
        public IActionResult RequestReport() => View();
        
        [HttpPost]
        public IActionResult RequestReport(RequestReportViewModel model)
        {
            try
            {
                return View(new RequestReportViewModel(_reportService.GetRequestReport(model.StartDate,model.FinalDate)));
            }
            catch (Exception)
            {

                throw;
            }
        }
      

        public IActionResult InventoryOutReport()
        {
            return View();
        }
    }
}