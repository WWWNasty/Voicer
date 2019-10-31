using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.Abstraction.Services.ListVoting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class VotingController : Controller
    {
        private readonly ILogger<VotingController> _logger;

        private readonly IVotingService _votingService;

        public VotingController(ILogger<VotingController> logger, IVotingService votingService)
        {
            _logger = logger;
            _votingService = votingService;
        }

        public IActionResult Index()
        {
            return View(_votingService.GetVoting());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}