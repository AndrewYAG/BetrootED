using LinkControlHW.Contracts;
using LinkControlHW.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkControlHW
{
    public class AddMeetingController : IController
    {
        const int MaximumNameLength = 25;

        private IRepository _repository;

        public AddMeetingController(IRepository repository = null)
        {
            if (repository == null)
                _repository = Factory.GetRepository();
            else
                _repository = repository;
        }

        public IController ExecuteAction()
        {
            var nextController = new MenuItemController();

            /*Console.WriteLine("\nEnter Start Date:");
            bool dateParsingResult = DateTime.TryParse(Console.ReadLine(), out var startTime);
            if (!dateParsingResult)
            {
                throw new ArgumentException("Error! Invalid start date!");
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

            Console.WriteLine("Enter existing room id:");
            int idOfMeetingRoom = int.TryParse(Console.ReadLine(), out var roomId) ? roomId :
                throw new NotImplementedException("Incorrect room Id!");

            string meetingName = "";
            int meetingId = 0;

            foreach (var room in _repository.GetAllRooms())
            {
                if (room.Id == idOfMeetingRoom)
                {
                    meetingName = room.Name;
                    meetingId = room.Id;
                }
            }

            if (string.IsNullOrEmpty(meetingName) && meetingId == 0)
                throw new NotImplementedException("You entered unexisting room id!");

            int primaryKey;
            ValidateMeetingTime(startTime, duration, idOfMeetingRoom);

            Console.WriteLine("Enter meeting Id:");
            primaryKey = int.Parse(Console.ReadLine());
            if (primaryKey < 0)
            {
                throw new NotImplementedException("PrimaryKey must be >= 0!");
            }

            Console.WriteLine("Enter Meeting Name:");
            string name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                throw new NotImplementedException("Error! Name value is empty!");
            }
            if (name.Length > MaximumNameLength)
            {
                throw new NotImplementedException($"Error! Name shouldn't be longer than {MaximumNameLength} symbols!");
            }


            var meeting = new Meeting(primaryKey, name, startTime, duration, new Room(meetingName, meetingId));

            _repository.AddMeeting(meeting);*/
            return nextController;
        }

        private void ValidateMeetingTime(DateTime newMeetingStartTime, int duration, int room)
        {
            var meetings = _repository.GetAllMeetings();
            foreach (var meeting in meetings)
            {
                var newMeetingEndTime = newMeetingStartTime.AddMinutes(duration);
                var listedMeetingEndTime = meeting.StartDate.AddMinutes(meeting.Duration);
                if (room == meeting.Room?.Id && newMeetingStartTime < listedMeetingEndTime && newMeetingEndTime > meeting.StartDate)
                {
                    throw new NotImplementedException($"Eror! Another meeting already take place " +
                        $" in the room: {room} in this period of time! Meeting take place at {meeting.StartDate}—{listedMeetingEndTime}.\n" +
                        $"You tried to reserve room: {room} at {newMeetingStartTime}-{newMeetingEndTime}");
                }
            }
        }

    }
}
