using BusinessLogic.Services;
using CalendarMVCSIte.Models;
using DatabaseLayer;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Diagnostics;

namespace CalendarMVCSIte.Controllers
{
    public class MeetingController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MeetingService _meetingService;

        public MeetingController(ILogger<HomeController> logger, CalendarDbContext calendar)
        {
            _logger = logger;
            _meetingService = new MeetingService(calendar);
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new IndexViewModel();

            var meetings = _meetingService.GetAll();

            model.Meetings = meetings;

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm] CreateMeetingModel model)
        {
            if (model != null)
            {
                _meetingService.Create(new Meeting
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate
                });
            }
            else
            {
                throw new ArgumentException("Invalid input in form. Can't add to database!");
            }

            return Redirect("Index");
        }
    }
}