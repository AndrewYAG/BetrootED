using LinkControlHW.Contracts;
using LinkControlHW.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkControlHW
{
    public class ShowRoomsController : IController
    {
        private IRepository _repository;

        public ShowRoomsController()
        {
            _repository = Factory.GetRepository();
        }

        public IController ExecuteAction()
        {
            var rooms = _repository.GetAllRooms();

            //ShowAllRooms(rooms);

            return new MenuItemController();
        }

        private static void ShowAllRooms(Room[] rooms)
        {
            /*if (rooms.Length == 0)
                throw new NotImplementedException("Error! File is empty yet! Firstly add a room!");*/

            Console.WriteLine($"\n{"RoomId",20}"
                + $"{"Name",20}");

            foreach (var room in rooms)
            {
                Console.WriteLine($"{room.Id, 20}" +
                    $"{room.Name, 20}");
            }

            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();
        }
    }
}
