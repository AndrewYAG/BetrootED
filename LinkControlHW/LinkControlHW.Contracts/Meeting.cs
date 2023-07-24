using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkControlHW.Contracts
{
    public class Meeting
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public Room Room { get; set; }

        public Meeting(int iD, string name, DateTime startDate, int duration, Room room)
        {
            Id = iD;
            Name = name;
            StartDate = startDate;
            Duration = duration;
            Room = room;
        }

    }
}
