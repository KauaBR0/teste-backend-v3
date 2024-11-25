using System;
using TheatricalPlayersRefactoringKata.Domain;

namespace TheatricalPlayersRefactoringKata;

public class Play
{
    private string _name;
    private int _lines;
    private PlayType _type;

    public string Name { get => _name; set => _name = value; }
    public int Lines { get => _lines; set => _lines = value; }
    public PlayType Type { get => _type; set => _type = value; }

    public Play(string name, int lines, string type)
    {
        this._name = name;
        this._lines = lines;
        this._type = type.ToLower() switch
        {
            "tragedy" => PlayType.Tragedy,
            "comedy" => PlayType.Comedy,
            "history" => PlayType.History,
            _ => throw new ArgumentException($"Unknown play type: {type}")
        };
    }
}
