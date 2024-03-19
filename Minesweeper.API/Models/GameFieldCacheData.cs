using Minesweeper.Core.Models;

namespace Minesweeper.API.Models
{
    public class GameFieldCacheData
    {
        public Guid GameId { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public int MinesCount { get; set; }

        public FieldCell[][] Field { get; set; }
    }
}
