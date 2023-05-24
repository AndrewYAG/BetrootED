using Microsoft.VisualBasic;

namespace TextHW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 2. Show all meeting
            // 1. Add meeting - without validation
            // 0. Exit calendar
            const string FileLocation = "meeting.csv";

            try
            {
                while (true)
                {
                    PrintMenu();
                    var pressedKey = Console.ReadKey();
                    switch (pressedKey.Key)
                    {
                        case ConsoleKey.D1:
                            ShowAllMeetings(FileLocation);
                            break;
                        case ConsoleKey.D2:
                            AddMeeting(FileLocation);
                            break;
                        case ConsoleKey.D3:
                            Exit();
                            break;
                        case ConsoleKey.D4:
                            DeleteLineByKey(FileLocation);
                            break;
                        case ConsoleKey.D5:
                            UpdateLineByKey(FileLocation);
                            break;
                        case ConsoleKey.D6:
                            FindMeetingsByRoom(FileLocation);
                            break;
                        case ConsoleKey.D7:
                            PrintMeetingsSortedByDate(FileLocation);
                            break;
                        default:
                            break;
                    }
                    Console.WriteLine("Press any key to return to menu...");
                    Console.ReadKey();
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Something with file went wrong! {ex.Message}\n Stack Trace is:\n{ex.StackTrace}");
            }
            catch (NotImplementedException ex)
            {
                Console.WriteLine($"Something expected went wrong! {ex.Message}\n Stack Trace is:\n{ex.StackTrace}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something unexpected went wrong! {ex.Message}\n Stack Trace is:\n{ex.StackTrace}");
            }
        }

        public static void ShowAllMeetings(string fileLocation)
        {
            if (!File.Exists(fileLocation))
            {
                throw new FileNotFoundException("Error! File not found or it doesn't exist!");
            }

            Console.WriteLine($"{"\n\tStart time",20}"
                + $"{"Duration",20}"
                + $"{"Room",20}" +
                 $"{"Name",20}" +
                 $"{"Key",20}");

            string[] meetingsToShow = File.ReadAllLines(fileLocation);

            foreach (var line in meetingsToShow)
            {
                string[] meeting = line.Split(",");
                Console.WriteLine($"{meeting[0],20}" +
                    $"{meeting[1],20}" +
                    $"{meeting[2],20}" +
                    $"{meeting[3],20}" +
                    $"{meeting[4],20}");
            }
        }

        public static void AddMeeting(string fileLocation)
        {
            const int MaximumRoomLength = 50;
            const int MaximumNameLength = 25;
            Console.WriteLine("\nEnter Start Date:");
            bool dateParsingResult = DateTime.TryParse(Console.ReadLine(), out var startTime);
            if (!dateParsingResult)
            {
                throw new NotImplementedException("Error! Invalid start date!");
            }

            Console.WriteLine("Enter Start Hours:");
            bool hourParsingResult = int.TryParse(Console.ReadLine(), out var hour);
            startTime = startTime.AddHours(hour);
            if (!hourParsingResult)
            {
                throw new NotImplementedException("Error! Invalid hour value!");
            }

            Console.WriteLine("Enter Start Minutes:");
            bool minuteParsingResult = int.TryParse(Console.ReadLine(), out var minute);
            startTime = startTime.AddMinutes(minute);
            if (!minuteParsingResult)
            {
                throw new NotImplementedException("Error! Invalid minute value!");
            }

            Console.WriteLine("Enter Duration In Minutes:");
            bool durationParsingResult = int.TryParse(Console.ReadLine(), out var duration);
            if (!durationParsingResult)
            {
                throw new NotImplementedException("Error! Invalid duration value!");
            }

            Console.WriteLine("Enter Room:");
            string room = Console.ReadLine();
            if (string.IsNullOrEmpty(room))
            {
                throw new NotImplementedException("Error! Room value is empty!");
            }
            if (room.Length > MaximumRoomLength)
            {
                throw new NotImplementedException($"Error! Room shouldn't be longer than {MaximumRoomLength} symbols!");
            }

            int primaryKey;
            if (File.Exists(fileLocation))
            {
                ValidateMeetingTime(startTime, duration, room, fileLocation);
                primaryKey = GenerateIdBasedOnFile(fileLocation);
            }
            else
            {
                primaryKey = 1;
            }

            Console.WriteLine("Enter Meeting Name:");
            string name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                throw new NotImplementedException("Error! Name value is empty!");
            }
            if (name.Length > MaximumRoomLength)
            {
                throw new NotImplementedException($"Error! Name shouldn't be longer than {MaximumNameLength} symbols!");
            }

            File.AppendAllText(fileLocation, $"{startTime},{duration},{room},{name},{primaryKey}\n");
        }
        // duration validation
        public static void ValidateMeetingTime(DateTime newMeetingStartTime, int duration, string room, string fileLocation)
        {
            string[] meetingsToShow = File.ReadAllLines(fileLocation);
            foreach (var line in meetingsToShow)
            {
                string[] meeting = line.Split(",");

                bool dateParsingResult = DateTime.TryParse(meeting[0], out var listedMeetingTime);
                bool durationParsingResult = int.TryParse(meeting[1], out var meetingDuration);

                if (!dateParsingResult)
                {
                    throw new NotImplementedException("Eror! Impossible to convert meetingTime to DateTime!");
                }
                if (!durationParsingResult)
                {
                    throw new NotImplementedException("Eror! Impossible to convert meetingDuration to int!");
                }

                var newMeetingEndTime = newMeetingStartTime.AddMinutes(duration);
                var listedMeetingEndTime = listedMeetingTime.AddMinutes(meetingDuration);

                if (room == meeting[2] && newMeetingStartTime < listedMeetingEndTime && newMeetingEndTime > listedMeetingTime)
                {
                    throw new NotImplementedException($"Eror! Another meeting already take place " +
                        $" in the room: {room} in this period of time! Meeting take place at {listedMeetingTime}—{listedMeetingEndTime}.\n" +
                        $"You tried to reserve room: {room} at {newMeetingStartTime}-{newMeetingEndTime}");
                }
            }
        }

        // id generation for meeting
        public static int GenerateIdBasedOnFile(string fileLocation)
        {
            string[] meetings = File.ReadAllLines(fileLocation);
            int generatedId = 0;

            foreach (var line in meetings)
            {
                var meeting = line.Split(",");

                bool idParsingResult = int.TryParse(meeting[4], out var listedKey);
                if (!idParsingResult)
                    throw new NotImplementedException($"Error! Invalid primary key in the file! The invalid key is {listedKey}");

                if (listedKey > generatedId)
                    generatedId = listedKey;
            }

            return ++generatedId;
        }

        public static void DeleteLineByKey(string fileLocation)
        {
            if (!File.Exists(fileLocation))
            {
                throw new FileNotFoundException("Error! File not found or it doesn't exist!");
            }

            Console.WriteLine("\nEnter key of the line to delete:");
            bool keyParsingResult = int.TryParse(Console.ReadLine(), out var keyToDelete);
            if (!keyParsingResult)
                throw new NotImplementedException($"Error! Invalid value of key to delete a line! Value is {keyToDelete}");

            string[] meetings = File.ReadAllLines(fileLocation);

            if (meetings.Length == 0)
                throw new NotImplementedException("Error! File is empty yet! Firstly enter a value!");

            string[] newMeetings = new string[meetings.Length - 1];
            int i = 0;

            foreach (string line in meetings)
            {
                if (i == meetings.Length - 1)
                    throw new NotImplementedException($"Error! Meeting to delete not found! Meeting key to delete is {keyToDelete}.");

                bool keyParsingResults = int.TryParse(line.Split(",")[4], out var lineKey);

                if(!keyParsingResults)
                    throw new NotImplementedException($"Error! Key value gotten in process of deleting is invalid! Key value is {line.Split(",")[4]}");

                if (keyToDelete == lineKey)
                {
                    continue;
                }
                newMeetings[i++] = line;
            }

            File.WriteAllLines(fileLocation, newMeetings);
        }
        public static void UpdateLineByKey(string fileLocation)
        {
            if (!File.Exists(fileLocation))
            {
                throw new FileNotFoundException("Error! File not found or it doesn't exist!");
            }

            Console.WriteLine("\nEnter key of the line to update:");
            bool keyParsingResult = int.TryParse(Console.ReadLine(), out var keyToUpdate);
            if (!keyParsingResult)
                throw new NotImplementedException($"Error! Invalid value of key to update a line! Value is {keyToUpdate}");

            string[] meetings = File.ReadAllLines(fileLocation);

            if (meetings.Length == 0)
                throw new NotImplementedException("Error! File is empty yet! Firstly enter a value!");

            var meetingWasFound = false;

            for (int i = 0; i < meetings.Length; i++)
            {
                bool keyParsingResults = int.TryParse(meetings[i].Split(",")[4], out var lineKey);

                if (!keyParsingResults)
                    throw new NotImplementedException($"Error! Primary key is invalid in process of updating! Key value is: {lineKey}");

                if (keyToUpdate == lineKey)
                {
                    meetingWasFound = true;

                    const int MaximumRoomLength = 50;
                    const int MaximumNameLength = 25;
                    Console.WriteLine("\nEnter Start Date:");
                    bool dateParsingResult = DateTime.TryParse(Console.ReadLine(), out var startTime);
                    if (!dateParsingResult)
                    {
                        throw new NotImplementedException("Error! Invalid start date!");
                    }

                    Console.WriteLine("Enter Start Hours:");
                    bool hourParsingResult = int.TryParse(Console.ReadLine(), out var hour);
                    startTime = startTime.AddHours(hour);
                    if (!hourParsingResult)
                    {
                        throw new NotImplementedException("Error! Invalid hour value!");
                    }

                    Console.WriteLine("Enter Start Minutes:");
                    bool minuteParsingResult = int.TryParse(Console.ReadLine(), out var minute);
                    startTime = startTime.AddMinutes(minute);
                    if (!minuteParsingResult)
                    {
                        throw new NotImplementedException("Error! Invalid minute value!");
                    }

                    Console.WriteLine("Enter Duration In Minutes:");
                    bool durationParsingResult = int.TryParse(Console.ReadLine(), out var duration);
                    if (!durationParsingResult)
                    {
                        throw new NotImplementedException("Error! Invalid duration value!");
                    }

                    Console.WriteLine("Enter Room:");
                    string room = Console.ReadLine();
                    if (string.IsNullOrEmpty(room))
                    {
                        throw new NotImplementedException("Error! Room value is empty!");
                    }
                    if (room.Length > MaximumRoomLength)
                    {
                        throw new NotImplementedException($"Error! Room shouldn't be longer than {MaximumRoomLength} symbols!");
                    }

                    ValidateMeetingTime(startTime, duration, room, fileLocation);

                    Console.WriteLine("Enter Meeting Name:");
                    string name = Console.ReadLine();
                    if (string.IsNullOrEmpty(name))
                    {
                        throw new NotImplementedException("Error! Name value is empty!");
                    }
                    if (name.Length > MaximumRoomLength)
                    {
                        throw new NotImplementedException($"Error! Name shouldn't be longer than {MaximumNameLength} symbols!");
                    }

                    meetings[i] = $"{startTime},{duration},{room},{name},{lineKey}";
                    break;
                }
                if (!meetingWasFound)
                    throw new NotImplementedException($"Error! Meeting with num: {keyToUpdate} wasn't found in file located in {fileLocation}!");
            }

            File.WriteAllLines(fileLocation, meetings);
        }
        public static void Exit()
        {
            Environment.Exit(0);
        }

        public static void FindMeetingsByRoom(string fileLocation)
        {
            if (!File.Exists(fileLocation))
            {
                throw new FileNotFoundException("Error! File not found or it doesn't exist!");
            }

            Console.WriteLine("\nEnter room to find corresponding meetings:");
            var room = Console.ReadLine();

            string[] meetings = File.ReadAllLines(fileLocation);

            if (meetings.Length == 0)
                throw new NotImplementedException("Error! File is empty yet! Firstly enter a value!");

            Console.WriteLine($"{"\n\tStart time",20}"
                + $"{"Duration",20}"
                + $"{"Room",20}" +
                 $"{"Name",20}" +
                 $"{"Key",20}");

            foreach (var line in meetings)
            {
                string[] meeting = line.Split(",");

                if (room == meeting[2])
                {
                    Console.WriteLine($"{meeting[0],20}" +
                    $"{meeting[1],20}" +
                    $"{meeting[2],20}" +
                    $"{meeting[3],20}" +
                    $"{meeting[4],20}");
                }

            }
        }

        public static void PrintMeetingsSortedByDate(string fileLocation)
        {
            if (!File.Exists(fileLocation))
            {
                throw new FileNotFoundException("Error! File not found or it doesn't exist!");
            }

            string[] meetings = File.ReadAllLines(fileLocation);

            if (meetings.Length == 0)
                throw new NotImplementedException("Error! File is empty yet! Firstly enter a value!");

            Console.WriteLine("Enter sort type {1 - Ascending / 2 - Descending}: ");
            SortType sortingType = (SortType)Enum.Parse(typeof(SortType), Console.ReadLine());

            if (sortingType == SortType.Ascending)
            {
                for (int i = 0; i < meetings.Length - 1; i++)
                {
                    // Find the minimum element in unsorted array
                    int min_idx = i;
                    for (int j = i + 1; j < meetings.Length; j++)
                    {
                        if (DateTime.Parse(meetings[j].Split(",")[0]) < DateTime.Parse(meetings[min_idx].Split(",")[0]))
                            min_idx = j;
                    }
                    // Swap the found minimum element with the first
                    // element
                    string temp = meetings[min_idx];
                    meetings[min_idx] = meetings[i];
                    meetings[i] = temp;
                }
            }
            else if (sortingType == SortType.Descending)
            {
                for (int i = 0; i < meetings.Length - 1; i++)
                {
                    // Find the minimum element in unsorted array
                    int max_idx = i;
                    for (int j = i + 1; j < meetings.Length; j++)
                    {
                        if (DateTime.Parse(meetings[j].Split(",")[0]) > DateTime.Parse(meetings[max_idx].Split(",")[0]))
                            max_idx = j;
                    }
                    // Swap the found minimum element with the first
                    // element
                    string temp = meetings[max_idx];
                    meetings[max_idx] = meetings[i];
                    meetings[i] = temp;
                }
            }
            else
                throw new NotImplementedException("Error! Entered wrong SorType of date sorting! It must be in range 1-2!" +
                    $" You entered: {sortingType}");

            Console.WriteLine($"\nMeetings sorted by date in {sortingType} order:");
            Console.WriteLine($"{"\n\tStart time",20}"
                + $"{"Duration",20}"
                + $"{"Room",20}" +
                 $"{"Name",20}" +
                 $"{"Key",20}");

            foreach (var line in meetings)
            {
                string[] meeting = line.Split(",");

                Console.WriteLine($"{meeting[0],20}" +
                $"{meeting[1],20}" +
                $"{meeting[2],20}" +
                $"{meeting[3],20}" +
                $"{meeting[4],20}");
            }
        }

        public static void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to calendar menu, choose an option:");
            Console.WriteLine("1. Show all meetings\n" +
                "2. Add meeting\n" +
                "3. Exit calendar\n" +
                "4. Delete line by key\n" +
                "5. Update line by key\n" +
                "6. Find meeting by room\n" +
                "7. Print meetings sorted by date");
        }
    }
    enum SortType
    {
        Ascending = 1,
        Descending
    }
}