using DatabaseLayer;
using Microsoft.EntityFrameworkCore;
using Models;

namespace BusinessLogic.Services
{
    public class MeetingService
    {
        private readonly CalendarDbContext _calendar;

        public MeetingService(CalendarDbContext calendar)
        {
            _calendar = calendar;
        }

        public IEnumerable<Meeting> GetAll()
        {
            return _calendar.Meetings.ToList();
        }

        public Guid Create(Meeting meeting)
        {
            _calendar.Meetings.Add(meeting);

            _calendar.SaveChanges();

            return meeting.Id;
        }

        // TODO: GetByDateRange guess won't work, correct it later
        public IEnumerable<Meeting> GetByDateRange(DateTime? startDate, DateTime? endDate)
        {
            var baseQuery = _calendar.Meetings.AsNoTracking();

            if(startDate != null)
            {
                baseQuery = baseQuery.Where(x => x.StartDate >= startDate);
            }

            if(endDate != null)
            {
                baseQuery = baseQuery.Where(x => x.EndDate <= endDate);
            }

            return baseQuery.ToList();
        }
    }
}