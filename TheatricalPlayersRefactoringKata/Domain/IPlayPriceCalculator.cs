namespace TheatricalPlayersRefactoringKata.Domain;

public interface IPlayPriceCalculator
{
    decimal CalculatePrice(int lines, int audience);
    int CalculateCredits(int audience);
}
