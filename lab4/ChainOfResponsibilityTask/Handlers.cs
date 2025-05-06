using System;

namespace ChainOfResponsibilityTask;

interface IHandler
{
    void SetNext(IHandler handler);
    bool Handle();
}

abstract class Handler : IHandler
{
    protected IHandler? nextHandler;

    public void SetNext(IHandler handler)
    {
        nextHandler = handler;
    }

    public abstract bool Handle();
}

class RedirectHandler : Handler
{
    public override bool Handle()
    {
        if (nextHandler == null)
            return false;

        bool result = nextHandler.Handle();

        if(result)
        {
            Console.WriteLine("Дякуємо за звернення");
            return true;
        } 
        else
        {
            Console.WriteLine("Не вдалось опрацювати ваш запит. Спробуємо ще раз!");
            return Handle();
        }
    }
}

class BillingHandler : Handler
{
    public override bool Handle()
    {
        Console.WriteLine("1. Це питання стосується оплати? (так/ні)");
        var input = Console.ReadLine()?.ToLower();
        if (input == "так")
        {
            Console.WriteLine("Переадресовано до служби підтримки по оплаті.");
            return true;
        }
        return nextHandler?.Handle() ?? false;
    }
}

class TechnicalHandler : Handler
{
    public override bool Handle()
    {
        Console.WriteLine("2. Це технічна проблема? (так/ні)");
        var input = Console.ReadLine()?.ToLower();
        if (input == "так")
        {
            Console.WriteLine("Переадресовано до технічної підтримки.");
            return true;
        }
        return nextHandler?.Handle() ?? false;
    }
}

class AccountHandler : Handler
{
    public override bool Handle()
    {
        Console.WriteLine("3. Проблема з акаунтом? (так/ні)");
        var input = Console.ReadLine()?.ToLower();
        if (input == "так")
        {
            Console.WriteLine("Переадресовано до підтримки акаунтів.");
            return true;
        }
        return nextHandler?.Handle() ?? false;
    }
}

class GeneralHandler : Handler
{
    public override bool Handle()
    {
        Console.WriteLine("4. Загальне питання? (так/ні)");
        var input = Console.ReadLine()?.ToLower();
        if (input == "так")
        {
            Console.WriteLine("Переадресовано до загальної підтримки.");
            return true;
        }
        return false;
    }
}