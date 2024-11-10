using Microsoft.AspNetCore.Mvc;
using ENSEK_Technical_Test.Models;
using ENSEK_Technical_Test.Services;

namespace ENSEK_Technical_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnergyAccountsController : ControllerBase
    {
        private readonly EnergyContext _context;
        private readonly CsvParseAndSaveService csvParseAndSaveService;

        public EnergyAccountsController(EnergyContext context, CsvParseAndSaveService csvParseAndSaveService)
        {
            _context = context;
            this.csvParseAndSaveService = csvParseAndSaveService;
        }

        // GET: api/EnergyAccounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EnergyAccount>> GetEnergyAccount(int id)
        {
            var energyAccount = await _context.EnergyAccounts.FindAsync(id);

            if (energyAccount == null)
            {
                return NotFound();
            }

            return energyAccount;
        }

        // GET: api/EnergyAccounts/EnergyReading/5
        [HttpGet("EnergyReading/{id}")]
        public async Task<ActionResult<EnergyReading>> GetEnergyReading(int id)
        {
            var energyAccount = await _context.EnergyReadings.FindAsync(id);

            if (energyAccount == null)
            {
                return NotFound();
            }

            return energyAccount;
        }

        // POST: api/EnergyAccounts/meter-reading-uploads
        [HttpPost("meter-reading-uploads")]
        public async Task<ActionResult<EnergyAccount>> PostMeterReadings(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("need to upload a file!");
            }

            var savedReadings =  await csvParseAndSaveService.CsvParseAndSave(file);

             if (savedReadings.TotalSaved == 0)
             {
                 return new BadRequestObjectResult(savedReadings);
             }

             return new OkObjectResult(savedReadings);
        }
    }
}
