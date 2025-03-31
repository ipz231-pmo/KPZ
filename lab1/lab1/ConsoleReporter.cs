using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lab1;

/*

 4. Реалізувати клас Reporting для роботи зі звітністю. 
Реєстрація надходження товару (формування прибуткової 
накладної) і відвантаження (видаткова накладна). Звіт по 
інвентаризації (залишки на складі). 

 */

internal class ConsoleReporter : IReporter
{
    public ConsoleReporter() { }

    public void Print(object? reportee)
    {
        Console.WriteLine($"{reportee}");
    }
}
