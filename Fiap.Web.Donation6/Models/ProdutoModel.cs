
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

        [Display(Name = "Nome do Produto" )]
        [Required(ErrorMessage = "O campo nome é requerido")]
        [StringLength(50)]
        public string NomeProduto { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "O campo descrição é requerido")]
        [StringLength(50)]
        public string Descricao { get; set; }

        [Display(Name = "Sugestão de Troca")]
        [Required(ErrorMessage = "O campo sugestão é requerido")]
        [StringLength(200)]
        public string SugestaoTroca { get; set; }


        public bool Disponivel { get; set; } = true;

        [Required(ErrorMessage = "O campo valor é requerido")]
        [Range(minimum: 10, maximum: 30000, ErrorMessage = "O valor do produto deverá ser entre R$ 10 e R$ 30.000")]
        public double? Valor { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;

        [Display(Name = "Data de Expiração")]
        [Required(ErrorMessage = "A data de expiração é requerida")]
        [DataType(DataType.Date)]
        public DateTime? DataExpiracao { get; set; }


        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; } // FK Categoria (Categoria que o produto pertence)

        [ForeignKey(nameof(CategoriaId))]
        public CategoriaModel? Categoria { get; set; } // FK - Navigation Property


        
        public int UsuarioId { get; set; } // FK Usuario (Usuário dono do produto)

        [ForeignKey(nameof(UsuarioId))]
        public UsuarioModel? Usuario { get; set; } // FK - Navigation Property   


    }
}
