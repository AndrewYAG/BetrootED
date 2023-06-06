namespace AbstractAndInterfacesHW
{
    public interface IProductable
    {
        void RegisterNewProduct(Product newProductToRegister);
        void SellProductByID(int productIDToSell, int clientIDToSellTo, int amountToSell);
    }
}