/*************************************************************************

   Copyright (C) 2018. dc-koromo. All Rights Reserved.

   Author: Koromo Hitomi Copy Developer

***************************************************************************/

using System;

namespace Hitomi_Copy_4.Utils
{
    public class StringAlgorithms
    {
        public static int get_diff(string a, string b)
        {
            int x = a.Length;
            int y = b.Length;
            int i, j;

            if (x == 0) return x;
            if (y == 0) return y;
            int[] v0 = new int[(y + 1) << 1];

            for (i = 0; i < y + 1; i++) v0[i] = i;
            for (i = 0; i < x; i++)
            {
                v0[y + 1] = i + 1;
                for (j = 0; j < y; j++)
                    v0[y + j + 2] = Math.Min(Math.Min(v0[y + j + 1], v0[j + 1]) + 1, v0[j] + ((a[i] == b[j]) ? 0 : 1));
                for (j = 0; j < y + 1; j++) v0[j] = v0[y + j + 1];
            }
            return v0[y + y + 1];
        }

        public static int[] get_diff_array(string src, string tar)
        {
            int[,] dist = new int[src.Length + 1, tar.Length + 1];
            for (int i = 1; i <= src.Length; i++) dist[i, 0] = i;
            for (int j = 1; j <= tar.Length; j++) dist[0, j] = j;

            for (int j = 1; j <= tar.Length; j++)
            {
                for (int i = 1; i <= src.Length; i++)
                {
                    if (src[i - 1] == tar[j - 1]) dist[i, j] = dist[i - 1, j - 1];
                    else dist[i, j] = Math.Min(dist[i - 1, j - 1] + 1, Math.Min(dist[i, j - 1] + 1, dist[i - 1, j] + 1));
                }
            }

            int[] route = new int[src.Length + 1];
            int fz = dist[src.Length, tar.Length];
            for (int i = src.Length, j = tar.Length; i >= 0 && j >= 0;)
            {
                int lu = int.MaxValue;
                int u = int.MaxValue;
                int l = int.MaxValue;
                if (i - 1 >= 0 && j - 1 >= 0) lu = dist[i - 1, j - 1];
                if (i - 1 >= 0) u = dist[i - 1, j];
                if (j - 1 >= 0) l = dist[i, j - 1];
                int min = Math.Min(lu, Math.Min(l, u));
                if (min == fz) route[i] = 1;
                if (min == lu)
                {
                    i--; j--;
                }
                else if (min == u) i--;
                else j--;
                fz = min;
            }
            return route;
        }
    }
}
