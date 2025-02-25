using Microsoft.AspNetCore.Mvc;
using ThriveBackend.Data;
using ThriveBackend.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ThriveBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommunityOutreachIntakeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CommunityOutreachIntakeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> SubmitForm([FromBody] CommunityOutreachIntake form)
        {
            if (form == null)
                return BadRequest("Invalid form data");

            // Ensure refugee is registered first
            var refugeeExists = _context.ThriveIntakeRegistrations
                .Any(r => r.LastName == form.LastName && r.DateOfBirth == form.DateOfBirth);

            if (!refugeeExists)
                return BadRequest("This refugee has not registered through the Thrive Intake Form.");

            _context.CommunityOutreachIntakes.Add(form);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Community outreach intake form submitted!", data = form });
        }
    }
}
