using Fiap.Web.Donation6.Data;
using Fiap.Web.Donation6.Models;

namespace Fiap.Web.Donation6.Repository
{
    public class CategoriaRepository
    {

        // DataContext _dataContext = new DataContext();
        private readonly DataContext _dataContext;
        public CategoriaRepository(DataContext dx) {
            _dataContext = dx;
        }


        public CategoriaModel FindById(int id)
        {
            var categoria = _dataContext.Categorias.Find(id);
            // SELECT * FROM categoria WHERE categoriaId = {id}

            return categoria;  
        }


        public IList<CategoriaModel> FindAll()
        {
            var categorias = _dataContext.Categorias.ToList() ?? new List<CategoriaModel>();
            return categorias;
        }


        public int Insert(CategoriaModel categoriaModel)
        {
            _dataContext.Categorias.Add(categoriaModel);
            _dataContext.SaveChanges();

            return categoriaModel.CategoriaId;
        }


        public void Update(CategoriaModel categoriaModel)
        {
            _dataContext.Categorias.Update(categoriaModel);
            _dataContext.SaveChanges();
        }


        public void Delete(int id)
        {
            //var categoria = new CategoriaModel() { CategoriaId = id };

            var categoria = FindById(id);
            _dataContext.Categorias.Remove(categoria);
            _dataContext.SaveChanges();

        }


    }
}

