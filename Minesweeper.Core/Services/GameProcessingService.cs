using Minesweeper.Core.Models;

namespace Minesweeper.Core.Services
{
    public class GameProcessingService : IGameProcessingService
    {
        public void OpenCell(
            FieldCell[][] field,
            int row,
            int col,
            int width,
            int height)
        {
            if (row < 0 || col < 0 || col >= width || row >= height)
            {
                return;
            }

            var cell = field[row][col];

            if (cell.Opened)
            {
                return;
            }

            cell.Opened = true;

            if (cell.Counter > 0)
            {
                return;
            }

            OpenCell(field, row - 1, col - 1, width, height);
            OpenCell(field, row, col - 1, width, height);
            OpenCell(field, row + 1, col - 1, width, height);
            OpenCell(field, row - 1, col, width, height);
            OpenCell(field, row + 1, col, width, height);
            OpenCell(field, row - 1, col + 1, width, height);
            OpenCell(field, row, col + 1, width, height);
            OpenCell(field, row + 1, col + 1, width, height);
        }

        public GameStatus GetGameStatus(
            FieldCell cell,
            FieldCell[][] field,
            int width,
            int height,
            int minesCount)
        {
            var cellWithoutMinesCount = (width * height) - minesCount;
            var openedCellsCount = field
                .Select(r => r.Where(c => c.Opened).Count())
                .Sum();

            return cell.IsMine
                ? GameStatus.Failed
                : (cellWithoutMinesCount == openedCellsCount
                    ? GameStatus.Successful
                    : GameStatus.InProgress);
        }
    }
}
