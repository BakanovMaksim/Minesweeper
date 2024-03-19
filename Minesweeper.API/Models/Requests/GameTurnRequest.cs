using System.Text.Json.Serialization;

namespace Minesweeper.API.Models.Requests
{
    public class GameTurnRequest
    {
        /// <summary>
        /// Идентификатор игры
        /// </summary>
        [JsonPropertyName("game_id")]
        public Guid GameId { get; set; }

        /// <summary>
        /// Колонка выбранной клетки
        /// </summary>
        public int Col { get;set; }

        /// <summary>
        /// Ряд выбранной клетки
        /// </summary>
        public int Row {  get;set; }
    }
}
