using System;

namespace TheatricalPlayersRefactoringKata.Domain.Calculators;

public class TragedyCalculator : IPlayPriceCalculator
{
    public decimal CalculatePrice(int lines, int audience)
    {
        var baseAmount = NormalizeLines(lines) * 0.1m;
        if (audience > 30)
        {
            baseAmount += 10m * (audience - 30);
        }
        return baseAmount;
    }

    public int CalculateCredits(int audience)
    {
        return Math.Max(audience - 30, 0);
    }

    private int NormalizeLines(int lines)
    {
        return Math.Max(1000, Math.Min(4000, lines));
    }
}
