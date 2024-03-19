using Minesweeper.Core.Models;

namespace Minesweeper.Core.Services
{
    public interface IGameDrawingService
    {
        string[][] GetNewField(int width, int height);

        string[][] GetProcessedField(FieldCell[][] field, GameStatus status);
    }
}
