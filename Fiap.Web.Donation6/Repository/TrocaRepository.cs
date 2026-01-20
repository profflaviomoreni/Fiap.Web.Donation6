using Fiap.Web.Donation6.Data;
using Fiap.Web.Donation6.Models;

namespace Fiap.Web.Donation6.Repository
{
    public class TrocaRepository
    {

        private readonly DataContext _dataContext;
        public TrocaRepository(DataContext dataContext) { 
            _dataContext = dataContext;
        }


        public Guid Insert(TrocaModel trocaModel)
        {
            _dataContext.Trocas.Add(trocaModel);
            _dataContext.SaveChanges();

            return trocaModel.TrocaId;
        }


    }
}
