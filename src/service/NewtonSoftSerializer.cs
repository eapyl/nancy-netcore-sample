using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SampleNancy
{
    public class NewtonSoftSerializer : JsonSerializer
    {
        public NewtonSoftSerializer()
        {
            this.ContractResolver = new CamelCasePropertyNamesContractResolver();
            this.Formatting = Formatting.Indented;
        }
    }
}