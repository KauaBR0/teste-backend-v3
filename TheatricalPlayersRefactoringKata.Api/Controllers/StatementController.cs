using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TheatricalPlayersRefactoringKata;
using TheatricalPlayersRefactoringKata.Api.Models;
using TheatricalPlayersRefactoringKata.Domain.Formatters;

namespace TheatricalPlayersRefactoringKata.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StatementController : ControllerBase
{
    [HttpPost("text")]
    public ActionResult<string> GenerateTextStatement([FromBody] GenerateStatementRequest request)
    {
        var plays = ConvertPlays(request.Plays);
        var invoice = ConvertInvoice(request.Customer, request.Performances);

        var printer = new StatementPrinter();
        var result = printer.Print(invoice, plays);

        return Ok(result);
    }

    [HttpPost("xml")]
    public ActionResult<string> GenerateXmlStatement([FromBody] GenerateStatementRequest request)
    {
        var plays = ConvertPlays(request.Plays);
        var invoice = ConvertInvoice(request.Customer, request.Performances);

        var printer = new StatementPrinter(new XmlStatementFormatter());
        var result = printer.Print(invoice, plays);

        return Ok(result);
    }

    private Dictionary<string, Play> ConvertPlays(Dictionary<string, PlayRequest> plays)
    {
        return plays.ToDictionary(
            kvp => kvp.Key,
            kvp => new Play(kvp.Value.Name, kvp.Value.Lines, kvp.Value.Type)
        );
    }

    private Invoice ConvertInvoice(string customer, List<PerformanceRequest> performances)
    {
        var convertedPerformances = performances.Select(p => 
            new Performance(p.PlayId, p.Audience)
        ).ToList();

        return new Invoice(customer, convertedPerformances);
    }
}
