using LeetCode.Lib;
using System.Linq;
using Xunit;

namespace LeetCode.Test
{
    public class TrappingRainWaterTest
    {
        public static TheoryData<int[], int> TestData { get; } =
            new TheoryData<int[], int>
            {
                {Enumerable.Empty<int>().ToArray(),0 },
                {new[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 }, 6 },
                {new[] { 2, 1, 0, 2 }, 3 },
                {new []{ 5, 2, 1, 2, 1, 5 ,1}, 14 },
                {new []{ 10527, 740, 9013, 1300, 29680, 4898, 13993, 15213, 18182, 24254, 3966, 24378, 11522, 9190, 6389, 32067, 21464, 7115, 7760, 3925 } ,2222}
            };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[] terrain, int expectedDrops)
        {
            var drops = TrappingRainWater.Trap(terrain);
            Assert.Equal(expectedDrops, drops);
        }
    }
}