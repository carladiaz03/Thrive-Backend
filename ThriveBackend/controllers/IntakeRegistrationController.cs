using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThriveBackend.Data;
using ThriveBackend.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ThriveBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThriveIntakeRegistrationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ThriveIntakeRegistrationController(ApplicationDbContext context)
        {
            _context = context;
        }

  [HttpPost]
public async Task<IActionResult> SubmitThriveIntakeForm([FromBody] ThriveIntakeRegistration form)
{
    if (form == null || !ModelState.IsValid)
    {
        Console.WriteLine("❌ Invalid form submission");
        return BadRequest("Invalid form data.");
    }

    Console.WriteLine($"📥 Received Data: {System.Text.Json.JsonSerializer.Serialize(form)}");

    using (var transaction = await _context.Database.BeginTransactionAsync())
    {
        try
        {
            // ✅ Check if refugee already exists
            var refugee = await _context.Refugees
                .FirstOrDefaultAsync(r => r.LastName == form.LastName && r.DateOfBirth == form.DateOfBirth);

            if (refugee == null)
            {
                // ✅ Create a new refugee (RefugeeID will be auto-generated)
                refugee = new Refugee
                {
                    FirstName = form.FirstName,
                    LastName = form.LastName,
                    DateOfBirth = form.DateOfBirth,
                    Email = form.EmailAddress,
                    Phone = form.PhoneNumber
                };

                _context.Refugees.Add(refugee);
                await _context.SaveChangesAsync(); // ✅ Now `RefugeeID` is auto-generated
            }

            // ✅ Save Thrive Intake Form Linked to Refugee
            var intakeForm = new ThriveIntakeRegistration
            {
                RefugeeID = refugee.RefugeeID,  // ✅ Uses auto-generated `RefugeeID`
                LastName = form.LastName,
                FirstName = form.FirstName,
                DateOfBirth = form.DateOfBirth,
                Gender = form.Gender,
                CountryOfOrigin = form.CountryOfOrigin,
                PhoneNumber = form.PhoneNumber,
                EmailAddress = form.EmailAddress,
                Address = form.Address,
                ProgramType = form.ProgramType,
                IntakeDate = form.IntakeDate,
                NavigatorName = form.NavigatorName,
                CurrentImmigrationStatus = form.CurrentImmigrationStatus,
                EligibilityDate = form.EligibilityDate,
                CaseWorker = !string.IsNullOrWhiteSpace(form.CaseWorker) ? form.CaseWorker : null,
                SubmissionDate = DateTime.UtcNow,
                AdditionalNotes = !string.IsNullOrWhiteSpace(form.AdditionalNotes) ? form.AdditionalNotes : null
            };

            _context.ThriveIntakeRegistrations.Add(intakeForm);
            await _context.SaveChangesAsync();

            await transaction.CommitAsync();
            Console.WriteLine($"✅ Form submitted successfully! RefugeeID: {refugee.RefugeeID}");
            return Ok(new { Message = "Form submitted successfully.", RefugeeID = refugee.RefugeeID });
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            Console.WriteLine($"❌ Error submitting form: {ex.Message}");
            return StatusCode(500, "Error submitting form: " + ex.Message);
        }
    }
}

    }
}

