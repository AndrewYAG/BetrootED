using Microsoft.EntityFrameworkCore;
using Models;

namespace DatabaseLayer
{
    public class CalendarDbContext : DbContext
    {
        public DbSet<Meeting> Meetings { get; set; }

        public CalendarDbContext(DbContextOptions<CalendarDbContext> options) : base(options)
        {
        }
    }
}