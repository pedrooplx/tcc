using System;
using System.Collections.Generic;
using System.Text;
using TCC.Domain.Enums;

namespace TCC.Domain.Entities
{
    public class AIResponse
    {
        public EmocoesEnum Emotion { get; set; }
        public double EmotionProbability { get; set; }

        public AIResponse() { }
        public AIResponse(EmocoesEnum emotion, double emotionProbability)
        {
            Emotion = emotion;
            EmotionProbability = emotionProbability * 100;
        }

        public AIResponse(int emotion, double emotionProbability)
        {
            Emotion = (EmocoesEnum)emotion;
            EmotionProbability = emotionProbability * 100;
        }
    }
}
