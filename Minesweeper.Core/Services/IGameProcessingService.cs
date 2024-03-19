using Minesweeper.Core.Models;

namespace Minesweeper.Core.Services
{
    public interface IGameProcessingService
    {
        void OpenCell(
            FieldCell[][] field,
            int row,
            int col,
            int width,
            int height);

        GameStatus GetGameStatus(
            FieldCell cell,
            FieldCell[][] field,
            int width,
            int height,
            int minesCount);
    }
}
