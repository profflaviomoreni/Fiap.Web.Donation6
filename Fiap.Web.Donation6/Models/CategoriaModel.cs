using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Web.Donation6.Models
{

    [Table("Categoria")]
    [Index(nameof(NomeCategoria))]
    public class CategoriaModel
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoriaId { get; set; }


        [Required]
        [StringLength(100)]
        public string NomeCategoria { get; set; }

        [NotMapped]
        public string? Token { get; set; }
    }
}
