
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Web.Donation6.Models
{
    [Table("Produto")]
    public class ProdutoModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProdutoId { get; set; }

        [Required]
        [StringLength(50)]
        public string NomeProduto { get; set; }

        [Required]
        [StringLength(50)]
        public string Descricao { get; set; }

        [Required]
        [StringLength(200)]
        public string SugestaoTroca { get; set; }


        public bool Disponivel { get; set; } = true;

        [Required]
        public double Valor { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public DateTime DataExpiracao { get; set; }

        
        public int CategoriaId { get; set; } // FK Categoria (Categoria que o produto pertence)

        [ForeignKey(nameof(CategoriaId))]
        public CategoriaModel? Categoria { get; set; } // FK - Navigation Property


        
        public int UsuarioId { get; set; } // FK Usuario (Usuário dono do produto)

        [ForeignKey(nameof(UsuarioId))]
        public UsuarioModel? Usuario { get; set; } // FK - Navigation Property   


    }
}
