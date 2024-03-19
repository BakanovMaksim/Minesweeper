using Minesweeper.Core.Models;

namespace Minesweeper.Core.Services
{
    public interface IGameCreatingService
    {
        FieldCell[][] GetNewField(int width, int height, int minesCount);
    }
}
