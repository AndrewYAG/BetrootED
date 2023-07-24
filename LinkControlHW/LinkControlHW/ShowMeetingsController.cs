using LinkControlHW.Contracts;
using LinkControlHW.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkControlHW
{
    public class ShowMeetingsController : IController
    {
        private IRepository _repository;

        public ShowMeetingsController()
        {
            _repository = Factory.GetRepository();
        }

        public IController ExecuteAction()
        {
            var meetings = _repository.GetAllMeetings();

            ShowAllMeetings(meetings);

            return new MenuItemController();
        }

        private static void ShowAllMeetings(Meeting[] meetings)
        {
            if (meetings.Length == 0)
                throw new NotImplementedException("Error! File is empty yet! Firstly add a meeting!");

            Console.WriteLine($"\n{"Start time",20}"
                + $"{"Duration",20}"
                + $"{"Room",20}" +
                $"{"Name",20}" +
                $"{"Id",20}");

            foreach (var meeting in meetings)
            {
                Console.WriteLine($"{meeting.StartDate, 20}" +
                    $"{meeting.Duration, 20}" +
                    $"{meeting.Room.Name, 20}" +
                    $"{meeting.Name, 20}" +
                    $"{meeting.Id, 20}");
            }

            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();
        }
    }
}
