while (true)
{
    try
    {
        Console.Clear();
        Stock.ViewAllProducts();

        Console.WriteLine("-=-=-=- Меню -=-=-=-");
        Console.WriteLine("[1] Добавить");
        Console.WriteLine("[2] Удалить");
        Console.WriteLine("[3] Изменить");
        Console.WriteLine("[0] Выход");

        Console.Write("Ваш выбор: ");
        uint Input = Convert.ToUInt32(Console.ReadLine());

        switch (Input)
        {
            case 1:
                {
                    string? ProductName;
                    double ProductPrice;
                    uint ProductQuantity;

                    Console.Write("\nНазвание: ");
                    ProductName = Console.ReadLine();
                    if (ProductName is null || ProductName.Trim().Length == 0) ProductName = "Неизвестно";

                    Console.Write("Цена за шт: ");
                    ProductPrice = Convert.ToDouble(Console.ReadLine());

                    Console.Write("В наличии: ");
                    ProductQuantity = Convert.ToUInt32(Console.ReadLine());

                    Stock.AddProduct(new Product(ProductName, ProductPrice, ProductQuantity));
                    break;
                }
            case 2:
                {
                    Console.Write("\nИндекс продукта: ");
                    Input = Convert.ToUInt32(Console.ReadLine());
                    Stock.DeleteProductById(Input);
                    break;
                }
            case 3:
                {
                    Console.Write("\nИндекс продукта: ");
                    Input = Convert.ToUInt32(Console.ReadLine());

                    Console.Write("\nКакое значение менять?\n[1] Название\n[2] Цена\n[3] Количество\nВаш выбор: ");
                    uint InputMode = Convert.ToUInt32(Console.ReadLine());

                    Stock.EditProductById(Input, InputMode);
                    break;
                }
            case 0: return;
            default: throw new Exception();
        }
    }
    catch { continue; }
}

class Product(string? ProductName, double ProductPrice, uint ProductQuantity)
{
    internal string? ProductName { get; set; } = ProductName;
    internal double ProductPrice { get; set; } = ProductPrice;
    internal uint ProductQuantity { get; set; } = ProductQuantity;
};

static class Stock
{
    static private readonly List<Product>? Products;
    static Stock() { Products = []; Products.Capacity = 0; }

    static public void ViewAllProducts()
    {
        if (Products is null || Products.Count == 0) 
        { Console.WriteLine("Список пуст!"); return; };

        for (int CurrentIndex = 0; CurrentIndex < Products.Count; ++CurrentIndex)
        {
            Console.WriteLine($"[{CurrentIndex + 1}]\tНазвание: {Products[CurrentIndex].ProductName}");
            Console.WriteLine($"\tЦена: ${Products[CurrentIndex].ProductPrice}"); 
            Console.WriteLine($"\tВ наличии: {Products[CurrentIndex].ProductQuantity} шт.\n");
        }
    }

    static public void DeleteProductById(uint Index)
    {
        if (Index <= Products?.Count && Index >= 0)
        { Products?.RemoveAt((int)Index - 1); }
    }

    static public void EditProductById(uint Index, uint Mode)
    {
        if (Products is null || Index > Products?.Count || Index < 0) return;

        switch (Mode)
        {
            case 1:
                {
                    Console.Write("\nНазвание: ");
                    string? newProductName = Console.ReadLine();
                    if (newProductName is null || newProductName.Trim().Length == 0) newProductName = "Неизвестно";

                    Products![(int)Index - 1].ProductName = newProductName;
                    break;
                }
            case 2:
                {
                    Console.Write("Цена за шт: ");
                    double newProductPrice = Convert.ToDouble(Console.ReadLine());

                    Products![(int)Index - 1].ProductPrice = newProductPrice;
                    break;
                }
            case 3:
                {
                    Console.Write("В наличии: ");
                    uint newProductQuantity = Convert.ToUInt32(Console.ReadLine());

                    Products![(int)Index - 1].ProductQuantity = newProductQuantity;
                    break;
                }
        }

    }

    static public void AddProduct(Product SampleObject) => Products?.Add(SampleObject);
};