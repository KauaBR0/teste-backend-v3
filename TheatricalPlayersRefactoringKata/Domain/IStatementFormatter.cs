using System.Collections.Generic;

namespace TheatricalPlayersRefactoringKata.Domain;

public interface IStatementFormatter
{
    string GenerateStatement(string customer, IEnumerable<StatementLine> lines, decimal totalAmount, int volumeCredits);
}

public record StatementLine(string PlayName, decimal Amount, int Audience);
