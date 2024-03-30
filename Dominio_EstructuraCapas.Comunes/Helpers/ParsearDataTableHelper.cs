using Newtonsoft.Json;
using System.Data;

namespace Dominio_EstructuraCapas.Comunes.Helpers
{
    public class ParsearDataTableHelper
    {
        public static T ConvertDataTableToObject<T>(DataTable data) 
        {
            string json = JsonConvert.SerializeObject(data.Rows[0].Table);
            T objeto = JsonConvert.DeserializeObject<T>(json.Replace("[","").Replace("]",""));
            return objeto;
        }

        public static List<T> ConvertDataTableToList<T>(DataTable data)
        {
            string json = JsonConvert.SerializeObject(data);
            List<T> lista = JsonConvert.DeserializeObject<List<T>>(json);
            return lista;
        }
    }
}
