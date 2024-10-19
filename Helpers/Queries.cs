using Dapper;
using Microsoft.Data.SqlClient;
using SA_W4.Models;
using System.Data;

namespace SA_W4.Helpers
{
    public class Queries
    {
        private readonly static Settings _settings = SettingsBuilder.Builder;
        public static string setEnvironment(string localEnvironment)
        {
            ConfigurationRoot configuration = (ConfigurationRoot)new ConfigurationBuilder()
             .AddEnvironmentVariables()
            .Build();
            return configuration["environmentSqlserver"] ?? localEnvironment;
        }

        /// <summary>
        /// Ejecuta procedimiento almacenado, con los parametros indicados
        /// </summary>
        /// <typeparam name="T">Clase Modelo a devolver</typeparam>
        /// <param name="connectionString">Conexión a base de datos</param>
        /// <param name="script">Nombre de procedimiento almacenado a ejecutar</param>
        /// <param name="commandType">Tipo de ejecución</param>
        /// <param name="parameters">Diccionario parametros a ejecutar</param>
        /// <returns>Primer objeto de la consulta</returns>
        public static dynamic Execute<T>(string script, object parameters = null)
        {
            using SqlConnection connection = new DatabaseConnection().Connection(_settings.ConnectionString);
            return connection.Query<T>(script, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        /// <summary>
        /// Ejecuta procedimiento almacenado, con los parametros indicados
        /// </summary>
        /// <typeparam name="T">Clase Modelo a devolver</typeparam>
        /// <param name="connectionString">Conexión a base de datos</param>
        /// <param name="script">Nombre de procedimiento almacenado a ejecutar</param>
        /// <param name="commandType">Tipo de ejecución</param>
        /// <param name="parameters">Diccionario parametros a ejecutar</param>
        /// <returns>Lista de Clase Modelo</returns>
        public static dynamic ExecuteToList<T>(string script, object parameters = null)
        {
            using SqlConnection connection = new DatabaseConnection().Connection(_settings.ConnectionString);
            return connection.Query<T>(script, parameters, commandType: CommandType.StoredProcedure).ToList();
        }

        /// <summary>
        /// Ejecuta procedimiento almacenado, con los parametros indicados
        /// </summary>
        /// <typeparam name="T">Clase Modelo a devolver</typeparam>
        /// <param name="connectionString">Conexión a base de datos</param>
        /// <param name="script">Nombre de procedimiento almacenado a ejecutar</param>
        /// <param name="commandType">Tipo de ejecución</param>
        /// <param name="parameters">Diccionario parametros a ejecutar</param>
        /// <returns>Int de filas afectadas</returns>
        public static int ExecuteNonQuery(string script, object parameters = null)
        {
            using SqlConnection connection = new DatabaseConnection().Connection(_settings.ConnectionString);
            return connection.Execute(script, parameters, commandType: CommandType.StoredProcedure);
        }

        /// <summary>
        /// Ejecuta procedimiento almacenado, con los parametros indicados
        /// </summary>
        /// <typeparam name="T">Clase Modelo a devolver</typeparam>
        /// <param name="connectionString">Conexión a base de datos</param>
        /// <param name="script">Nombre de procedimiento almacenado a ejecutar</param>
        /// <param name="commandType">Tipo de ejecución</param>
        /// <param name="parameters">Diccionario parametros a ejecutar</param>
        /// <returns>Datatable con información obtenida</returns>
        public static DataTable ExecuteReader(string script, object parameters = null)
        {
            using SqlConnection connection = new DatabaseConnection().Connection(_settings.ConnectionString);
            DataTable table = new();
            table.Load(connection.ExecuteReader(script, parameters, commandType: CommandType.StoredProcedure));
            return table;
        }
    }
}
