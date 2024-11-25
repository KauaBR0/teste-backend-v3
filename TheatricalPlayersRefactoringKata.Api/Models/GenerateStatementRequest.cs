using System.Collections.Generic;
using TheatricalPlayersRefactoringKata;

namespace TheatricalPlayersRefactoringKata.Api.Models;

public class GenerateStatementRequest
{
    public required string Customer { get; set; }
    public required List<PerformanceRequest> Performances { get; set; }
    public required Dictionary<string, PlayRequest> Plays { get; set; }
}

public class PerformanceRequest
{
    public required string PlayId { get; set; }
    public int Audience { get; set; }
}

public class PlayRequest
{
    public required string Name { get; set; }
    public int Lines { get; set; }
    public required string Type { get; set; }
}
