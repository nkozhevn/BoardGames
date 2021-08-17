using BoardGames.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoardGames.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GamesController : ControllerBase
    {
        GamesContext db;
        public GamesController(GamesContext context)
        {
            db = context;
            if (!db.Games.Any())
            {
                db.Games.Add(new Game { Name = "Carcassone", Rating = 7 });
                db.Games.Add(new Game { Name = "Blood Rage", Rating = 9 });
                db.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Game>>> Get()
        {
            return await db.Games.ToListAsync();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> Get(int id)
        {
            Game user = await db.Games.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
                return NotFound();
            return new ObjectResult(user);
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<Game>> Post(Game game)
        {
            // If any errors - return 400
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // If no errors - saving to db
            db.Games.Add(game);
            await db.SaveChangesAsync();
            return Ok(game);
        }

        // PUT api/users/
        [HttpPut]
        public async Task<ActionResult<Game>> Put(Game game)
        {
            if (game == null)
            {
                return BadRequest();
            }
            if (!db.Games.Any(x => x.Id == game.Id))
            {
                return NotFound();
            }

            db.Update(game);
            await db.SaveChangesAsync();
            return Ok(game);
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Game>> Delete(int id)
        {
            Game game = db.Games.FirstOrDefault(x => x.Id == id);
            if (game == null)
            {
                return NotFound();
            }
            db.Games.Remove(game);
            await db.SaveChangesAsync();
            return Ok(game);
        }
    }
}
