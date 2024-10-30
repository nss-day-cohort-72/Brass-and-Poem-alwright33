public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int ProductTypeId { get; set; }

    public Product(string name, decimal price, int productTypeId)
    {
        Name = name;
        Price = price;
        ProductTypeId = productTypeId;
    }

}