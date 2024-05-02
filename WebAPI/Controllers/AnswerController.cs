using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.DB;
using WebAPI.DTO;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnswerController:ControllerBase
    {
        private readonly AnketDbContext _context;

        public AnswerController(AnketDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<List<Answer_View>> Get()
        {
            var cevap = await _context.Answer.ToListAsync();
            return cevap;
        }

        [HttpGet("{user_Name}")]
        public async Task<List<Answer_View>> Get(string user_Name)
        {
            var cevap = await _context.Answer.Where(x => x.user_name == user_Name).ToListAsync();
            return cevap;
        }
        [HttpPost]
        public async Task<Answer> Post(AnswerDTO answerModel)
        {
            var cevap = new Answer { 
                user_name = answerModel.user_name,
                question_id = answerModel.question_id,
                option_id = answerModel.option_id,
            };
            _context.Cevaplar.AddAsync(cevap);
            _context.SaveChanges();
            return cevap;
        }
    }
}
