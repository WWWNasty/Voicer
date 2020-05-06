using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BusinessLogicLayer.Abstraction.Extensions;
using BusinessLogicLayer.Abstraction.Services.VotingCommands;
using BusinessLogicLayer.Abstraction.Services.VotingCommands.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
            GetVotingDto getVotingDto = await _votingService.GetVotingAsync(id);


            getVotingDto.UserVoted = await _votingService.HasUserVotedAsync(id, User.GetUserId());
            
            return View(getVotingDto);
        }

        [Authorize]
        public IActionResult Delete([FromRoute]int id)
        {
            _votingService.DeleteAsync(new DeleteVotingDto
            {
                Id = id,
                User = User
            });
            
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Add()
        {
            return View();
        }
        
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add([FromForm]CreateVotingDto dto)
        {
            if (ModelState.IsValid)
            {
                int createdVotingId = await _votingService.AddAsync(dto, User);

                return RedirectToAction("Get", new {id = createdVotingId});
            }

            return View(dto);
        }

        [Authorize]
        public IActionResult Invite(int id)
        {
            return View(new InviteUserDto
            {
                VotingId = id
            });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Invite([FromForm] InviteUserDto dto)
        {
            await _votingService.InviteAsync(dto);
            return RedirectToAction("Get",  new {id = dto.VotingId});
        }
        public async Task<IActionResult> Update([FromRoute]int id)
        {
            return View( await _votingService.GetVotingForUpdateAsync(id));
        }

        [Authorize]
        public async Task<IActionResult> MakeVote([FromQuery] int votingOptionId)
        {
            var makeVoteDto = new MakeVoteDto
            {
                VotingOptionId = votingOptionId,
                User = User
            };
            await _votingService.MakeVoteAsync(makeVoteDto);
            
            return Redirect(Request.Headers["Referer"].ToString()); 
        }
        
        [HttpPost]
        public async Task<IActionResult> Update([FromForm] UpdateVotingDto dto)
        {
            await _votingService.UpdateAsync(dto);

            return RedirectToAction("Get",  new {id = dto.Id}); 
        }
       
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}