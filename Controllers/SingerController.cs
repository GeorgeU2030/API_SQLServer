using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_SQLServer.Models;

namespace API_SQLServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SingerController : ControllerBase
    {
        private readonly SingerDbContext _context;

        public SingerController(SingerDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetSingers")]
        public async Task<IActionResult> GetSingers()
        {
            var listsingers = await _context.Singers.ToListAsync();
            return Ok(listsingers);
        }

        [HttpPost]
        [Route("AddSinger")]
        public async Task<IActionResult> AddSinger([FromBody] Singer request)
        {
            await _context.Singers.AddAsync(request);
            await _context.SaveChangesAsync();
            return Ok(request);
        }
    }
}