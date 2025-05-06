using ChainOfResponsibilityTask;


Console.OutputEncoding = System.Text.Encoding.Unicode;
Console.InputEncoding = System.Text.Encoding.Unicode;

IHandler def = new RedirectHandler();
IHandler billing = new BillingHandler();
IHandler technical = new TechnicalHandler();
IHandler account = new AccountHandler();
IHandler general = new GeneralHandler();

def.SetNext(billing);
billing.SetNext(technical);
technical.SetNext(account);
account.SetNext(general);

def.Handle();
