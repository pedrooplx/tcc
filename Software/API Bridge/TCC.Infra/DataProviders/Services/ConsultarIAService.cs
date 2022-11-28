using Microsoft.Extensions.Configuration;
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

        private readonly IConfiguration _configuration;

        public ConsultarIAService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<Tuple<string, double>>> ObterAnalise(string image)
        {
            var httpContent = new StringContent("{\"Imagem\":\"" + image + "\"}", Encoding.UTF8, "application/json");
            var httpResponse = await httpClient.PostAsync($"{_configuration.GetSection("IA_MS_ENDPOINT").Value}IaEngine/Analyze", httpContent);

            return JsonConvert.DeserializeObject<List<Tuple<string, double>>>(httpResponse.Content.ReadAsStringAsync().Result);
        }
    }
}
