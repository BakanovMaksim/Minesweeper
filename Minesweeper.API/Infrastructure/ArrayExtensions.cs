namespace Minesweeper.API.Infrastructure
{
    public static class ArrayExtensions
    {
        public static T? GetValueOrDefault<T>(this T[][] source, int row, int col) where T : class
        {
            if (source == null || source.Length <= row)
            {
                return default;
            }

            var subArray = source[row];

            return subArray == null || subArray.Length <= col
                ? default
                : subArray[col];
        }
    }
}
