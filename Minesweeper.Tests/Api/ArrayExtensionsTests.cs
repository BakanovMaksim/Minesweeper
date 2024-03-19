using Minesweeper.API.Infrastructure;

namespace Minesweeper.Tests.Api
{
    public class ArrayExtensionsTests
    {
        [Fact(DisplayName = "Проверка возвращения дефолтного значения")]
        public void GetValueOrDefaultCheckDefaultTest()
        {
            var source = new string[2][]
            {
                new string[]{ string.Empty, string.Empty, string.Empty, string.Empty },
                new string[]{ string.Empty, "Success", string.Empty, string.Empty }
            };

            var actual = source.GetValueOrDefault(5, 5);

            Assert.Null(actual);
        }

        [Fact(DisplayName = "Проверка возвращения значения")]
        public void GetValueOrDefaultCheckValueTest()
        {
            var source = new string[2][]
            {
                new string[]{ string.Empty, string.Empty, string.Empty, string.Empty },
                new string[]{ "Success", string.Empty, string.Empty, string.Empty }
            };

            var expected = "Success";
            var actual = source.GetValueOrDefault(1, 0);

            Assert.Equal(expected, actual);
        }
    }
}
