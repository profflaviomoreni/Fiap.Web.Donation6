using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Web.Donation6.Models
{

    public enum TrocaStatus
    {
        Iniciado = 1,
        Analisado = 2,
        Finalizado = 3,
        Revertido = 4
    }


    [Table("Troca")]
    public class TrocaModel
    {

        [Key]
        public Guid TrocaId { get; set; } = Guid.NewGuid();

        public TrocaStatus TrocaStatus { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.Now;


        public int ProdutoIdMeu { get; set; } // FK

        [ForeignKey(nameof(ProdutoIdMeu))]
        public ProdutoModel ProdutoMeu { get; set; } // Navigation Property


        public int ProdutoIdEscolhido { get; set; } // FK

        [ForeignKey(nameof(ProdutoIdEscolhido))]
        public ProdutoModel ProdutoEscolhido { get; set; } // Navigation Property


    }
}
