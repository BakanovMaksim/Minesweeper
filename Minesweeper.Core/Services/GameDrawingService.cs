using Minesweeper.Core.Models;

namespace Minesweeper.Core.Services
{
    public class GameDrawingService : IGameDrawingService
    {
        public string[][] GetNewField(int width, int height)
        {
            var field = new string[height][];

            for (var i = 0; i < height; i++)
            {
                field[i] = Enumerable.Repeat(" ", width).ToArray();
            }

            return field;
        }

        public string[][] GetProcessedField(FieldCell[][] field, GameStatus status)
        {
            var fieldView = new string[field.Length][];

            for (var i = 0; i < field.Length; i++)
            {
                fieldView[i] = field[i].Select(MapToCellValue).ToArray();
            }

            return fieldView;

            string MapToCellValue(FieldCell cell)
            {
                return status switch
                {
                    GameStatus.InProgress when !cell.Opened => " ",
                    GameStatus.Failed when cell.IsMine => "X",
                    GameStatus.Successful when cell.IsMine => "M",
                    _ => cell.Counter.ToString(),
                };
            }
        }
    }
}
