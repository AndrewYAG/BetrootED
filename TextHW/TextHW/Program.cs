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
                    default:
                        break;
                }
                Console.WriteLine("Press any key to return to menu...");
                Console.ReadKey();
            }
        }

        public static void ShowAllMeetings(string fileLocation)
        {
            if (!File.Exists(fileLocation))
            {
                File.Create(fileLocation);
            }

            Console.WriteLine($"{"\n\tStart time", 20}"
                + $"{"Duration",20}"
                + $"{"Room",20}" +
                 $"{"Name",20}" +
                 $"{"Key", 20}");

            string[] meetingsToShow = File.ReadAllLines(fileLocation);

            foreach (var line in meetingsToShow)
            {
                string[] meeting = line.Split(",");
                Console.WriteLine($"{meeting[0],20}" +
                    $"{meeting[1],20}" +
                    $"{meeting[2],20}" +
                    $"{meeting[3],20}" +
                    $"{meeting[4], 20}");
            }
        }

        public static void AddMeeting(string fileLocation)
        {
            const int MaximumRoomLength = 50;
            const int MaximumNameLength = 25;
            Console.WriteLine("\nEnter Start Date:");
            bool dateParsingResult = DateTime.TryParse(Console.ReadLine(), out var startTime);
            if(!dateParsingResult)
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
            if(string.IsNullOrEmpty(room))
            {
                throw new NotImplementedException("Error! Room value is empty!");
            }
            if(room.Length > MaximumRoomLength) 
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

            int primaryKey = GenerateIdBasedOnFile(fileLocation);
            
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

                if(!dateParsingResult)
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
                if(!idParsingResult)
                    throw new NotImplementedException($"Error! Invalid primary key in the file! The key is {listedKey}");

                if(listedKey > generatedId)
                    generatedId = listedKey;
            }

            return ++generatedId;
        }

        public static void DeleteLineByKey(string fileLocation)
        {
            Console.WriteLine("\nEnter key of the line to delete:");
            bool keyParsingResult = int.TryParse(Console.ReadLine(), out var keyToDelete);
            if(!keyParsingResult)
                throw new NotImplementedException($"Error! Invalid value of key to delete a line! Value is {keyToDelete}");

            string[] meetings = File.ReadAllLines(fileLocation);

            if(meetings.Length == 0)
                throw new NotImplementedException("Error! File is empty yet! Firstly enter a value!");

            string[] newMeetings = new string[meetings.Length - 1];
            int i = 0;
            
            foreach (string line in meetings)
            {
                bool keyParsingResults = int.TryParse(line.Split(",")[4], out var lineKey);
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
            Console.WriteLine("\nEnter key of the line to update:");
            bool keyParsingResult = int.TryParse(Console.ReadLine(), out var keyToUpdate);
            if (!keyParsingResult)
                throw new NotImplementedException($"Error! Invalid value of key to update a line! Value is {keyToUpdate}");

            string[] meetings = File.ReadAllLines(fileLocation);

            if (meetings.Length == 0)
                throw new NotImplementedException("Error! File is empty yet! Firstly enter a value!");

            for (int i = 0; i < meetings.Length; i++)
            {
                bool keyParsingResults = int.TryParse(meetings[i].Split(",")[4], out var lineKey);

                if (keyToUpdate == lineKey)
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

                    bool primaryKeyParsingResult = int.TryParse(meetings[i].Split(",")[4], out var primaryKey);
                    if (!primaryKeyParsingResult)
                        throw new NotImplementedException($"Error! Primary key is invalid in process of updating! Key value is: {primaryKey}");

                    meetings[i] = $"{startTime},{duration},{room},{name},{primaryKey}";
                    break;
                }
            }

            File.WriteAllLines(fileLocation, meetings);
        }
        public static void Exit()
        {
            Environment.Exit(0);
        }

/*        public static void ShowError(string message)
        {
            Console.WriteLine(message);
            Console.ReadKey();
        }*/

        public static void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to calendar menu, choose an option:");
            Console.WriteLine("1. Show all meetings\n" +
                "2. Add meeting\n" +
                "3. Exit calendar\n" +
                "4. Delete line by key\n" +
                "5. Update line by key");
        }
    }
}