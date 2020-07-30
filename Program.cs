using System;
using System.Collections.Generic;

namespace Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            FirstNonRecurring("BBCABA");
            LongestConsecutiveChar("AABCDDBBBEA");
            int[,] M = { { -3, -2, -1, 1 },
                      { -2, 2, 3, 4 },
                      { 4, 5, 7, 8 } };
            NegativeCountMatrix(M, 3, 4);
        }

        private static int FirstNonRecurring(string test)
        {
            char[] count = new char[256];
            for (int i = 0; i < test.Length; i++)
            {
                count[test[i]]++;
            }

            int index = -1;
            for (int i = 0; i < test.Length; i++)
            {
                if (count[test[i]] == 1)
                {
                    index = i;
                    break;
                }
            }
            var x = test[index];
            return x;
        }

        private static Dictionary<char, int> LongestConsecutiveChar(string test)
        {
            int max_count = 0;
            char max_char = '\0';
            char prev_char = '\0';
            int count = 0;

            foreach (char current in test)
            {
                if (current == prev_char)
                {
                    count++;
                }
                else
                {
                    count = 1;
                }
                if (count > max_count)
                {
                    max_count = count;
                    max_char = current;
                }
                prev_char = current;
            }
            return new Dictionary<char, int>
            {
                { max_char, max_count }
            };
        }

        private static int NegativeCountMatrix(int[,] M, int n, int m)
        {
            int i = 0;
            int j = m - 1;
            int count = 0;
            
            while (j >= 0 && i < n)
            {
                if (M[i,j] < 0)
                {
                    count += j + 1;
                    i++;
                }
                else
                {
                    j -= 1;
                }
            }
            return count;
        }
    }
}
