namespace AbstractAndInterfacesHW
{
    internal interface IPurchasable
    {
        void AddProductToPurchased(params Product[] newPurchasedProducts);

        void AddNewReceipt(Receipt newReceipt);
    }
}