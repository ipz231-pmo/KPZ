using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1;
/*

3. Реалізувати клас Warehouse, який описує товари, що 
зберігаються на складі: найменування, одиниця виміру, ціна 
одиниці, кількість, дата останнього завозу, тощо.  

 */
internal class Storage : Reportable
{
    private Dictionary<Product, ProductStock> items;
    public IReporter? Reporter { get; set; }
    public Storage(IReporter? reporter = null)
    {
        items = [];
        Reporter = reporter;
    }

    public Product? GetProduct(string name)
    {
        return items.FirstOrDefault(kv => kv.Key.Name == name).Key;
    }
    public ProductStock? GetProductStock(string name)
    {
        return items.FirstOrDefault(kv => kv.Key.Name == name).Value;
    }
    public ProductStock? GetProductStock(Product product)
    {
        return items.FirstOrDefault(kv => kv.Key == product).Value;
    }

    public void AddProductQuantity(string name, double quantity)
    {
        KeyValuePair<Product, ProductStock>? kv = items.FirstOrDefault(pair => pair.Key.Name == name);
        if (kv == null)
            throw new Exception("Error, Storage dont have given Product");
        kv.Value.Value.Quantity += quantity;

        if (Reporter == null) return;
        Reporter.Print(
            $"Giving action\n" +
            $"Product: {kv.Value.Key.Name}\n" +
            $"Product gived: {quantity} {kv.Value.Value.QuantityUnit}\n" +
            $"Product new quantity: {kv.Value.Value.Quantity} {kv.Value.Value.QuantityUnit}\n"
            );
    }

    public void RemoveProductQuantity(string name, double quantity)
    {
        KeyValuePair<Product, ProductStock>? kv = items.FirstOrDefault(pair => pair.Key.Name == name);
        if (kv == null)
            throw new Exception("Error, Storage dont have given Product");
        kv.Value.Value.Quantity -= quantity;
        if (kv.Value.Value.Quantity < 0)
            throw new Exception("Error, You are trying to take more quantity than storage has");

        if (Reporter == null) return;
        Reporter.Print(
            $"Taking action\n" +
            $"Product: {kv.Value.Key.Name}\n" +
            $"Product taked: {quantity} {kv.Value.Value.QuantityUnit}\n" +
            $"Product new quantity: {kv.Value.Value.Quantity} {kv.Value.Value.QuantityUnit}\n"
            );

    }

    public void AddProduct(Product product, ProductStock stock)
    {
        if (items.ContainsKey(product))
            throw new Exception("Item are already in WareHouse");

        items.Add(product, stock);
    }
    public void RemoveProduct(Product product)
    {
        items.Remove(product);
    }




    public override string ToString()
    {
        string result = "Storage\n\n";

        foreach (var kv in items)
        {
            result += kv.Key;
            result += kv.Value;
            result += '\n';
        }
        result += "End of Storage\n";
        return result;
    }
}
