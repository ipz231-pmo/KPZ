using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1;

/*

 1. Запрограмуйте клас Money (об'єкт класу оперує однією 
валютою) для роботи з грошима. У класі мають бути передбачені: 
поле для зберігання цілої частини грошей (долари, євро, гривні 
тощо) і поле для зберігання копійок (центи, євроценти, копійки 
тощо). Реалізувати методи виведення суми на екран, задання 
значень частин. 

 */

internal class Money : Reportable
{
    public int BillsCount {  get; set; }
    public int CoinsCount { get; set; }

    public Money(int billsCount = 0, int coinsCount = 0)
    {
        BillsCount = billsCount;
        CoinsCount = coinsCount;
    }
    public override string ToString()
    {
        return $"Money: {BillsCount}.{CoinsCount}";
    }
}
