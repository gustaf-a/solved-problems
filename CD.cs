using System;
using System.Collections.Generic;

namespace KattisSolutions
{
    // https://open.kattis.com/problems/cd

    class CDEqualityComparer : IEqualityComparer<int>
    {
        public bool Equals(int cd1, int cd2)
        {
            if (cd1 == cd2)
                return true;
            else
                return false;
        }

        public int GetHashCode(int cd)
        {
            return cd;
        }
    }

    class CD
    {

        static void Main()
        {
            bool moreCases= true;
            while (moreCases)
            {
                string[] line1Arr = Console.ReadLine().Split(' ');
                int N = Int32.Parse(line1Arr[0]);
                int M = Int32.Parse(line1Arr[1]);

                if (N==0 && M==0)
                {
                    moreCases = false;
                    break;
                }
                int sell = HowManyCDsToSell(N, M);
                Console.WriteLine(sell.ToString());
                line1Arr = null;
            }
        }

        private static int HowManyCDsToSell(int N, int M)
        {
            int cdsToSellCounter = 0;
            CDEqualityComparer cdEqC = new CDEqualityComparer();
            HashSet<int> jackCD = new HashSet<int>(cdEqC);
            for (int i = 0; i < N; i++)
            {
                jackCD.Add(Int32.Parse(Console.ReadLine()));
            }
            for (int i = 0; i < M; i++)
            {
                int cd = Int32.Parse(Console.ReadLine());
                if (jackCD.Contains(cd))
                {
                    cdsToSellCounter++;
                }
            }
            return cdsToSellCounter;
        }
    }
}
