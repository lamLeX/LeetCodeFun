using System.Linq;

namespace LeetCode.Lib
{
    public class TrappingRainWater
    {
        public static int Trap(int[] height)
        {
            if (!height.Any()) return 0;

            var maxHeight = height.Max();
            var waterDrops = 0;
            for (int layer = maxHeight; layer > 0; layer--)
            {
                var currentOpenHole = 0;
                var holeStarted = false;
                foreach (var stack in height)
                {
                    if (stack < layer)
                    {
                        //wall is not high enough for this layer
                        if (!holeStarted) continue;

                        currentOpenHole++;
                    }
                    else
                    {
                        //if hole is not open, open it; otherwise, close and add water to pool
                        if (!holeStarted)
                        {
                            holeStarted = true;
                        }
                        else
                        {
                            if (currentOpenHole == 0)
                            {
                                continue;
                            }

                            waterDrops += currentOpenHole;
                            currentOpenHole = 0;
                        }
                    }
                }
            }

            return waterDrops;
        }

        public static int NewTrap(int[] height)
        {
            if (!height.Any()) return 0;
            var waterDrops = 0;
            var highest = 0;

            for (int i = 0; i < height.Length - 2; i++)
            {
                var currentColumn = height[i];

                if (currentColumn > highest) highest = currentColumn;

            }

            return waterDrops;
        }
    }
}