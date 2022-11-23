using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TCC.Domain.Gateways.Services;

namespace TCC.Infra.DataProviders.Services
{
    public class ConsultarIAService : IConsultarIAGateway
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public async Task<List<Tuple<string, double>>> ObterAnalise(string image)
        {
            var httpContent = new StringContent("{\"Imagem\":\"" + image + "\"}", Encoding.UTF8, "application/json");
            var httpResponse = await httpClient.PostAsync($"{Environment.GetEnvironmentVariable("IA_SERVICE_ENDPONINT")}IaEngine/Analyze", httpContent);

            return JsonConvert.DeserializeObject<List<Tuple<string, double>>>(httpResponse.Content.ReadAsStringAsync().Result);
        }
    }
}
