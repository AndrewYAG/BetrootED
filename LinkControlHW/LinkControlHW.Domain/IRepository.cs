using LinkControlHW.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkControlHW.Domain
{
    public interface IRepository
    {
        public Meeting[] GetAllMeetings();
        public void AddMeeting(Meeting meeting);

        public Room[] GetAllRooms();
        public void AddRoom(Room room);
    }
}
