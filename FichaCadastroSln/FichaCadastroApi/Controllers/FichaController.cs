using AutoMapper;
using FichaCadastroApi.DTO.Ficha;
using FichaCadastroApi.Model;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Linq;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using FichaCadastroApi.Business;
using FichaCadastroApi.Enumerators;
using FichaCadastroApi.Singleton;

namespace FichaCadastroApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FichaController : ControllerBase
    {
        private readonly ILogger<FichaController> _logger;
        private readonly FichaCadastroDbContext _fichaCadastroDbContext;
        private readonly IMapper _mapper;

        public FichaController(ILogger<FichaController> logger, FichaCadastroDbContext fichaCadastroDbContext, IMapper mapper)
        {
            _logger = logger;
            _fichaCadastroDbContext = fichaCadastroDbContext;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<FichaReadDTO> Post([FromBody] FichaCreateDTO fichaCreateDTO)
        {
            try
            {
                

                _logger.LogInformation("Create Ficha do M�todo POST da Controller", new { email = fichaCreateDTO.EmailInformado });

                var fichaModel = _mapper.Map<FichaModel>(fichaCreateDTO);

                if (_fichaCadastroDbContext.FichaModels.ToList().Exists(e => e.Email == fichaCreateDTO.EmailInformado))
                {
                    return Conflict(new { erro = "E-mail Cadastrado" });
                }

                var fichaReadDTO = _mapper.Map<FichaReadDTO>(fichaModel);

                MensagemSingleton singleton = MensagemSingleton.InstanciaClasseLocal();
                fichaReadDTO.MensagemSingleton = singleton.Mensagem();

                return StatusCode(HttpStatusCode.Created.GetHashCode(), fichaReadDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex);
            }

        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<FichaReadDTO>> Get([FromQuery] string? email)
        {
            try
            {
                List<FichaModel> fichaModels;

                if (email.IsNullOrEmpty()) // email == null || email == "" 
                {
                    fichaModels = _fichaCadastroDbContext.FichaModels
                                                         .Include(i => i.Detalhes)
                                                         .ToList();
                }
                else
                {
                    fichaModels = _fichaCadastroDbContext.FichaModels
                                                         //.Where(w => w.Email.Equals(email!))
                                                         .Where(w => w.Email == email)
                                                         .Include(i => i.Detalhes).ToList();
                }

                var fichaReadDTO = _mapper.Map<List<FichaReadDTO>>(fichaModels);

                MensagemSingleton singleton = MensagemSingleton.InstanciaClasseLocal();
                fichaReadDTO.ForEach(s => s.MensagemSingleton = singleton.Mensagem());

                return Ok(fichaReadDTO);
            }
            catch (Exception ex)
            {
                _logger.LogTrace(ex, "OLÁ MUNDO", new { email });
                return StatusCode(500, ex);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<FichaReadDTO> Get(int id)
        {
            try
            {
                var fichaModel = _fichaCadastroDbContext.FichaModels.Find(id);

                if (fichaModel == null)
                {
                    return NotFound(new { erro = "Ficha n�o encontrada" });
                }

                var fichaReadDTO = _mapper.Map<FichaReadDTO>(fichaModel);
                return Ok(fichaReadDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex);
            }
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<FichaReadDTO> Put(int id, [FromBody] FichaUpdateDTO fichaUpdateDTO)
        {
            try
            {
                var fichaModel = _fichaCadastroDbContext.FichaModels.Where(w => w.Id == id).FirstOrDefault();

                if (fichaModel == null)
                {
                    return NotFound(new { erro = "Registro n�o encontrado" });
                }

                fichaModel = _mapper.Map(fichaUpdateDTO, fichaModel);

                _fichaCadastroDbContext.FichaModels.Update(fichaModel);
                _fichaCadastroDbContext.SaveChanges();
                var fichaReadDTO = _mapper.Map<FichaReadDTO>(fichaModel);

                return Ok(fichaReadDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Delete(int id)
        {
            try
            {
                /*
                 * Bug no c�digo
                 * Ele n�o est� montando o relacionamento para efetuar a consulta entre Ficha e Detalhe (INNER JOIN)
                 * SELECT * 
                 * FROM Ficha
                 * INNER JOIN Detalhe
                 * WHERE Ficha.Id = 1
                 */
                var fichaModel = _fichaCadastroDbContext.FichaModels.Where(w => w.Id == id).FirstOrDefault();

                if (fichaModel == null)
                {
                    return NotFound(new { erro = "Registro n�o encontrado" });
                }

                if (fichaModel.Detalhes != null && fichaModel.Detalhes!.Count > 0)
                {
                    return NotFound(new { erro = "Existe Detalhes relacionados com a ficha" });
                }

                _fichaCadastroDbContext.FichaModels.Remove(fichaModel);
                _fichaCadastroDbContext.SaveChanges();

                return StatusCode(200);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }


        [HttpGet("topregister/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult GetTop2(int id)
        {
            try
            {
                var detalheModel = _fichaCadastroDbContext.DetalheModels
                                                     .Include(w => w.Ficha)    
                                                     .Where(w => w.Ficha.Id == id)
                                                     .ToList();

                if (detalheModel == null)
                {
                    detalheModel = new List<DetalheModel>()
                    {
                        new DetalheModel{ Id = id, Nota = NotaEnum.Cinco, Feedback = "TEXTO UM" },
                        new DetalheModel{ Id = id, Nota = NotaEnum.Tres, Feedback = "TEXTO DOIS" },
                        new DetalheModel{ Id = id, Nota = NotaEnum.Cinco, Feedback = "TEXTO UM" },
                        new DetalheModel{ Id = id, Nota = NotaEnum.Cinco, Feedback = "TEXTO UM" },
                        new DetalheModel{ Id = id, Nota = NotaEnum.Cinco, Feedback = "TEXTO UM" }
                    };
                }


                Top2DetalhesSRP top2DetalhesSRP = new Top2DetalhesSRP(detalheModel);
                top2DetalhesSRP.CalcularTopDois();

                var teste = top2DetalhesSRP.ToString();

                return Ok(top2DetalhesSRP);
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex);
            }
        }
    }
}