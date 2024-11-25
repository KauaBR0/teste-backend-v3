using System;

namespace TheatricalPlayersRefactoringKata.Domain.Calculators;

public class HistoryCalculator : IPlayPriceCalculator
{
    private readonly TragedyCalculator _tragedyCalculator;
    private readonly ComedyCalculator _comedyCalculator;

    public HistoryCalculator()
    {
        _tragedyCalculator = new TragedyCalculator();
        _comedyCalculator = new ComedyCalculator();
    }

    public decimal CalculatePrice(int lines, int audience)
    {
        return _tragedyCalculator.CalculatePrice(lines, audience) + 
               _comedyCalculator.CalculatePrice(lines, audience);
    }

    public int CalculateCredits(int audience)
    {
        return Math.Max(audience - 30, 0);
    }
}
