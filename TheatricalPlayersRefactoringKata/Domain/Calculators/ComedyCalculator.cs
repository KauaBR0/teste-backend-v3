using System;

namespace TheatricalPlayersRefactoringKata.Domain.Calculators;

public class ComedyCalculator : IPlayPriceCalculator
{
    public decimal CalculatePrice(int lines, int audience)
    {
        var baseAmount = NormalizeLines(lines) * 0.1m;
        baseAmount += 3m * audience;
        
        if (audience > 20)
        {
            baseAmount += 100m + (5m * (audience - 20));
        }
        
        return baseAmount;
    }

    public int CalculateCredits(int audience)
    {
        var baseCredits = Math.Max(audience - 30, 0);
        var bonusCredits = (int)Math.Floor(audience / 5m);
        return baseCredits + bonusCredits;
    }

    private int NormalizeLines(int lines)
    {
        return Math.Max(1000, Math.Min(4000, lines));
    }
}
