using Fiap.Web.Donation6.Data;
using Fiap.Web.Donation6.Models;

namespace Fiap.Web.Donation6.Repository
{
    public class UsuarioRepository
    {

        private readonly DataContext _dataContext;

        public UsuarioRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public List<UsuarioModel> FindAll()
        {

            return _dataContext.Usuarios.ToList() ?? new List<UsuarioModel>();
        }


        public UsuarioModel FindById(int id)
        {
            return _dataContext.Usuarios.Find(id);
        }


        public int Insert(UsuarioModel usuarioModel)
        {
            _dataContext.Usuarios.Add(usuarioModel);
            _dataContext.SaveChanges();

            return usuarioModel.UsuarioId;
        }


        public void Update(UsuarioModel usuarioModel)
        {
            _dataContext.Usuarios.Update(usuarioModel);
            _dataContext.SaveChanges();
        }


        public void Delete(int id)
        {
            var usuario = new UsuarioModel()
            {
                UsuarioId = id
            };

            _dataContext.Usuarios.Remove(usuario);
            _dataContext.SaveChanges();

        }


    }
}
