using FichaCadastroApi.Base;
using FichaCadastroApi.Enumerators;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FichaCadastroApi.Model
{
    [Table("Detalhe")]
    public class DetalheModel : RelacionalBase, IModel
    {
       

        [Column(TypeName = "VARCHAR"), Required, StringLength(500)]
        public string? Feedback { get; set; }

        [Required]
        public NotaEnum Nota { get; set; }

        [Required]
        public bool Ativado { get; set; }

        [Required]
        public virtual FichaModel Ficha { get; set; }
    }

    public interface IModel 
    {
        public int Id { get; set; }
    }


    /*Exemplo*/
    public class ExemploQualquerCoisa<T> : IExemploQualquerCoisa
    {
        private readonly FichaCadastroDbContext _fichaCadastroDbContext;

        public ExemploQualquerCoisa(FichaCadastroDbContext fichaCadastroDbContext)
        {
            _fichaCadastroDbContext = fichaCadastroDbContext;
        }

        public void Salvar<T>(IModel model)
        {
            _fichaCadastroDbContext.Add((T)model);
            _fichaCadastroDbContext.SaveChanges();
        }
    }

    public class ExemploDoisInterface<T> : IExemploQualquerCoisa
    {
        private readonly FichaCadastroDbContext _fichaCadastroDbContext;

        public ExemploDoisInterface(FichaCadastroDbContext fichaCadastroDbContext)
        {
            _fichaCadastroDbContext = fichaCadastroDbContext;
        }

        public void Salvar<T>(IModel model)
        {

            this.NomeString();
            _fichaCadastroDbContext.Add((T)model);
            _fichaCadastroDbContext.SaveChanges();
        }

        private void NomeString()
        {

        }
    }


    public interface IExemploQualquerCoisa
    {
        void Salvar<T>(IModel model);
    }

    public class ExemploDois
    {
        private readonly IExemploQualquerCoisa exemploQualquerCoisa;
        private readonly IExemploQualquerCoisa exemploDoisInterface;


        public ExemploDois(IExemploQualquerCoisa exemploQualquerCoisa, IExemploQualquerCoisa exemploDoisInterface)
        {
            this.exemploQualquerCoisa = exemploQualquerCoisa;
            this.exemploDoisInterface = exemploDoisInterface;
        }

        public void Salvar(DetalheModel model, FichaModel exemplo) 
        {
            IModel model2 = model;

            this.exemploQualquerCoisa.Salvar<DetalheModel>(model2);

            this.exemploDoisInterface.Salvar<FichaModel>(exemplo);


        }

    }

}
