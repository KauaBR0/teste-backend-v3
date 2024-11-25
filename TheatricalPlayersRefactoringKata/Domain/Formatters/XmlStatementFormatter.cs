using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace TheatricalPlayersRefactoringKata.Domain.Formatters;

public class XmlStatementFormatter : IStatementFormatter
{
    private static readonly XNamespace xsi = "http://www.w3.org/2001/XMLSchema-instance";
    private static readonly XNamespace xsd = "http://www.w3.org/2001/XMLSchema";

    public string GenerateStatement(string customer, IEnumerable<StatementLine> lines, decimal totalAmount, int volumeCredits)
    {
        var settings = new XmlWriterSettings
        {
            Indent = true,
            OmitXmlDeclaration = false,
            Encoding = new UTF8Encoding(false),
            CloseOutput = true
        };

        var ms = new MemoryStream();
        using (var writer = XmlWriter.Create(ms, settings))
        {
            var doc = new XDocument(
                new XElement("Statement",
                    new XAttribute(XNamespace.Xmlns + "xsi", xsi),
                    new XAttribute(XNamespace.Xmlns + "xsd", xsd),
                    new XElement("Customer", customer),
                    new XElement("Items",
                        from line in lines
                        select new XElement("Item",
                            new XElement("AmountOwed", line.Amount.ToString("G29", CultureInfo.InvariantCulture)),
                            new XElement("EarnedCredits", CalculateEarnedCredits(line)),
                            new XElement("Seats", line.Audience)
                        )
                    ),
                    new XElement("AmountOwed", totalAmount.ToString("G29", CultureInfo.InvariantCulture)),
                    new XElement("EarnedCredits", volumeCredits)
                )
            );

            doc.Save(writer);
        }

        var xmlString = Encoding.UTF8.GetString(ms.ToArray());
        return "\uFEFF" + xmlString; // Adiciona o BOM UTF-8
    }

    private int CalculateEarnedCredits(StatementLine line)
    {
        var baseCredits = Math.Max(line.Audience - 30, 0);
        var bonusCredits = line.PlayName == "As You Like It" ? (int)Math.Floor(line.Audience / 5m) : 0;
        return baseCredits + bonusCredits;
    }
}
