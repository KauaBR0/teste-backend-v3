using System.Collections.Generic;
using System.Linq;
using TheatricalPlayersRefactoringKata.Domain;
using TheatricalPlayersRefactoringKata.Domain.Formatters;

namespace TheatricalPlayersRefactoringKata;

public class StatementPrinter
{
    private readonly IStatementFormatter _formatter;

    public StatementPrinter(IStatementFormatter formatter = null)
    {
        _formatter = formatter ?? new TextStatementFormatter();
    }

    public string Print(Invoice invoice, Dictionary<string, Play> plays)
    {
        var statementLines = new List<StatementLine>();
        var totalAmount = 0m;
        var volumeCredits = 0;

        foreach (var perf in invoice.Performances)
        {
            var play = plays[perf.PlayId];
            var calculator = PlayPriceCalculatorFactory.CreateCalculator(play.Type);

            var amount = calculator.CalculatePrice(play.Lines, perf.Audience);
            volumeCredits += calculator.CalculateCredits(perf.Audience);

            statementLines.Add(new StatementLine(play.Name, amount, perf.Audience));
            totalAmount += amount;
        }

        return _formatter.GenerateStatement(invoice.Customer, statementLines, totalAmount, volumeCredits);
    }
}
