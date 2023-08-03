using LinkControlHW.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkControlHW.Domain
{
    internal class Repository : IRepository
    {
        const string MeetingsFileLocation = "meeting.csv";
        const string RoomsFileLocation = "room.csv";
        public Repository()
        {
            if (!File.Exists(MeetingsFileLocation))
            {
                File.Create(MeetingsFileLocation);
            }
            if (!File.Exists(RoomsFileLocation))
            {
                File.Create(RoomsFileLocation);
            }
        }
        public Meeting[] GetAllMeetings()
        {
            string[] fileContent = File.ReadAllLines(MeetingsFileLocation);

            List<Meeting> meetings = new List<Meeting>();

            foreach (var line in fileContent)
            {
                string[] meeting = line.Split(",");
                meetings.Add(new Meeting(
                    int.TryParse(meeting[4], out var meetingId) ? meetingId : 0,
                    meeting[3],
                    DateTime.TryParse(meeting[0], out var date) ? date : DateTime.MinValue,
                    int.TryParse(meeting[1], out var duration) ? duration : 0,
                    new Room(meeting[2])
                    ));
            }
            return meetings.ToArray();
        }

        public void AddMeeting(Meeting meeting)
        {
            File.AppendAllText(MeetingsFileLocation, $"{meeting.StartDate},{meeting.Duration},{meeting.Room?.Name}," +
                $"{meeting.Name},{meeting.Id}\n");
        }

        public Room[] GetAllRooms()
        {
            string[] fileContent = File.ReadAllLines(RoomsFileLocation);

            List<Room> rooms = new List<Room>();

            foreach (var line in fileContent)
            {
                string[] room = line.Split(",");
                rooms.Add(new Room(room[1], int.TryParse(room[0], out var roomId) ? roomId : 0));
            }
            return rooms.ToArray();
        }

        public void AddRoom(Room room)
        {
            File.AppendAllText(RoomsFileLocation, $"{room.Id},{room.Name}\n");
        }
    }
}
