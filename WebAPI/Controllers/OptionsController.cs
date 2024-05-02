using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.DB;
using WebAPI.DTO;
using WebAPI.Models;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OptionsController:ControllerBase
    {
        private readonly AnketDbContext _context;

        public OptionsController(AnketDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<List<Options>> Get()
        {
            var option = await _context.Secenekler.ToListAsync();
            return option;
        }
        [HttpGet("{option_id}")]
        public async Task<Options> GetOption(int option_id)
        {
            var option = await _context.Secenekler.FirstOrDefaultAsync(x=> x.question_id==option_id);
           return option;
        }
        [HttpPost]
        public async Task<Options> Post(OptionDTO OptionModel)
        {
            var secenek = new Options
            {
                question_id = OptionModel.question_id,
                option = OptionModel.option,
            };
            _context.Secenekler.AddAsync(secenek);
            _context.SaveChanges();
            return secenek;
        }

    }
}
