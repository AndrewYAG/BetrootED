using LinkControlHW.Contracts;
using LinkControlHW.Domain;

namespace LinkControlHW
{
    public class FindMeetingsByRoomController : IController
    {
        private IRepository _repository;

        public FindMeetingsByRoomController()
        {
            _repository = Factory.GetRepository();
        }

        public IController ExecuteAction()
        {
            var meetings = _repository.GetAllMeetings();
            //FindMeetingsByRoom(meetings);

            return new MenuItemController();
        }

        private void FindMeetingsByRoom(Meeting[] meetings)
        {
            Console.WriteLine("\nEnter room name to find corresponding meetings:");
            var room = Console.ReadLine();

            if (meetings.Length == 0)
                throw new NotImplementedException("Error! File is empty yet! Firstly add a meeting!");

            Console.WriteLine($"{"\n\tStart time",20}"
                + $"{"Duration",20}"
                + $"{"Room",20}" +
                 $"{"Name",20}" +
                 $"{"Key",20}");

            foreach (var meeting in meetings)
            {
                if (room == meeting.Room?.Name)
                {
                    Console.WriteLine($"{meeting.StartDate,20}" +
                    $"{meeting.Duration,20}" +
                    $"{meeting.Room.Name,20}" +
                    $"{meeting.Name,20}" +
                    $"{meeting.Id,20}");
                }
            }

            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();
        }
    }
}