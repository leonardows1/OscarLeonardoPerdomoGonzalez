using Microsoft.AspNetCore.Mvc;
using OscarLeonardoPerdomoGonzalez.Models;
using OscarLeonardoPerdomoGonzalez.Services;

namespace OscarLeonardoPerdomoGonzalez.Controllers
{
    [ApiController]
    [Route("controller")]
    public class HalterofiliaController : ControllerBase
    {
        private readonly IHalterofiliaService _halterofiliaService;
        private readonly ILogger<HalterofiliaController> _logger;

        public HalterofiliaController(IHalterofiliaService halterofiliaService, ILogger<HalterofiliaController> logger)
        {
            _halterofiliaService = halterofiliaService;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<List<Halterofilia>> Get() => Ok(_halterofiliaService.GetTableroHalterofilias().Result);
    }
}
