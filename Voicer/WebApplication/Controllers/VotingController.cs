using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.Abstraction.Services.VotingCommands;
using BusinessLogicLayer.Abstraction.Services.VotingCommands.Dtos;
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

        public async Task<IActionResult> Index()
        {
            return View(await _votingService.GetAllVotingAsync());
        }
        
        public async Task<IActionResult> Get([FromRoute]int id)
        {
            return View(await _votingService.GetVotingAsync(id));
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult _VotingStatusActive()
        {
            return View();
        }
        
        public IActionResult _VotingStatusEnded()
        {
            return View();
        }
        
        public IActionResult _VotingStatusUpcoming()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Add([FromForm]CreateVotingDto dto)
        {
            int createdVotingId = await _votingService.AddAsync(dto);

            return RedirectToAction("Get",  new {id = createdVotingId});
        }

        public IActionResult Invite()
        {
            return View();
        }
        
        public IActionResult _Voting()
        {
            return View();
        }
        
        public IActionResult Update()
        {
            return View();
        }
        
       
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}