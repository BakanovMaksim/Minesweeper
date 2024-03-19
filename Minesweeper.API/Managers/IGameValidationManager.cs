using Minesweeper.Core.Models;

namespace Minesweeper.API.Managers
{
    public interface IGameValidationManager
    {
        IGameValidationManager ValidateFieldWidth(int width);

        IGameValidationManager ValidateFieldHeight(int height);

        IGameValidationManager ValidateFieldMinesCount(int minesCount, int width, int height);

        IGameValidationManager ValidateGameFieldExisted(Guid gameId, FieldCell[][]? field);

        IGameValidationManager ValidateGameFieldCellExisted(FieldCell? cell);

        IGameValidationManager ValidateGameFieldCellOpened(FieldCell cell);
    }
}
