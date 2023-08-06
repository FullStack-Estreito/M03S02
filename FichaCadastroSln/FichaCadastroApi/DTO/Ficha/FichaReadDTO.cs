using FichaCadastroApi.Base;
using FichaCadastroApi.Enumerators;

namespace FichaCadastroApi.DTO.Ficha
{
    public class FichaReadDTO : DTOBase 
    {
        public string Nome { get; set; }

        public string Email { get; set; }

        public DateTime DataNascimento { get; set; }

        public IList<FichaDetalheReadDTO>? FichaComDetalhes  { get; set; }
    }

    public class FichaDetalheReadDTO : DTOBase 
    {
        public NotaEnum Nota { get; set; }
        public string Justificativa { get; set; }
    }
}
