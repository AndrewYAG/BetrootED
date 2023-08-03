using LinkControlHW.Contracts;
using LinkControlHW.Domain;

namespace LinkControlHW
{
    public class ReadOnlyShowRoomsController : IController
    {
        private IRepository _repository;

        public ReadOnlyShowRoomsController()
        {
            _repository = Factory.GetRepository();
        }

        public IController ExecuteAction()
        {
            var rooms = _repository.GetAllRooms();

            ShowAllRooms(rooms);

            return new ReadOnlyMenuItemController();
        }

        private static void ShowAllRooms(Room[] rooms)
        {
            /*if (rooms.Length == 0)
                throw new NotImplementedException("Error! File is empty yet! Firstly add a meeting!");*/

            Console.WriteLine($"\n{"RoomId",20}"
                + $"{"Name",20}");

            foreach (var room in rooms)
            {
                Console.WriteLine($"{room.Id,20}" +
                    $"{room.Name,20}");
            }

            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();
        }
    }
}