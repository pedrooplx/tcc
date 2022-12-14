using System.Threading.Tasks;

namespace TCC.Application.UseCases.Abstract
{
    public interface IUseCaseAsync <in TRequest>
    {
        Task ExecuteAsync(TRequest request);
    }
    public interface IUseCaseAsync<TRequest, TResponse>
    {
        Task<TResponse> ExecuteAsync(TRequest request);
    }
}
