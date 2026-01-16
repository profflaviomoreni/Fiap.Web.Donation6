using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Fiap.Web.Donation6.Models
{
    [Table("Usuario")]
    [Index(nameof(Email), nameof(Senha))]
    [Index(nameof(Nome))]
    public class UsuarioModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UsuarioId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Senha { get; set; }

        [Required]
        [StringLength(30)]
        public string Regra { get; set; }


    }
}
