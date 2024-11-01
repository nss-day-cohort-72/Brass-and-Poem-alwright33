List<Product> products = new List<Product>
{
    new Product("The Raven", 34.99m, 1),
    new Product("To Kill a Mockingbird", 24.99m, 1),
    new Product("The Odyssey", 29.99m, 1),
    new Product("The Iliad", 32.50m, 1),
    new Product("Trumpet", 299.99m, 2),
    new Product("Saxophone", 449.99m, 2),
    new Product("Tuba", 799.00m, 2),
    new Product("French Horn", 649.99m, 2),
    new Product("Leaves of Grass", 19.95m, 1),
    new Product("Canterbury Tales", 39.99m, 1)
};
List<ProductType> productTypes = new List<ProductType>
{
    new ProductType("Poem", 1),
    new ProductType("Brass", 2)
};

string greeting = @"Welcome to The Brass and Poem";

Console.WriteLine(greeting);
DisplayMenu();



void DisplayMenu()
{
    bool exit = false;
    while (!exit)
    {
        Console.WriteLine("Menu:");
        Console.WriteLine("a. Display all products");
        Console.WriteLine("b. Remove product from inventory");
        Console.WriteLine("c. Add product to inventory");
        Console.WriteLine("d. Update product details");
        Console.WriteLine("e. Exit");

        string choice = Console.ReadLine()?.ToLower();

        switch (choice)
        {
            case "a":
                DisplayAllProducts(products, productTypes);
                break;
            case "b":
                DeleteProduct(products, productTypes);
                break;
            case "c":
                AddProduct(products, productTypes);
                break;
            case "d":
                UpdateProduct(products, productTypes);
                break;
            case "e":
                exit = true;
                Console.WriteLine("Thank you for visiting The Brass and Poem!");
                break;

        }
    }

    void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
    {
        Console.WriteLine("All Products:");

        var productList = from product in products
                          join productType in productTypes on product.ProductTypeId equals productType.Id
                          select new
                          {
                              product.Name,
                              product.Price,
                              ProductType = productType.Title
                          };

        int index = 1;
        foreach (var product in productList)
        {
            Console.WriteLine($"{index}. {product.Name} - {product.Price:C} ({product.ProductType})");
            index++;
        }
    }

    void DeleteProduct(List<Product> products, List<ProductType> productTypes)
    {
        Console.WriteLine("Current Inventory:");
        for (int i = 0; i < products.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {products[i].Name} - {products[i].Price:C}");
        }

        int selectedIndex;
        Console.Write("\nEnter the number of the product you want to remove: ");
        while (!int.TryParse(Console.ReadLine(), out selectedIndex) || selectedIndex < 1 || selectedIndex > products.Count)
        {
            Console.Write("Invalid input. Please enter a valid product number: ");
        }

        Product removedProduct = products[selectedIndex - 1];
        products.RemoveAt(selectedIndex - 1);

        Console.WriteLine($"{removedProduct.Name} has been removed from the inventory.");
    }

    void AddProduct(List<Product> products, List<ProductType> productTypes)
    {
        Console.Write("Enter the product name: ");
        string name = Console.ReadLine();

        Console.Write("Enter the price of the product: ");
        decimal price;
        while (!decimal.TryParse(Console.ReadLine(), out price))
        {
            Console.Write("Invalid input. Please enter a valid price: ");
        }

        Console.WriteLine("Select the product type by entering the corresponding number:");
        foreach (var type in productTypes)
        {
            Console.WriteLine($"{type.Id}. {type.Title}");
        }

        int productTypeId;
        while (true)
        {
            Console.Write("Enter the product type ID: ");
            if (int.TryParse(Console.ReadLine(), out productTypeId) && productTypes.Any(pt => pt.Id == productTypeId))
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Please select a valid product type ID from the list.");
            }
        }
        Product newProduct = new Product(name, price, productTypeId);
        products.Add(newProduct);

        Console.WriteLine($"{name} has been added to the inventory as a {productTypes.First(pt => pt.Id == productTypeId).Title}.");
    }
}

void UpdateProduct(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("\nCurrent Inventory:");
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name} - {products[i].Price:C}");
    }

    int selectedIndex;
    Console.Write("Enter the number of the product you wish to update: ");
    while (!int.TryParse(Console.ReadLine(), out selectedIndex) || selectedIndex < 1 || selectedIndex > products.Count)
    {
        Console.Write("Invalid input. Please enter a valid product number: ");
    }

    Product selectedProduct = products[selectedIndex - 1];

    Console.Write($"Current name: {selectedProduct.Name}. Enter new name or press Enter to keep the current name: ");
    string newName = Console.ReadLine();
    if (!string.IsNullOrEmpty(newName))
    {
        selectedProduct.Name = newName;
    }

    Console.Write($"Current price: {selectedProduct.Price:C}. Enter new price or press Enter to keep the current price: ");
    string priceInput = Console.ReadLine();
    if (!string.IsNullOrEmpty(priceInput))
    {
        if (decimal.TryParse(priceInput, out decimal newPrice))
        {
            selectedProduct.Price = newPrice;
        }
        else
        {
            Console.WriteLine("Invalid input. Price will remain unchanged.");
        }
    }

    Console.WriteLine($"\nUpdated Product: {selectedProduct.Name} - {selectedProduct.Price:C}");
}

// don't move or change this!
public partial class Program { }