using KoenCrud.Data;
using KoenCrud.Models.Dtos;
using KoenCrud.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KoenCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordPairsController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public WordPairsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetWordPairs()
        {
            return Ok(dbContext.WordPairs.ToList());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetWordPairById(Guid id)
        {
            var wordPairEntity = dbContext.WordPairs.Find(id);

            if (wordPairEntity == null)
            {
                return NotFound();
            }
            
            return Ok(wordPairEntity);
        }
         
        [HttpPost]
        public IActionResult AddWordPair(AddWordPairDto addWordPairDto) {
            var wordPairEntity = new WordPair()
            {
                Korean = addWordPairDto.Korean,
                English = addWordPairDto.English,
            };

            dbContext.WordPairs.Add(wordPairEntity);
            dbContext.SaveChanges();

            return Ok(wordPairEntity);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateWordPair(Guid id, UpdateWordPairDto updateWordPairDto)
        {
            var wordPairEntity = dbContext.WordPairs.Find(id);

            if (wordPairEntity == null)
            {
                return NotFound();
            }

            wordPairEntity.Korean = updateWordPairDto.Korean;
            wordPairEntity.English = updateWordPairDto.English;

            dbContext.SaveChanges();

            return Ok(wordPairEntity);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteWordPair(Guid id)
        {
            var wordPairEntity = dbContext.WordPairs.Find(id);

            if(wordPairEntity == null)
            {
                return NotFound();
            }

            dbContext.WordPairs.Remove(wordPairEntity);
            dbContext.SaveChanges();

            return Ok(wordPairEntity);
        }
    }
}
