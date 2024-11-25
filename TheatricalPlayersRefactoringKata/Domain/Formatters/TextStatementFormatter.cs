using System.Collections.Generic;
using System.Globalization;

namespace TheatricalPlayersRefactoringKata.Domain.Formatters;

public class TextStatementFormatter : IStatementFormatter
{
    private readonly CultureInfo _cultureInfo = new("en-US");

    public string GenerateStatement(string customer, IEnumerable<StatementLine> lines, decimal totalAmount, int volumeCredits)
    {
        var result = $"Statement for {customer}\n";

        foreach (var line in lines)
        {
            result += $"  {line.PlayName}: {line.Amount.ToString("C", _cultureInfo)} ({line.Audience} seats)\n";
        }

        result += $"Amount owed is {totalAmount.ToString("C", _cultureInfo)}\n";
        result += $"You earned {volumeCredits} credits\n";

        return result;
    }
}
