using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Animals
{
    private string _description = "Unknown";

    public string Description
    {
        get => _description;
        init
        {
            var valueTrimmed = value.Trim();

            if (valueTrimmed.Length < 3)
            {
                valueTrimmed = valueTrimmed.PadRight(3, '#');
            }

            if (valueTrimmed.Length > 15)
            {
                valueTrimmed = valueTrimmed.Substring(0, 15).TrimEnd();
                if (valueTrimmed.Length < 3)
                {
                    valueTrimmed = valueTrimmed.PadRight(3, '#');
                }
            }

            if (char.IsLower(valueTrimmed[0]))
            {
                valueTrimmed = char.ToUpper(valueTrimmed[0]) + valueTrimmed.Substring(1);
            }

            _description = valueTrimmed;
        }
    }

    public uint Size { get; set; } = 3;

    public string Info => $"{Description} <{Size}>";
}
