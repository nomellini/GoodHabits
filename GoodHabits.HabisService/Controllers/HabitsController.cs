using Microsoft.AspNetCore.Mvc;

namespace GoodHabits.HabitsService.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class HabitsController : ControllerBase
    {
        private readonly ILogger<HabitsController> _logger;
        private readonly IHabitsService _habitService;

        public HabitsController(ILogger<HabitsController> logger,
            IHabitsService habitService)
        {
            _logger = logger;
            _habitService = habitService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync() => Ok(await _habitService.GetAllItems());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string Id)
        {
            return Ok(await _habitService.GetById(Id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateHabitDto request) => Ok(await _habitService.Create(request.Name, request.Description));
    }
}
