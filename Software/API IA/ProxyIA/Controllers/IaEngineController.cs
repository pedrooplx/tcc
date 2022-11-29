using Microsoft.AspNetCore.Mvc;
using ProxyIA.Utils;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProxyIA.Controllers
{
    [ApiController]
    [Route("IaEngine/Analyze")]
    public class IaEngineController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Analyse(Receive Base64)
        {
            List<Tuple<string, double>> Resultado = new List<Tuple<string, double>>();

            Resultado = IaEngine.IaEngine.AnalisarFace(Base64.Imagem);

            return Ok(Resultado);
        }
    }
}
