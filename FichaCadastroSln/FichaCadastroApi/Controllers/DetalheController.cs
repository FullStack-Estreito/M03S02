using FichaCadastroApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace FichaCadastroApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DetalheController : ControllerBase
    {
        private readonly ILogger<FichaController> _logger;
        private readonly FichaCadastroDbContext _fichaCadastroDbContext;


        public DetalheController(ILogger<FichaController> logger, FichaCadastroDbContext fichaCadastroDbContext)
        {
            _logger = logger;
            _fichaCadastroDbContext = fichaCadastroDbContext;
        }

    }
}