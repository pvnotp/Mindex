using CodeChallenge.Models;
using CodeChallenge.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace CodeChallenge.Controllers
{
    [ApiController]
    [Route("api/compensations")]
    public class CompensationController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly ICompensationService _compensationService;

        public CompensationController(ILogger<CompensationController> logger, ICompensationService compensationService)
        {
            _logger = logger;
            _compensationService = compensationService;
        }

        [HttpPost]
        public IActionResult CreateCompensation([FromBody] CompensationDto compensationDto)
        {
            _logger.LogDebug($"Received compensation create request");

            var compensation = new Compensation();
            if (compensationDto != null)
            {
                compensation.Employee = new Guid(compensationDto.EmployeeId);
                compensation.Salary = int.Parse(compensationDto.Salary);
                compensation.EffectiveDate = DateTime.Parse(compensationDto.EffectiveDate);
            }

            _compensationService.Create(compensation);

            return CreatedAtRoute("getCompensationById", new { id = compensation.Employee }, compensation);
        }

        [HttpGet("{id}", Name = "getCompensationById")]
        public IActionResult GetCompensationById(String id)
        {
            _logger.LogDebug($"Received compensation get request for '{id}'");

            var compensation = _compensationService.GetById(id);

            if (compensation == null)
            {
                return NotFound();
            }

            return Ok(compensation);
        }
    }
}
