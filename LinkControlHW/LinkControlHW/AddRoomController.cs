using LinkControlHW.Contracts;
using LinkControlHW.Domain;

namespace LinkControlHW
{
    internal class AddRoomController : IController
    {
        const int MaximumRoomLength = 50;

        private IRepository _repository;

        public AddRoomController()
        {
            _repository = Factory.GetRepository();
        }

        public IController ExecuteAction()
        {
            var nextController = new MenuItemController();


            Console.WriteLine("Enter room name:");
            string roomName = Console.ReadLine();
            if (string.IsNullOrEmpty(roomName))
            {
                throw new NotImplementedException("Error! Room value is empty!");
            }
            if (roomName.Length > MaximumRoomLength)
            {
                throw new NotImplementedException($"Error! Room shouldn't be longer than {MaximumRoomLength} symbols!");
            }

            int primaryKey;
            Console.WriteLine("Enter meeting Id:");
            primaryKey = int.Parse(Console.ReadLine());
            if (primaryKey < 0)
            {
                throw new NotImplementedException("PrimaryKey must be >= 0!");
            }

            var room = new Room(roomName, primaryKey);

            _repository.AddRoom(room);
            return nextController;
        }
    }
}