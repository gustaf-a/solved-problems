using System;
using System.Collections.Generic;

namespace KattisSolutions
{
    //https://open.kattis.com/problems/areyoulistening

    public class AreYouListening
    {
        /// <summary>
        /// Calculates the biggest allowed radius without overlapping with more than 2 other devices
        /// Performance 0.02s
        /// Best submissions: 0.02s
        /// </summary>
        public static void Main()
        {
            string[] line = Console.ReadLine().Split(' ');

            var myDeviceX = int.Parse(line[0]);
            var myDeviceY = int.Parse(line[1]);
            var n = int.Parse(line[2]);

            var enemyDevices = new string[n];

            for (int i = 0; i < n; i++)
                enemyDevices[i] = Console.ReadLine();

            Console.WriteLine(AreYouListeningSolveCase(myDeviceX, myDeviceY, enemyDevices, ref n));
        }

        /// <summary>
        /// Case is solved separately from read-write to allow for unit tests.
        /// </summary>
        public static int AreYouListeningSolveCase(int myDeviceX, int myDeviceY, string[] enemyDevices, ref int n)
        {
            int[] distanceToEnemyDevices = new int[n];

            var threeClosestEnemyDevices = new List<int>();

            for (int i = 0; i < n; i++)
            {
                distanceToEnemyDevices[i] = ProcessEnemyDevice(enemyDevices[i], myDeviceX, myDeviceY);

                if (i < 2)
                    threeClosestEnemyDevices.Add(distanceToEnemyDevices[i]);
                else if (i == 2)
                {
                    threeClosestEnemyDevices.Add(distanceToEnemyDevices[2]);

                    threeClosestEnemyDevices.Sort();
                }
                else
                {
                    if (threeClosestEnemyDevices[2] > distanceToEnemyDevices[i])
                    {
                        threeClosestEnemyDevices[2] = distanceToEnemyDevices[i];

                        threeClosestEnemyDevices.Sort();
                    }
                }
            }

            return threeClosestEnemyDevices[2];
        }

        private static int ProcessEnemyDevice(string enemyDeviceLine, int myDeviceX, int myDeviceY)
        {
            string[] line = enemyDeviceLine.Split(' ');

            return CalculateDistanceToEnemy(myDeviceX, myDeviceY, int.Parse(line[0]), int.Parse(line[1]), int.Parse(line[2]));
        }

        private static int CalculateDistanceToEnemy(int myDeviceX, int myDeviceY, int enemyX, int enemyY, int enemyR)
        {
            var distanceCenters = Math.Sqrt((enemyX - myDeviceX) * (enemyX - myDeviceX) + (enemyY - myDeviceY) * (enemyY - myDeviceY));

            if (distanceCenters < enemyR)
                return 0;

            return (int)Math.Floor(distanceCenters - enemyR);
        }
    }
}
