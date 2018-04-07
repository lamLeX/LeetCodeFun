using System.Linq;
using LeetCode.Lib;
using Xunit;

namespace LeetCode.Test
{
    public class GetExcelHeaderTest
    {
        public static TheoryData<int, string> TestData { get; } =
            new TheoryData<int, string>
            {
                {1,"A" },
                {26,"Z" },
                {27,"AA" },

            };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int input, string headerName)
        {
            var actual = GetExcelHeader.ConvertToTitle(input);
            Assert.Equal(headerName, actual);
        }
    }
}