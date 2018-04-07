namespace LeetCode.Lib
{
    public class GetExcelHeader
    {
        public static string ConvertToTitle(int n)
        {
            var fullNum = n;
            var result = "";
            var drag = 1;
            while (fullNum > 0)
            {
                var remainder = (fullNum) % 27;
                result = (char)(remainder + 65) + result;
                fullNum /= 27;
            }

            return result;
        }
    }
}