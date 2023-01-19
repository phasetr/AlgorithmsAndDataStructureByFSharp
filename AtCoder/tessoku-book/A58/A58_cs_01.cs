// https://atcoder.jp/contests/tessoku-book/submissions/37942198
using System;


internal class Program
{
    struct Query
    {
        public int q;
        public int pl;
        public int xr;
    }

    private static void Main(string[] args)
    {
        string[] strs = Console.ReadLine().Split(' ');
        int n = int.Parse(strs[0]);
        int q = int.Parse(strs[1]);

        Query[] qs = new Query[q];

        for (int i = 0; i < q; i++)
        {
            strs = Console.ReadLine().Split(' ');
            qs[i].q = int.Parse(strs[0]);
            qs[i].pl = int.Parse(strs[1]);
            qs[i].xr = int.Parse(strs[2]);
        }

        int siz = 1;
        while(siz < n)
        {
            siz *= 2;
        }

        int[] st = new int[siz * 2];
        for(int i = 0; i < st.Length; i++)
        {
            st[i] = 0;
        }


        for (int i = 0; i < q; i++)
        {
            if (qs[i].q == 1)
            {
                ReplaceNumber(st, qs[i].pl, qs[i].xr);
            }
            else
            {
                Console.WriteLine(RangeMaximum(st, qs[i].pl, qs[i].xr));
            }
        }
    }

    private static void ReplaceNumber(int[] st, int pos, int x)
    {
        int i = st.Length / 2 + pos - 1;
        st[i] = x;

        while (i > 1)
        {
            i /= 2;
            st[i] = Math.Max(st[2 * i], st[2 * i + 1]);
        }
    }

    private static int RangeMaximum(int[] st, int l, int r)
    {
        return RangeMax(st, l, r, 1, st.Length / 2 + 1, 1);
    }

    private static int RangeMax(int[] st, int l, int r, int a, int b, int i)
    {
        if(l <= a && b <= r)
        {
            return st[i];
        }
        else if(b <= l || r <= a)
        {
            return 0;
        }

        int m = (a + b) / 2;

        int am = RangeMax(st, l, r, a, m, i * 2);
        int mb = RangeMax(st, l, r, m, b, i * 2 + 1);

        return Math.Max(am, mb);
    }
}
