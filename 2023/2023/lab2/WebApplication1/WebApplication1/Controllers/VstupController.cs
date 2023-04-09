using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VstupController : ControllerBase
    {
        private readonly VstupContext _context;

        public VstupController(VstupContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Vstup>>> Get()
        {
            return Ok(await _context.Vstup.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Vstup>> Get(int id)
        {
            var vstup = await _context.Vstup.FindAsync(id);
            if (vstup == null) { 
                return BadRequest(404);
            }
            else
            {
                return Ok(vstup);
            }
        }

        [HttpPost]
        public async Task<ActionResult<List<Vstup>>> Add(Vstup shop)
        {   
            _context.Add(shop);
            await _context.SaveChangesAsync();
            return Ok(await _context.Vstup.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Vstup>>> Update(Vstup request)
        {
            var vstup = await _context.Vstup.FindAsync(request.Id);
            if (vstup == null)
            {
                return BadRequest(404);
            }
            else
            {
                vstup.FullName = request.FullName;
                vstup.Year = request.Year;
                vstup.ZNO = request.ZNO;
                vstup.Sex = request.Sex;

                await _context.SaveChangesAsync();

                return Ok(vstup);
            }
        }


        [HttpDelete]
        public async Task<ActionResult<List<Vstup>>> Delete(int id)
        {
            var vstup = await _context.Vstup.FindAsync(id);
            if (vstup == null)
            {
                return BadRequest(404);
            }
            else
            {
                _context.Vstup.Remove(vstup);

                await _context.SaveChangesAsync();

                return Ok(vstup);
            }
        }
    }
}
