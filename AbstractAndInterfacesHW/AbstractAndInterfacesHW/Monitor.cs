namespace AbstractAndInterfacesHW
{
    public class Monitor : Product
    {
        public double ScreenSize { get; private set; }
        public string MatrixType { get; private set; }
        public double UpdateFrequencyInGz { get; private set; }
        public double DisplayBrightness { get; private set; }
        public string PortType { get; private set; }

        public Monitor(string title, string producer, int price, string description, string category, int quantityInStock,
            int productID, string model, double screenSize, string matrixType, double updateFrequencyInGz,
            double displayBrightness, string portType)
             : base(title, producer, price, description, category, quantityInStock, productID, model)
        {
            ScreenSize = screenSize;
            MatrixType = matrixType;
            UpdateFrequencyInGz = updateFrequencyInGz;
            DisplayBrightness = displayBrightness;
            PortType = portType;
        }
    }



}