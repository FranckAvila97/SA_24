using Microsoft.AspNetCore.Mvc;

namespace SA_W4.Helpers
{
    public class CustomResponse
    {
        /// <summary>
        /// Clase para respuestas HTTP personalizadas
        /// </summary>
        /// <param name="response">Objeto Response que contiene los datos de respuesta del servicio</param>
        /// <returns>ObjectResult personalizado</returns>
        public static IActionResult GetResponseByStatus(Response response) => new ObjectResult(new { response.Data, response.Message, response.Status }) { StatusCode = response.Status };
    }
}
