namespace AbstractAndInterfacesHW
{
    public class BankCard
    {
        public string CardNumber { get; private set; }
        public string ExpirationDate { get; private set; }
        public int CVV { get; private set; }

        public BankCard(string cardNumber, string expirationDate, int cVV)
        {
            CardNumber = cardNumber;
            ExpirationDate = expirationDate;
            CVV = cVV;
        }

        public override string ToString()
        {
            return $"CardNum:{CardNumber}";
        }
    }



}