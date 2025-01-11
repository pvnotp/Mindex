using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CodeChallenge.Services;
using CodeChallenge.Models;

namespace CodeChallenge.Controllers
{
    [ApiController]
    [Route("api/reportingStructures")]
    public class ReportingStructureController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IEmployeeService _employeeService;

        public ReportingStructureController(ILogger<ReportingStructureController> logger, IEmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
        }

        [HttpGet("{id}", Name = "getReportStructureById")]
        public IActionResult GetReportingStructureById(String id)
        {
            _logger.LogDebug($"Received reporting structure get request for employee id '{id}'.");

            var employee = _employeeService.GetById(id);

            if (employee == null)
                return NotFound();

            try
            {
                var reportingStructure = new ReportingStructure(employee);
                return Ok(reportingStructure);
            }
            catch
            {
                _logger.LogDebug($"Could not get reporting structure for employee id '{id}'.");
                return BadRequest();
            }

        }

    }
}
