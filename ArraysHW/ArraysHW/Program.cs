namespace ArraysHW
{
    public enum SortAlgorithmType
    {
        Selection = 1,
        Bubble,
        Insertion
    }
    public enum OrderBy
    {
        Asc = 1,
        Desc
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // Implement 3 sort algorithms:
            int[] array = new int[6] { 3, 21, 4, 1, 6, 14 };

            Console.Write("Enter sort algorithm type {1:3}:\n1.Selection\n2.Bubble\n3.Insertion\n>:");
            int type = int.Parse(Console.ReadLine());

            Console.Write("\nEnter sort order {1:2}:\n1.Ascending\n2.Descending\n>:");
            int order = int.Parse(Console.ReadLine());

            Sort(array, (SortAlgorithmType)type, (OrderBy)order);

            Console.WriteLine("\nYour array:");
            PrintArray(array);
        }
        public static void Sort(int[] array, SortAlgorithmType sortType, OrderBy sortOrder)
        {
            if(sortOrder == OrderBy.Asc)
            switch (sortType)
            {
                case SortAlgorithmType.Selection:
                    for (int i = 0; i < array.Length - 1; i++)
                    {
                        int minElementIndex = i;
                        for (int j = i + 1; j < array.Length; j++)
                        {
                            if (array[j] < array[minElementIndex])
                            {
                                minElementIndex = j;
                            }
                        }
                        if (i != minElementIndex)
                        {
                            var temp = array[i];
                            array[i] = array[minElementIndex];
                            array[minElementIndex] = temp;
                        }
                    }
                    break;

                case SortAlgorithmType.Bubble:
                    bool needSorting;

                    for (int i = 0; i < array.Length - 1; i++)
                    {
                        needSorting = false;
                        for (int j = 0; j < array.Length - 1 - i; j++)
                        {
                            if (array[j] > array[j + 1])
                            {
                                needSorting = true;
                                var temp = array[j];
                                array[j] = array[j + 1];
                                array[j + 1] = temp;
                            }
                        }
                        if (needSorting == false)
                            break;
                    }
                    break;

                case SortAlgorithmType.Insertion:
                    for (int i = 1; i < array.Length; i++)
                    {
                        var key = array[i];
                        int j = i - 1;

                        while (j >= 0 && array[j] > key)
                        {
                            array[j + 1] = array[j];
                            j--;
                        }
                        array[j + 1] = key;
                    }
                    break;

                default:
                    Console.WriteLine("ERROR! DEFINE CORRECT ALGORITHM TYPE!!!");
                    break;
            }
            else if(sortOrder == OrderBy.Desc)
            {
                switch (sortType)
                {
                    case SortAlgorithmType.Selection:
                        for (int i = 0; i < array.Length - 1; i++)
                        {
                            int maxElementIndex = i;
                            for (int j = i + 1; j < array.Length; j++)
                            {
                                if (array[j] > array[maxElementIndex])
                                {
                                    maxElementIndex = j;
                                }
                            }
                            if (i != maxElementIndex)
                            {
                                var temp = array[i];
                                array[i] = array[maxElementIndex];
                                array[maxElementIndex] = temp;
                            }
                        }
                        break;

                    case SortAlgorithmType.Bubble:
                        bool needSorting;

                        for (int i = 0; i < array.Length - 1; i++)
                        {
                            needSorting = false;
                            for (int j = 0; j < array.Length - 1 - i; j++)
                            {
                                if (array[j] < array[j + 1])
                                {
                                    needSorting = true;
                                    var temp = array[j];
                                    array[j] = array[j + 1];
                                    array[j + 1] = temp;
                                }
                            }
                            if (needSorting == false)
                                break;
                        }
                        break;

                    case SortAlgorithmType.Insertion:
                        for (int i = 1; i < array.Length; i++)
                        {
                            var key = array[i];
                            int j = i - 1;

                            while (j >= 0 && array[j] < key)
                            {
                                array[j + 1] = array[j];
                                j--;
                            }
                            array[j + 1] = key;
                        }
                        break;

                    default:
                        Console.WriteLine("ERROR! DEFINE CORRECT ALGORITHM TYPE!!!");
                        break;
                }
            }
            else
            {
                Console.WriteLine("ERROR! DEFINE CORRECT ORDERBY TYPE!!!");
            }
        }
        public static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
    }
}