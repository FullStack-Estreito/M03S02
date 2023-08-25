using FichaCadastroApi.Business;
using FichaCadastroApi.DTO.Ficha;
using FichaCadastroApi.Enumerators;
using FichaCadastroApi.Model;
using FichaCadastroApi.Partner.Adpter;
using FichaCadastroApi.Partner.Command;
using FichaCadastroApi.Partner.Singleton;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FichaCadastroApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DetalheController : ControllerBase
    {
        /// <summary>
        /// Declaração da ILogger privado e leitura injectado pelo construtor
        /// </summary>
        private readonly ILogger<DetalheController> _logger;

        /// <summary>
        /// Injeção do ILogger como parametro via construtor
        /// </summary>
        /// <param name="logger"></param>
        public DetalheController(ILogger<DetalheController> logger)
        {
            _logger = logger;
        }

        [HttpGet("concepcao-adpter")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult ConcepcaoAdpter()
        {
            IAdaptee adaptee = new Adaptee();
            ITarget target = new ConcepcaoAdpter(adaptee);

            var mensagem1 = "Adaptee interface is incompatible with the client.";

            var mensagem2 = target.GetRequest();

            return Ok(new { mensagem1, mensagem2 });
        }

        [HttpGet("concepcao-singleton")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult ConcepcaoSingleton()
        {
            ConcepcaoSingleton singleton = Partner.Singleton.ConcepcaoSingleton.InstanciaClasseLocal();
            var mensagem = singleton.Mensagem();

            return Ok(mensagem);
        }

        [HttpGet("concepcao-single-responsible")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult ConcepcaoSingleResponsible()
        {

            var detalheModel = new List<DetalheModel>()
                    {
                        new DetalheModel{ Id = 1, Nota = NotaEnum.Cinco, Feedback = "TEXTO UM" },
                        new DetalheModel{ Id = 2, Nota = NotaEnum.Tres, Feedback = "TEXTO DOIS" },
                        new DetalheModel{ Id = 3, Nota = NotaEnum.Cinco, Feedback = "TEXTO UM" },
                        new DetalheModel{ Id = 4, Nota = NotaEnum.Cinco, Feedback = "TEXTO UM" },
                        new DetalheModel{ Id = 5, Nota = NotaEnum.Cinco, Feedback = "TEXTO UM" }
                    };


            Top2DetalhesSRP top2DetalhesSRP = new Top2DetalhesSRP(detalheModel);
            top2DetalhesSRP.CalcularTopDois();

            var teste = top2DetalhesSRP.ToString();

            return Ok(new { top2DetalhesSRP, teste });

        }

        [HttpGet("concepcao-command")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult ConcepcaoCommand()
        {
            ConcepacaoCommand invoker = new ConcepacaoCommand();

            invoker.SetOnStart(new SimpleCommand("Say Hi!"));
            
            Receiver receiver = new Receiver();

            ComplexCommand complexCommand = new ComplexCommand(receiver, "Send email", "Save report");

            invoker.SetOnFinish(complexCommand);

            invoker.DoSomethingImportant();

            return Ok(new { receiver = receiver.Message, complexCommand = complexCommand.Message });
        }
    }
}