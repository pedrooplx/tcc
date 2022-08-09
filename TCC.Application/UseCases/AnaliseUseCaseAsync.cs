using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TCC.Application.Abstract;
using TCC.Application.Models;

namespace TCC.Application.UseCases
{
    public class AnaliseUseCaseAsync : IUseCaseAsync<AnaliseRequest>
    {
        private readonly ILogger<AnaliseUseCaseAsync> _logger;

        public AnaliseUseCaseAsync(ILogger<AnaliseUseCaseAsync> logger)
        {
            _logger = logger;
        }

        public async Task ExecuteAsync(AnaliseRequest request)
        {
            var result = artificialInteligence(request.Imagem);

            if (result != null)
            {
                //db-persistence
            }

            Task.CompletedTask.Wait();
        }

        private object artificialInteligence(string image)
        {
            return true;
        }
    }
}
