
namespace Fiap.Web.Donation6.Models
{
    public class ProdutoModel
    {

        public int ProdutoId { get; set; }

        public string NomeProduto { get; set; }

        public string Descricao { get; set; }

        public string SugestaoTroca { get; set; }

        public bool Disponivel { get; set; }

        public double Valor { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime DataExpiracao { get; set; }

        // FK Categoria (Categoria que o produto pertence)
        public int CategoriaId { get; set; }

        // FK Usuario (Usuário dono do produto)
        public int UsuarioId { get; set; }


    }
}
