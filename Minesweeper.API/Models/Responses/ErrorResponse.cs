using System.Text.Json.Serialization;

namespace Minesweeper.API.Models.Responses
{
    public class ErrorResponse
    {
        [JsonPropertyName("error")]
        public string? Error {  get; set; }
    }
}
