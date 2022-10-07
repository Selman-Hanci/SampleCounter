using Microsoft.AspNetCore.Mvc;
using SampleAPI.Validators;
using SampleBusiness.Services.Interfaces;
using SampleDomain.Models;

namespace SampleAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculatorController : ControllerBase
{
    private readonly ICalculatorService _calculatorService;
    private readonly ClientValidator _clientValidator = new ClientValidator();

    public CalculatorController(ICalculatorService calculatorService)
    {
        _calculatorService = calculatorService;
    }

    [HttpPut("~/Increase")]
    [ProducesResponseType(typeof(NumberDTO), StatusCodes.Status200OK)]
    public async Task<IActionResult> Increaser(Client client,
        CancellationToken cancellationToken = default)
    {
        _clientValidator.ValidateModel(client);

        var result = await _calculatorService.Increase(cancellationToken);

        return Ok(result);

        // TODO:
        // user enters param
        // logger middleware
        // error handling middleware
        // ci cd with jenkins
    }

    [HttpGet("~/Decrease")]
    [ProducesResponseType(typeof(NumberDTO), StatusCodes.Status200OK)]
    public IActionResult Decreaser(CancellationToken cancellationToken = default)
    {
        var result = int.MinValue;
        return Ok(result);
    }

    [HttpGet("~/HealthCheck")]
    [ProducesResponseType(typeof(HealthCheckDTO), StatusCodes.Status200OK)]
    public IActionResult FactCheck(CancellationToken cancellationToken = default)
    {
        return Ok("Noice");
    }
}

