using Microsoft.AspNetCore.Mvc;

namespace project_management_system_api.MemberDayOff
{
    [Route("api/[controller]")]
    [ApiController]
    public class DayOffController : Controller
    {
        private readonly DayOffDbContext _context;
        public DayOffController(DayOffDbContext context)
        {
            _context = context;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetMemberDayOff(long id)
        {
            var dayoff = await _context.MemberDayOff.FindAsync(id);

            if (dayoff == null)
            {
                return NotFound();
            }

            return Ok(dayoff);
        }


        [HttpPost("{FullName}/{FromDate}/{ToDate}/{Reason}/{IsMakingUp}/{ReportImage}")]
        public async Task<IActionResult> RequestDayOff(string FullName, DateTime FromDate, DateTime ToDate, string Reason, bool IsMakingUp, byte[] ReportImage)
        {
            var dayoff = new MemberDayOff()
            {
                FullName = FullName,
                FromDate = FromDate,
                ToDate = ToDate,
                Reason = Reason,
                IsMakingUp = IsMakingUp,
                ReportImage = ReportImage
            };

            _context.MemberDayOff.Add(dayoff);
            await _context.SaveChangesAsync();

            return Ok(dayoff);
        }
    }
}

