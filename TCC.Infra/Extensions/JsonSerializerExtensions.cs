using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace TCC.Infra.Extensions
{
    public static class JsonSerializerExtensions
    {
        public static JsonNamingPolicy SnakeCaseNamingPolicySerializer(this JsonOptions jsonOptions)
        {
            return jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = SnakeCaseNamingPolicy.Instance;
        }
    }

    internal class SnakeCaseNamingPolicy : JsonNamingPolicy
    {
        public static SnakeCaseNamingPolicy Instance { get; } = new SnakeCaseNamingPolicy();

        public override string ConvertName(string name) => name.ToSnakeCase();
    }
}
