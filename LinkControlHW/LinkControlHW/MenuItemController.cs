using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkControlHW
{
    public class MenuItemController : IController
    {
        public IController ExecuteAction()
        {
            while (true)
            {
                PrintMenu();

                var pressedKey = Console.ReadKey();
                switch (pressedKey.Key)
                {
                    case ConsoleKey.D1:
                        return new ShowMeetingsController();
                    case ConsoleKey.D2:
                        return new AddMeetingController();
                    case ConsoleKey.D3:
                        return null;
                    case ConsoleKey.D4:
                        return new FindMeetingsByRoomController();
                    case ConsoleKey.D5:
                        return new ShowRoomsController();
                    case ConsoleKey.D6:
                        return new AddRoomController();
                    default:
                        return null;
                }
            }
        }
        private static void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to calendar menu, choose an option:");
            Console.WriteLine("1. Show all meetings\n" +
                "2. Add meeting\n" +
                "3. Exit calendar\n" +
                "4. Find meeting by room\n" +
                "5. Show all rooms\n" +
                "6. Add room");
        }
    }
}
