using System.Text.Json.Serialization;

namespace Minesweeper.API.Models.Requests
{
    public class NewGameRequest
    {
        /// <summary>
        /// Ширина игрового поля
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Высота игрового поля
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Количество мин
        /// </summary>
        [JsonPropertyName("mines_count")]
        public int MinesCount {  get; set; }
    }
}
