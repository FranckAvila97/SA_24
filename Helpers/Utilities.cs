using System.Reflection;

namespace SA_W4.Helpers
{
    public class Utilities
    {
        public static Dictionary<string, object> ConvertObjectToDictionary<T>(object obj) where T : class
        {
            var dictionary = new Dictionary<string, object>();
            try
            {
                Type type = obj.GetType();
                PropertyInfo[]? properties = type.GetProperties();

                properties.ToList().ForEach(property =>
                {

                    if (property.GetValue(obj, null) is not null)
                        if (property.GetValue(obj, null) is bool boolValue)
                            dictionary.Add("@p_" + property.Name, boolValue ? "1" : "0");
                        else
                            dictionary.Add("@p_" + property.Name, property?.GetValue(obj, null).ToString());
                });
            }
            catch (Exception e)
            {
                throw new Exception($"Excepcion {MethodBase.GetCurrentMethod().Name}: {e.Message}.");
            }
            return dictionary;
        }
    }
}
