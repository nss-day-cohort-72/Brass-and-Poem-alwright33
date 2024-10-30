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

bool exit = false;
while (!exit)
{
    Console.WriteLine("\nMenu:");
    Console.WriteLine("a. Display all products");
    Console.WriteLine("b. Add product to inventory");
    Console.WriteLine("c. Remove product from inventory");
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

    void DisplayMenu()
    {
        throw new NotImplementedException();
    }

    void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
    {
        throw new NotImplementedException();
    }

    void DeleteProduct(List<Product> products, List<ProductType> productTypes)
    {
        throw new NotImplementedException();
    }

    void AddProduct(List<Product> products, List<ProductType> productTypes)
    {
        throw new NotImplementedException();
    }

    void UpdateProduct(List<Product> products, List<ProductType> productTypes)
    {
        throw new NotImplementedException();
    }
}
// don't move or change this!
public partial class Program { }