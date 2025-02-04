using FormulaOneV2.Server.Data;
using FormulaOneV2.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FormulaOneV2.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DriversController : ControllerBase
    {
        private readonly ApiDbContext _context;
        public DriversController(ApiDbContext apiDbContext)
        {
            _context = apiDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Driver>>> GetDrivers()
        {
            var drivers = await _context.Drives.ToListAsync();
            return Ok(drivers);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Driver>> GetDriversDetils(int id)
        {
            var driver = await _context.Drives.FirstOrDefaultAsync(d => d.Id == id);

            if (driver == null)
                return NotFound();

            return Ok(driver);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDriver(Driver driver)
        {
            _context.Drives.Add(driver);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDriversDetils), driver, driver.Id);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDriver(Driver driver, int id)
        {
            var driverExist = await _context.Drives.FirstOrDefaultAsync(d => d.Id == id);

            if (driverExist == null)
                return NotFound();

            driverExist.Name = driver.Name;
            driverExist.RacingNb = driver.RacingNb;
            driverExist.Team = driver.Team;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDriver(int id)
        {
            var driverExist = await _context.Drives.FirstOrDefaultAsync(d => d.Id == id);

            if (driverExist == null)
                return NotFound();

            _context.Remove(driverExist.Id);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
