namespace AbstractAndInterfacesHW
{
    public class Phone : Product
    {
        public double ScreenSize { get; private set; }
        public int RAM { get; private set; }
        public int Memory { get; private set; }
        public string OS { get; private set; }
        public int BatterySize { get; private set; }
        public string MatrixType { get; private set; }
        public string BackColor { get; private set; }

        public Phone(string title, string producer, int price, string description, string category, int quantityInStock,
            int productID, string model, double screenSize, int ram, int memory, string oS, int batterySize,
            string matrixType, string backColor) : base(title, producer, price, description, category, quantityInStock, productID, model)
        {
            ScreenSize = screenSize;
            RAM = ram;
            Memory = memory;
            OS = oS;
            BatterySize = batterySize;
            MatrixType = matrixType;
            BackColor = backColor;
        }
    }



}