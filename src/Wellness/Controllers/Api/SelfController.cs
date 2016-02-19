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
    [Route("api/self")]
    public class SelfController : Controller
    {
        private IWellnessRepository _repository;
        private ILogger<SelfController> _logger;

        public SelfController(IWellnessRepository repository, ILogger<SelfController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("")]
        public JsonResult Get()
        {
            var user = _repository.GetUser(User.Identity.Name);

            //TODO Need to just return stuff we need
            //var results = Mapper.Map<IEnumerable<SelfViewModel>>(user);

            return Json(user);
        }

        [HttpPost("")]
        public JsonResult Post()
        {
            return Json("TODO create new wellness user or update current wellness user");
        }
    }
}