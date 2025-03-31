

/*

1. Запрограмуйте клас Money (об'єкт класу оперує однією 
валютою) для роботи з грошима. У класі мають бути передбачені: 
поле для зберігання цілої частини грошей (долари, євро, гривні 
тощо) і поле для зберігання копійок (центи, євроценти, копійки 
тощо). Реалізувати методи виведення суми на екран, задання 
значень частин.  

2. Створити клас Product для роботи з продуктом або товаром. 
Реалізувати метод, який дозволяє зменшити ціну на задане число.  

3. Реалізувати клас Warehouse, який описує товари, що 
зберігаються на складі: найменування, одиниця виміру, ціна 
одиниці, кількість, дата останнього завозу, тощо. 

4. Реалізувати клас Reporting для роботи зі звітністю. 
Реєстрація надходження товару (формування прибуткової 
накладної) і відвантаження (видаткова накладна). Звіт по 
інвентаризації (залишки на складі).  

5. Для кожного з класів реалізувати необхідні методи і поля. Для 
класів передбачити реалізацію конструкторів та методів для 
встановлення та читання значень. 

6. Ви також можете додавати власний функціонал для 
унаочнення принципів програмування. Приклади додаткового 
функціоналу:  
    a. категорії для продуктів; 
    b. конкретні дочірні класи валюти 
    c. корзина для замовлень. 

*/


using lab1;

IReporter reporter = new ConsoleReporter();

Product phone = new("Phone", new Money(252, 40), "Just a phone");
Product laptop = new("Laptop", new Money(1250, 0), "Just a regular laptop");
Product water = new("Water", new Money(1, 20), "Just a water");

phone.DecreasePrice(new Money(2, 41));
laptop.DecreasePrice(new Money(50, 1));
water.DecreasePrice(new Money(0, 10));

ProductStock phoneStock = new(120);
ProductStock LaptopStock = new(45);
ProductStock waterStock = new(1.5, "litres");

Storage storage = new(reporter);
storage.AddProduct(phone, phoneStock);
storage.AddProduct(laptop, LaptopStock);
storage.AddProduct(water, waterStock);


//storage.GetProduct("Laptop").Value.Key.DecreasePrice(new Money(0, -1));

phone.Report(reporter);
laptop.Report(reporter);
water.Report(reporter);

storage.Report(reporter);

Console.WriteLine("Taking and Giving reports test\n\n");

storage.AddProductQuantity("Laptop", 20);
storage.RemoveProductQuantity("Phone", 15);
