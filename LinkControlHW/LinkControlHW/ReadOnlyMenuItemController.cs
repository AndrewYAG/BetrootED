using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkControlHW
{
    public class ReadOnlyMenuItemController : IController
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
                        return new ReadOnlyShowMeetingsController();
                    case ConsoleKey.D3:
                        return null;
                    case ConsoleKey.D2:
                        return new ReadOnlyFindMeetingsByRoomController();
                    case ConsoleKey.D4:
                        return new ReadOnlyShowRoomsController();
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
                "2. Find meeting by room\n" +
                "3. Exit calendar\n" +
                "4. Show all rooms\n");
        }
    }
}
