using TestsDemo.Helpers;
using Xunit;

namespace UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void TestThatPasses()
        {
            int number1 = 0;
            int number2 = 100;

            int result = MathHelpers.Multiply(number1, number2);
            Assert.Equal(0, result);
        }

        [Fact]
        public void TestThatFail()
        {
            //Assert.Equal(1, 0);
        }
    }
}