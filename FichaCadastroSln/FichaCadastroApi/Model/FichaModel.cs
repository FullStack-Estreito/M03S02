using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FichaCadastroApi.Model

{
    [Table("Ficha")]
    public class FichaModel

    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    
        [Column(TypeName = "VARCHAR"), Required, StringLength(250)]
        public string Nome { get; set; }

        [Column(TypeName = "VARCHAR"), Required, StringLength(100)]
        public string Email { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }

        [Required]
        public DateTime DataCadastro { get; set; }

       

    }

}
