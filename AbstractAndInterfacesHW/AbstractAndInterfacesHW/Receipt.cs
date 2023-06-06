namespace AbstractAndInterfacesHW
{
    public class Receipt
    {
        public string PaymentID { get; init; }
        public Client Buyer { get; init; }
        public double PaymentAmount { get; init; }
        public DateTime TimeOfPayment { get; init; }
        public Product[] PurchasingdProducts { get; init; }
        public string DeliveryAddress { get; init; }
        public int DeliveryPrice { get; init; }
        public BankCard PaymentCard { get; init; }

        public Receipt(string paymentID, Client buyer, DateTime timeOfPayment, Product[] purchasingdProducts,
            string deliveryAddress, int deliveryPrice, BankCard paymentCard)
        {
            PaymentID = paymentID;
            Buyer = buyer;
            TimeOfPayment = timeOfPayment;
            PurchasingdProducts = purchasingdProducts;
            DeliveryAddress = deliveryAddress;
            DeliveryPrice = deliveryPrice;
            PaymentCard = paymentCard;
            PaymentAmount = CalculateProductsPriceInReceipt();
        }

        public double CalculateProductsPriceInReceipt()
        {
            double finalPrice = 0;
            for (int i = 0; i < PurchasingdProducts.Length; i++)
            {
                finalPrice += PurchasingdProducts[i].Price;
            }
            return finalPrice;
        }

        public override string ToString()
        {
            return $"Payment ID: {PaymentID}, Payment Amount:{PaymentAmount}, From Card with {PaymentCard}.";
        }
    }
}