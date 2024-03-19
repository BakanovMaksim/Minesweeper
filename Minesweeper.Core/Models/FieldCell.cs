namespace Minesweeper.Core.Models
{
    public class FieldCell
    {
        public int Counter { get; set; }

        public bool IsMine { get; set; }

        public bool Opened { get; set; }
    }
}
