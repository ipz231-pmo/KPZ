using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1;

/*
 
2. Створити клас Product для роботи з продуктом або товаром. 
Реалізувати метод, який дозволяє зменшити ціну на задане число.  

 */

internal class Product : Reportable
{
    public Money Price {  get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    
    public Product(string name, Money price, string? description)
    {
        Name = name;
        Price = price;
        Description = description;
    }
    public void DecreasePrice(Money offset) 
    {
        int coins_total = Price.BillsCount * 100 + Price.CoinsCount;
        int coins_offset = offset.BillsCount * 100 + offset.CoinsCount;

        int coins_diff = coins_total - coins_offset;
        if (coins_diff < 0)
            throw new Exception("Under zero value");


        Price.BillsCount = coins_diff / 100;
        Price.CoinsCount = coins_diff % 100;
    }
    public override string ToString()
    {
        return 
            $"Product {Name}\n" +
            $"{Price}\n" +
            $"Description: {Description}\n";
    }

}
