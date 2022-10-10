using System;
using System.Threading.Tasks;
using TCC.Domain.Entities;

namespace TCC.Infra.DataProviders.Services.ExpressionIA
{
    public static class ExpressionIAService
    {
        public static async Task<AIResponse> AnalisarFace(string base64Image)
        {
            Random rnd = new Random();

            int emotion = rnd.Next(0, 6);
            int probability = rnd.Next(50, 100);

            return new AIResponse(emotion, probability);
        }
    }
}
