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
    [Route("api/self/metrics")]
    public class SelfMetricsController : Controller
    {
        private IWellnessRepository _repository;
        private ILogger<SelfMetricsController> _logger;

        public SelfMetricsController(IWellnessRepository repository, ILogger<SelfMetricsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("")]
        public JsonResult Get()
        {
            var metrics = _repository.GetUserMetrics(User.Identity.Name);

            return Json(metrics);
        }

        [HttpPost("")]
        public JsonResult Post([FromBody]WellnessUserMetric vm)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var newMetric = Mapper.Map<WellnessUserMetric>(vm);
                    newMetric.UserName = User.Identity.Name;

                    _repository.AddUserMetric(newMetric);

                    if(_repository.SaveAll())
                    {
                        Response.StatusCode = (int)HttpStatusCode.Created;
                        return Json(Mapper.Map<MetricViewModel>(newMetric));
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Falied to save new metric", ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { MessageBody = ex.Message });
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(new { Message = "Failed", ModelState = ModelState });
        }
    }
}