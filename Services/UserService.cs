using SA_W4.Helpers;
using SA_W4.Models;
using SA_W4.Repositories;
using System.Buffers.Text;
using System.Reflection;
using System.Text;

namespace SA_W4.Services
{
    public class UserService : IUser
    {
        private readonly IConfiguration _config;

        public UserService(IConfiguration config)
        {
            _config = config;
        }
        public Response GetUsers()
        {
            try
            {
                var result = new UserRepository(_config).GetUsers();
                if (result.Count == 0)
                    return new(null, 404, "Información no encontrada");

                return new(result, 200, "Información encontrada.");
            }
            catch (Exception e)
            {
                return new Response($"{MethodBase.GetCurrentMethod()?.Name} exception: {e.Message}", 500, "Ocurrio un error al crear a la persona, intente más tarde");
            }
        }

        public Response DeleteUser(int idUser)
        {
            try
            {
                var result = new UserRepository(_config).DeleteUser(idUser);
                if (result == 0)
                    return new(null, 400, "Información no eliminada");

                return new(result, 200, "Información eliminada.");
            }
            catch (Exception e)
            {
                return new Response($"{MethodBase.GetCurrentMethod()?.Name} exception: {e.Message}", 500, "Ocurrio un error al crear a la persona, intente más tarde");
            }
        }

        public Response CreateUser(UserModel model)
        {
            try
            {
                var result = new UserRepository(_config).CreateUser(model);
                if (result == 0)
                    return new(null, 400, "Información no creada");

                return new(result, 200, "Información creada.");
            }
            catch (Exception e)
            {
                return new Response($"{MethodBase.GetCurrentMethod()?.Name} exception: {e.Message}", 500, "Ocurrio un error al crear a la persona, intente más tarde");
            }
        }

        public Response Login(UserModel model)
        {
            try
            {
                var base64EncodedBytes = Convert.FromBase64String(model.Password);
                model.Password = Encoding.UTF8.GetString(Convert.FromBase64String(Encoding.UTF8.GetString(base64EncodedBytes)));

                var result = new UserRepository(_config).Login(model);
                if (result is null)
                    return new(null, 400, "Información no encontrada");

                if (string.IsNullOrEmpty(result.Nombre))
                    return new(null, 400, "Información no encontrada");

                return new(result, 200, "Información encontrada.");
            }
            catch (Exception e)
            {
                return new Response($"{MethodBase.GetCurrentMethod()?.Name} exception: {e.Message}", 500, "Ocurrio un error al crear a la persona, intente más tarde");
            }
        }

        public Response UpdateUser(UserModel model)
        {
            try
            {
                var result = new UserRepository(_config).UpdateUser(model);
                if (result == 0)
                    return new(null, 400, "Información no actualizada");

                return new(result, 200, "Información actualizada.");
            }
            catch (Exception e)
            {
                return new Response($"{MethodBase.GetCurrentMethod()?.Name} exception: {e.Message}", 500, "Ocurrio un error al crear a la persona, intente más tarde");
            }
        }
    }
}
