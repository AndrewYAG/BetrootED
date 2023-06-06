namespace AbstractAndInterfacesHW
{
    public class Fridge : Product
    {

        public double HeightInMeters { get; private set; }
        public double Volume { get; private set; }
        public string PowerConsumptionClass { get; private set; }
        public string CompressorType { get; private set; }
        public string NoiseLevel { get; private set; }
        public string Color { get; private set; }

        public Fridge(string title, string producer, int price, string description, string category,
            int quantityInStock, int productID, string model, double heightInMeters, double volume, string powerConsumptionClass,
            string compressorType, string noiseLevel, string color)
            : base(title, producer, price, description, category, quantityInStock, productID, model)
        {
            HeightInMeters = heightInMeters;
            Volume = volume;
            PowerConsumptionClass = powerConsumptionClass;
            CompressorType = compressorType;
            NoiseLevel = noiseLevel;
            Color = color;
        }
    }



}