using TCC.Domain.Enums;

namespace TCC.Application.Models
{
    public class AIResponse
    {
        public Emocoes Emotion { get; set; }
        public double EmotionProbability {get; set; }

        public AIResponse() { }
        public AIResponse(Emocoes emotion, double emotionProbability)
        {
            Emotion = emotion;
            EmotionProbability = emotionProbability * 100;
        }
    }
}
