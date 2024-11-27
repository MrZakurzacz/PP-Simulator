using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Animals
{
    private string _description = "Unknown";

    public required string Description
    {
        get => _description;
        init => _description = Validator.Shortener(value, 3, 15, '#');
    }

    public uint Size { get; set; } = 3;

    // Wirtualna metoda Info
    public virtual string Info => $"{Description} <{Size}>";

    // Nadpisanie ToString() dla wyświetlania nazwy typu i właściwości Info
    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }
}
