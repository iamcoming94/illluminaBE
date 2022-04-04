using Microsoft.AspNetCore.Mvc;

namespace pb.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    public class PhoneBookController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<PhoneBookController> _logger;
        private readonly IPhoneBookInterface _phonebookService;

        public PhoneBookController(ILogger<PhoneBookController> logger, IPhoneBookInterface phoneBookService)
        {
            _logger = logger;
            _phonebookService = phoneBookService;
        }

        [HttpGet]
        [Route("/")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpGet("all")]
        //[Route("/all")]
        public async Task<IActionResult> GetAll()
        {
            //PhoneBook phoneBook = new PhoneBook();
            //phoneBook.Id = "1";
            //phoneBook.Name = "js";
            //phoneBook.Address = "278 Jalan Tembikai";
            //phoneBook.PhoneNumber = "123";

            //PhoneBook phoneBook2 = new PhoneBook();
            //phoneBook2.Id = "2";
            //phoneBook2.Name = "js2";
            //phoneBook2.Address = "39 Lorong Kota Permai";
            //phoneBook2.PhoneNumber = "12345";

            //List<PhoneBook> list = new List<PhoneBook>();
            //list.Add(phoneBook);
            //list.Add(phoneBook2);

            //return Ok(list);
            _logger.LogInformation("entered all");
            var result = await _phonebookService.GetAll();
            return Ok(result);
        }

        [HttpPost("add")]
        //[Route("/add")]
        public async Task<IActionResult> AddPhoneBook(PhoneBook phoneBook)
        {
            phoneBook.ID = 0;
            await _phonebookService.Add(phoneBook);
            return Ok();
        }

        [HttpGet("get")]
        //[Route("/get")]
        public async Task<IActionResult> GetSinglePhoneBook(int id)
        {
            _logger.LogInformation("entered get");
            var result = await _phonebookService.Get(id);
            return Ok(result);
        }

        [HttpPost("update")]
        //[Route("/update")]
        public async Task<IActionResult> UpdatePhoneBook(PhoneBook phoneBook)
        {
            _logger.LogInformation("entered update");
            await _phonebookService.Update(phoneBook);
            return Ok();
        }

        [HttpPost("delete")]
        //[Route("/delete")]
        public async Task<IActionResult> DeletePhoneBook(int id)
        {
            _logger.LogInformation("entered delete");
            await _phonebookService.Delete(id);
            return Ok();
        }
    }
}