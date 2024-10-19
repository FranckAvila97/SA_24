using SA_W4.Helpers;
using SA_W4.Models;
using System.Reflection;

namespace SA_W4.Repositories
{
    public class UserRepository
    {
        private readonly IConfiguration _config;
        private readonly Settings _settings;

        public UserRepository(IConfiguration config)
        {
            _config = config;
            _settings = _config.GetSection("Settings").Get<Settings>();
        }

        public List<UserModel> GetUsers()
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "p_action", 1 }
                };
                return Queries.ExecuteToList<UserModel>(_settings.StoredProcedures.Users, parameters);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Excepcion {MethodBase.GetCurrentMethod().Name}: {e.Message}.");
                return [];
            }
        }

        public UserModel Login(UserModel model)
        {
            var parameters = Utilities.ConvertObjectToDictionary<UserModel>(model);
            parameters.Add("@p_action", 5);
            var result = Queries.Execute<UserModel>(_settings.StoredProcedures.Users, parameters);
            return result;
        }

        public int CreateUser(UserModel model)
        {
            try
            {
                var parameters = Utilities.ConvertObjectToDictionary<UserModel>(model);
                parameters.Add("@p_action", 2);
                var result = Queries.ExecuteNonQuery(_settings.StoredProcedures.Users, parameters);
                return result;
            }
            catch (Exception e)
            {

                Console.WriteLine($"Excepcion {MethodBase.GetCurrentMethod().Name}: {e.Message}.");
                return 0;
            }
        }
        
        public int UpdateUser(UserModel model)
        {
            try
            {
                var parameters = Utilities.ConvertObjectToDictionary<UserModel>(model);
                parameters.Add("@p_action", 3);
                var result = Queries.ExecuteNonQuery(_settings.StoredProcedures.Users, parameters);
                return result;
            }
            catch (Exception e)
            {

                Console.WriteLine($"Excepcion {MethodBase.GetCurrentMethod().Name}: {e.Message}.");
                return 0;
            }
        }
        
        public int DeleteUser(int idUser)
        {
            try
            {
                Dictionary<string, object> parameters = new()
                {
                    { "p_action", 4 },
                    { "p_id", idUser }
                };
                var result = Queries.ExecuteNonQuery(_settings.StoredProcedures.Users, parameters);
                return result;
            }
            catch (Exception e)
            {

                Console.WriteLine($"Excepcion {MethodBase.GetCurrentMethod().Name}: {e.Message}.");
                return 0;
            }
        }
    }
}
