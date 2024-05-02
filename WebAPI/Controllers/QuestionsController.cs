using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using WebAPI.DB;
using WebAPI.DTO;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionsController : ControllerBase
    {
        private readonly AnketDbContext _context;

        public QuestionsController(AnketDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<List<Questions>> Get()
        {
            var question = await _context.Sorular.ToListAsync();
            return question;
        }

        [HttpGet("{id}")]
        public async Task<Questions> Get(int id)
        {
            var question = await _context.Sorular.FirstOrDefaultAsync(x => x.Id == id);
            return question;
        }
        [HttpPost]
        public async Task<Questions> Post(QuestionDTO QuestionModel)
        {
            var soru = new Questions
            {
                Question = QuestionModel.Question,
                type = QuestionModel.type
            };
            _context.Sorular.AddAsync(soru);
            _context.SaveChanges();
            return soru;
            
        }
    }
}
