namespace Minesweeper.API.Infrastructure
{
    public class MinesweeperApplicationException : Exception
    {
        public MinesweeperApplicationException() : base()
        {

        }

        public MinesweeperApplicationException(string? message) : base(message)
        {

        }

        public MinesweeperApplicationException(string? message, Exception? innerException = null) : base(message, innerException)
        {

        }
    }
}
