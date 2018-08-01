using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Wellness.Models;
using Wellness.ViewModels;

namespace Wellness.Controllers.Api
{
    [Authorize]
    [Route("api/self/metric/{MetricId}")]
    public class SelfMetricController : Controller
    {
        private IWellnessRepository _repository;
        private ILogger<SelfMetricController> _logger;

        public SelfMetricController(IWellnessRepository repository, ILogger<SelfMetricController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("")]
        public JsonResult Get(int MetricId)
        {
            return Json(_repository.GetUserMetric(MetricId, User.Identity.Name));
        }

        [HttpPost("")]
        public JsonResult Post([FromBody]WellnessUserMetric vm)
        {
            try
            {
                var metricUpdate = Mapper.Map<WellnessUserMetric>(vm);

                _repository.ModifyUserMetric(metricUpdate);

                if(_repository.SaveAll())
                {
                    Response.StatusCode = (int)HttpStatusCode.OK;
                    return Json(metricUpdate);
                }

                return Json("TODO Update wellness METRICS of Metric ID");
            }
            catch (Exception ex)
            {
                _logger.LogError("Falied to update metric", ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { MessageBody = ex.Message });
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(new { Message = "Failed", ModelState = ModelState });
        }

        [HttpDelete("")]
        public JsonResult Delete(int MetricId)
        {
            try
            {
                var results = _repository.GetUserMetric(MetricId, User.Identity.Name);

                if (results == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return Json("Failed to delete metric");
                }

                _repository.DeleteUserMetric(results);

                if (_repository.SaveAll())
                {
                    Response.StatusCode = (int)HttpStatusCode.OK;
                    return Json("Deleted Metric");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to delete Metric", ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Failed to delete Metric");
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json("Failed to delete Metric");
        }

    }
}