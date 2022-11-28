using System.ComponentModel;

namespace TCC.Domain.Enums
{
    public enum Emocoes
    {
        [Description("Bravo(a)")]
        angry,
        [Description("Desgosto")]
        disgust,
        [Description("Assustado(a)")]
        scared,
        [Description("Feliz")]
        happy,
        [Description("Triste")]
        sad,
        [Description("Surpreso(a)")]
        surprised,
        [Description("Neutro")]
        neutral,
        [Description("Indefinido")]
        undefined
    }
}