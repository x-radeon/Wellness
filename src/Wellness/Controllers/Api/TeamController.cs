using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Server.Kestrel.Http;
using Microsoft.Extensions.Logging;
using Wellness.Models;
using Wellness.ViewModels;

namespace Wellness.Controllers.Api
{
    [Authorize]
    [Route("api/team")]
    public class TeamController : Controller
    {
        private IWellnessRepository _repository;
        private ILogger<TeamController> _logger;

        public TeamController(IWellnessRepository repository, ILogger<TeamController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("")]
        public JsonResult Get()
        {
            //Show team members
            //var Teams = _repository.GetTeamMembers(User.Identity.Name);
            //var results = Mapper.Map<IEnumerable<TeamViewModel>>(Teams);

            return Json("TODO Get team members for current user");
        }

        [HttpPost("")]
        public JsonResult Post([FromBody]TeamViewModel vm)
        {
            //Join a team
            try
            {
                if (ModelState.IsValid)
                {
                    var newTeam = Mapper.Map<Team>(vm);

                    newTeam.Name = vm.Name;

                    //DB insert
                    _logger.LogInformation("Attempting to save a new Team");

                    _repository.CreateTeam(newTeam);

                    if (_repository.SaveAll())
                    {
                        Response.StatusCode = (int)HttpStatusCode.Created;
                        return Json(Mapper.Map<TeamViewModel>(newTeam));
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Falied to save new Team", ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { MessageBody = ex.Message });
            }


            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(new { Message = "Failed", ModelState = ModelState });
        }

        [HttpGet("/api/Teams/{TeamName}")]
        public JsonResult Get(string TeamName)
        {
            //Get metrics for all team members
            return Json("TODO Get Team Members for specified team");

        }
    }
}