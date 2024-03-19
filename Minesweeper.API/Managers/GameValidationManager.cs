using Minesweeper.API.Infrastructure;
using Minesweeper.Core.Models;

namespace Minesweeper.API.Managers
{
    public class GameValidationManager : IGameValidationManager
    {
        public IGameValidationManager ValidateFieldWidth(int width)
        {
            const int minWidth = 2;
            const int maxWidth = 30;

            if (width < minWidth || width > maxWidth)
            {
                throw new MinesweeperApplicationException(
                    $"Ширина={width} не попадает в допустимый интервал от {minWidth} до {maxWidth}.");
            }

            return this;
        }

        public IGameValidationManager ValidateFieldHeight(int height)
        {
            const int minHeight = 2;
            const int maxHeight = 30;

            if (height < minHeight || height > maxHeight)
            {
                throw new MinesweeperApplicationException(
                    $"Высота={height} не попадает в допустимый интервал от {minHeight} до {maxHeight}.");
            }

            return this;
        }

        public IGameValidationManager ValidateFieldMinesCount(int minesCount, int width, int height)
        {
            const int minMinesCount = 1;
            var maxMinesCount = width * height - 1;

            if (minesCount < minMinesCount || minesCount > maxMinesCount)
            {
                throw new MinesweeperApplicationException(
                    $"Количество мин={minesCount} не попадает в допустимый интервал от {minMinesCount} до {maxMinesCount}.");
            }

            return this;
        }

        public IGameValidationManager ValidateGameFieldExisted(Guid gameId, FieldCell[][]? field)
        {
            if (field == null)
            {
                throw new MinesweeperApplicationException(
                    $"Игра с идентификатором {gameId} не была создана или устарела (неактуальна).");
            }

            return this;
        }

        public IGameValidationManager ValidateGameFieldCellExisted(FieldCell? cell)
        {
            if (cell == null)
            {
                throw new MinesweeperApplicationException("Клетка игрового поля не найдена.");
            }

            return this;
        }

        public IGameValidationManager ValidateGameFieldCellOpened(FieldCell cell)
        {
            if (cell.Opened)
            {
                throw new MinesweeperApplicationException("Клетка игрового поля уже открыта.");
            }

            return this;
        }
    }
}
