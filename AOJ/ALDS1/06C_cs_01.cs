// https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_6_C/review/3373327/Kaz_nl/C%23
using System;
using System.Linq;

class Program {
    struct Card {
        public string Key;
        public int Value;
    }

    static int Partition(Card[] a, int p, int r) {
        int x = a[r].Value;
        int i = p - 1;
        for (int j = p; j < r; j++) {
            if (a[j].Value <= x) {
                Swap(ref a[++i], ref a[j]);
            }
        }
        Swap(ref a[i + 1], ref a[r]);
        return i + 1;
    }

    static void Swap<T>(ref T lhs, ref T rhs) {
        T temp = lhs;
        lhs = rhs;
        rhs = temp;
    }

    static void QuickSort(Card[] a, int p, int r) {
        if (p < r) {
            int q = Partition(a, p, r);
            QuickSort(a, p, q - 1);
            QuickSort(a, q + 1, r);
        }
    }

    static void Main() {
        var n = int.Parse(Console.ReadLine());
        var cards = new Card[n];
        for (int i = 0; i < n; i++) {
            var s = Console.ReadLine().Split();
            cards[i].Key = s[0];
            cards[i].Value = int.Parse(s[1]);
        }
        var stbl = cards.OrderBy(x => x.Value).ToArray();
        QuickSort(cards, 0, n - 1);
        Console.WriteLine(cards.SequenceEqual(stbl) ? "Stable" : "Not stable");
        foreach (var card in cards) {
            Console.WriteLine("{0} {1}", card.Key, card.Value);
        }
    }
}
