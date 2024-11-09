using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ENSEK_Technical_Test.Models;
using ENSEK_Technical_Test.Data;
using ENSEK_Technical_Test.Services;
using ENSEK_Technical_Test.Services.Repository;

namespace ENSEK_Technical_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnergyAccountsController : ControllerBase
    {
        private readonly EnergyContext _context;
        private readonly ReadingRepository accountRepository;
        private readonly CsvParseAndSaveService csvParseAndSaveService;
        public EnergyAccountsController(EnergyContext context, ReadingRepository accountRepository, CsvParseAndSaveService csvParseAndSaveService)
        {
            _context = context;
            this.accountRepository = accountRepository;
            this.csvParseAndSaveService = csvParseAndSaveService;
        }

        // GET: api/EnergyAccounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnergyAccount>>> GetEnergyAccountList()
        {
            return await _context.EnergyAccounts.ToListAsync();
        }

        //// GET: api/EnergyAccounts/5
        //[HttpGet("GetReadingForAccount/{id}")]
        //public async Task<ActionResult<EnergyReading>> GetReadingForAccount(int id)
        //{
        //    var energyReading = await accountRepository.GetForAccountID(id);

        //    if (energyReading == null)
        //    {
        //        return NotFound();
        //    }

        //    return new OkObjectResult(energyReading);
        //}

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

        // POST: api/EnergyAccounts/Post
        [HttpPost("meter-reading-uploads")]
        public async Task<ActionResult<EnergyAccount>> PostMeterReadings(IFormFile file)
        {
             var savedReadings = csvParseAndSaveService.CsvParseAndSave(file);

             if (savedReadings.TotalFailed > 0)
             {
                 return new BadRequestObjectResult(savedReadings);
             }

             return new OkObjectResult(savedReadings);
        }

        private bool EnergyAccountExists(int id)
        {
            return _context.EnergyAccounts.Any(e => e.Id == id);
        }
    }
}
