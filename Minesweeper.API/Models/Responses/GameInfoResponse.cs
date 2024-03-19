using System.Text.Json.Serialization;

namespace Minesweeper.API.Models.Responses
{
    public class GameInfoResponse
    {
        /// <summary>
        /// Идентификатор игры
        /// </summary>
        [JsonPropertyName("game_id")]
        public Guid GameId { get; set; }

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
        public int MinesCount { get; set; }

        /// <summary>
        /// Показатель завершения игры
        /// </summary>
        public bool Completed { get; set; }

        /// <summary>
        /// Игровое поле
        /// </summary>
        public string[][] Field { get; set; }
    }
}
