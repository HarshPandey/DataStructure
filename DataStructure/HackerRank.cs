using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DataStructure
{
    // This class contains all the problems solved given at GFG
    public class HackerRank
    {
        #region Find the running median

        #region Approach 1 this works for smaller values less than 100

        private static float GetMedianValue(int[] array)
        {
            Array.Sort(array);

            float medianValue;
            int length = array.Length;
            int half = length / 2;

            if (length % 2 == 0)
            {
                medianValue = (float)(array[half - 1] + array[half]) / 2;
            }
            else
            {
                medianValue = array[half];
            }
            return Convert.ToSingle(medianValue);
        }

        public static void InputReader1()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] a = new int[n];
            for (int a_i = 0; a_i < n; a_i++)
            {
                a[a_i] = Convert.ToInt32(Console.ReadLine());
                int[] temp = new int[a_i + 1];
                Array.Copy(a, 0, temp, 0, a_i + 1);
                float value = GetMedianValue(temp);
                Console.WriteLine(string.Format("{0:0.0}", value));
            }
        }

        #endregion

        #region Approach 2 this works for 10^5 values and uses Heaps

        public static void InputReader2()
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int[] a = new int[n];

            for (int i = 0; i < n; i++)
            {
                int aItem = Convert.ToInt32(Console.ReadLine());
                a[i] = aItem;
            }
        }


        #endregion


        #endregion
    }
}
