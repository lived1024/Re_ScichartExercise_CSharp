using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace MultiSeries
{
    public class TransJson
    {
        public static Dictionary<String, double[]> JsonObjectToDictionary(String json)
        {
            JObject jsonObject = JObject.Parse(json);
            Dictionary<String, double[]> dictionary = jsonObject.ToObject<Dictionary<String, double[]>>();
            
            return dictionary;
        }

        public static List<double[]> JsonObjectToList(String json)
        {
            JObject jsonObject = JObject.Parse(json);
            JArray jArray = jsonObject.Value<JArray>("resultSet");
            List<double[]> list = jArray.ToObject<List<double[]>>();

            return list;
        }
    }
}
