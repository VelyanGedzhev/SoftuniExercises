using System;
using Wintellect.PowerCollections;

namespace _04.CookiesProblem
{
    public class CookiesProblem
    {
        public int Solve(int k, int[] cookies)
        {
            var bag = new OrderedBag<int>();

            foreach (var cookie in cookies)
            {
                bag.Add(cookie);
            }

            int currentMinSweetness = bag.GetFirst();
            int counter = 0;

            while (currentMinSweetness < k
                && bag.Count > 1)
            {
                int leastSweetCookie = bag.RemoveFirst();
                int secondLeastSweetCookie = bag.RemoveFirst();

                int combinedCookie = leastSweetCookie + 2 * secondLeastSweetCookie;

                bag.Add(combinedCookie);

                currentMinSweetness = bag.GetFirst();
                counter++;
            }

            return currentMinSweetness < k ? -1 : counter;
        }
    }
}
