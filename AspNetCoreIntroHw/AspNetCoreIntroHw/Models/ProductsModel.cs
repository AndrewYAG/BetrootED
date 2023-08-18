namespace AspNetCoreIntroHw.Models
{
    public class ProductsModel
    {
        public string Name { get; set; } = "Products list";
        public List<Product> Products { get; set;} = new List<Product>();
    }
}
