using System;
using System.Collections.Generic;
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

            var i = 0;
            var processedInput = height.Select(val =>
            {
                var item = (index: i, value: val);
                i++;
                return item;
            }).ToArray();
            var firstDivider = GetDivider(processedInput, true);
            var leftPart = DivideAndConquer(processedInput.Take(firstDivider.index + 1), firstDivider, false);
            var rightPart = DivideAndConquer(processedInput.Skip(firstDivider.index), firstDivider, true);



            int DivideAndConquer(IEnumerable<(int index, int value)> input, (int index, int value) divider, bool goRight)
            {
                var inputCount = input.Count();
                if (inputCount < 3) return 0;

                var pocketInThisRun = 0;

                if (goRight)
                {
                    var newDivider = GetDivider(input.Skip(1), goRight);

                    pocketInThisRun = CountDrop(input.Take(newDivider.index - divider.index + 1));

                    var lastItemIndex = input.Last().index;

                    return pocketInThisRun + DivideAndConquer(input.TakeLast(lastItemIndex - newDivider.index + 1),
                               newDivider, goRight);
                }
                else
                {
                    var newDivider = GetDivider(input.SkipLast(1), goRight);

                    pocketInThisRun = CountDrop(input.TakeLast(divider.index - newDivider.index + 1));

                    var firstItemIndex = input.First().index;
                    return pocketInThisRun + DivideAndConquer(input.Take(newDivider.index - firstItemIndex + 1),
                               newDivider, goRight);
                }
            }

            (int index, int value) GetDivider(IEnumerable<(int index, int value)> input, bool goRight)
            {
                if (goRight)
                {
                    //We want the get the highest value that is furthest to the right
                    return input.Aggregate((previousValue, currentValue) =>
                        (previousValue.value > currentValue.value) ? previousValue : currentValue);
                }

                return input.Aggregate((previousValue, currentValue) =>
                    (currentValue.value > previousValue.value) ? currentValue : previousValue);
            }

            int CountDrop(IEnumerable<(int index, int value)> input)
            {
                var count = input.Count();
                if (count < 3) return 0;
                var dirtCount = input.Skip(1).Take(count - 2)
                    .Aggregate(0, (dirt, currentGround) => dirt + currentGround.value);
                var first = input.First();
                var last = input.Last();
                var x = last.index - first.index - 1;
                var y = Math.Min(first.value, last.value);
                return x * y - dirtCount;
            }

            return leftPart + rightPart;
        }
    }
}