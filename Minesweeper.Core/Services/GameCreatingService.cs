using Minesweeper.Core.Models;

namespace Minesweeper.Core.Services
{
    public class GameCreatingService : IGameCreatingService
    {
        private const int maxFails = 100;

        private int width;
        private int height;
        private int minesCount;

        public FieldCell[][] GetNewField(int width, int height, int minesCount)
        {
            this.width = width;
            this.height = height;
            this.minesCount = minesCount;

            var field = new FieldCell[height][];

            GenerateEmptyField(field);
            GenerateMines(field);
            GenerateMinesCounter(field);

            return field;
        }

        private void GenerateEmptyField(FieldCell[][] field)
        {
            for (var i = 0; i < height; i++)
            {
                field[i] = new FieldCell[width];

                for (var j = 0; j < width; j++)
                {
                    field[i][j] = new FieldCell();
                }
            }
        }

        private void GenerateMines(FieldCell[][] field)
        {
            var fails = 0;
            var setMinesCount = 0;
            var rnd = new Random();

            while (setMinesCount < minesCount && fails < maxFails)
            {
                var row = rnd.Next(0, height);
                var column = rnd.Next(0, width);

                if (field[row][column].IsMine)
                {
                    fails++;
                    continue;
                }

                field[row][column].IsMine = true;

                setMinesCount++;
            }

            if (fails == maxFails)
            {
                throw new Exception("Incorrect generate mines.");
            }
        }

        private void GenerateMinesCounter(FieldCell[][] field)
        {
            for (var i = 0; i < height; i++)
            {
                for (var j = 0; j < width; j++)
                {
                    if (field[i][j].IsMine)
                    {
                        if (i > 0 && !field[i - 1][j].IsMine)
                        {
                            field[i - 1][j].Counter += 1;
                        }

                        if (i < height - 1 && !field[i + 1][j].IsMine)
                        {
                            field[i + 1][j].Counter += 1;
                        }

                        if (j > 0 && !field[i][j - 1].IsMine)
                        {
                            field[i][j - 1].Counter += 1;
                        }

                        if (j < width - 1 && !field[i][j + 1].IsMine)
                        {
                            field[i][j + 1].Counter += 1;
                        }

                        if (i > 0 && j > 0 && !field[i - 1][j - 1].IsMine)
                        {
                            field[i - 1][j - 1].Counter += 1;
                        }

                        if (i < height - 1 && j < width - 1 && !field[i + 1][j + 1].IsMine)
                        {
                            field[i + 1][j + 1].Counter += 1;
                        }

                        if (i < height - 1 && j > 0 && !field[i + 1][j - 1].IsMine)
                        {
                            field[i + 1][j - 1].Counter += 1;
                        }

                        if (i > 0 && j < width - 1 && !field[i - 1][j + 1].IsMine)
                        {
                            field[i - 1][j + 1].Counter += 1;
                        }
                    }
                }
            }
        }
    }
}
