using FichaCadastroApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace FichaCadastroApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FichaController : ControllerBase
    {
        private readonly ILogger<FichaController> _logger;
        private readonly FichaCadastroDbContext _fichaCadastroDbContext;


        public FichaController(ILogger<FichaController> logger, FichaCadastroDbContext fichaCadastroDbContext)
        {
            _logger = logger;
            _fichaCadastroDbContext = fichaCadastroDbContext;
        }

    }
}