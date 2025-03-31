using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1;

internal class ProductStock
{
    public string QuantityUnit { get; set; }
    public double Quantity { get; set; }

    public ProductStock(double quantity = 0, string unit = "pcs")
    {
        QuantityUnit = unit;
        Quantity = quantity;
    }

    public override string ToString()
    {
        return $"Product Stock: {Quantity} {QuantityUnit}\n";
    }
}
