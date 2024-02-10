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
    public class SongController : ControllerBase
    {
        private readonly SingerDbContext _context;

        public SongController(SingerDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetSongs")]
        public async Task<IActionResult> GetSongs()
        {
            var listsingers = await _context.Songs.ToListAsync();
            return Ok(listsingers);
        }

        [HttpPost]
        [Route("AddSong")]
        public async Task<IActionResult> AddSong([FromBody] Song request)
        {
            await _context.Songs.AddAsync(request);
            await _context.SaveChangesAsync();
            return Ok(request);
        }
    }
}