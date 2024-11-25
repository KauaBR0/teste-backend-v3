using System;
using TheatricalPlayersRefactoringKata.Domain.Calculators;

namespace TheatricalPlayersRefactoringKata.Domain;

public class PlayPriceCalculatorFactory
{
    public static IPlayPriceCalculator CreateCalculator(PlayType playType)
    {
        return playType switch
        {
            PlayType.Tragedy => new TragedyCalculator(),
            PlayType.Comedy => new ComedyCalculator(),
            PlayType.History => new HistoryCalculator(),
            _ => throw new ArgumentException($"Unknown play type: {playType}")
        };
    }
}
