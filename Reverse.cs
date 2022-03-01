using System;
using System.Text;

namespace KattisSolutions
{
    //https://open.kattis.com/problems/ofugsnuid
    public class Reverse
    {
        ///<summary>
        ///Recursive stringbuilder solution
        ///Performance 0.06s. 
        ///Best solution anyone submitted: 0.05s
        /// </summary>
        public static void Main()
        {
            var sb = new StringBuilder();

            PrintReverse(int.Parse(Console.ReadLine()), sb);

            Console.Write(sb.ToString());
        }

        private static void PrintReverse(int linesToRead, StringBuilder sb)
        {
            var number = Console.ReadLine();

            if (linesToRead > 1)
                PrintReverse(linesToRead - 1, sb);

            sb.Append(number);
            sb.AppendLine();
        }

        ///<summary>
        ///Array-based solution
        ///Performance 0.21s. 
        ///</summary>

        //public static void Main()
        //{
        //    var n = int.Parse(Console.ReadLine());

        //    if (n == 1)
        //    {
        //        Console.WriteLine(Console.ReadLine());

        //        return;
        //    }

        //    var array = new string[n-1];

        //    for (int i = 0; i < n-1; i++)
        //        array[i] = Console.ReadLine();

        //    Console.WriteLine(Console.ReadLine());

        //    for (int i = n-1; i > 0; i--)
        //        Console.WriteLine(array[i-1]);
        //}
    }
}
