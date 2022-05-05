// https://atcoder.jp/contests/dp/submissions/9589090
using System;
using System.Linq;

var n = int.Parse(Console.ReadLine());
var a = new int[n].Select(_ => Console.ReadLine().Split().Select(s => s == "1").ToArray()).ToArray();
var p2 = Enumerable.Range(0, n + 1).Select(i => 1 << i).ToArray();
// var p2 = Enumerable.Range(0, 10 + 1).Select(i => 1 << i).ToArray();
// => int[11] { 1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024 }

var dp = new int[n + 1, p2[n]];
dp[0, 0] = 1;
for (int i = 0, i2 = 1; i < n; i++, i2++)
	for (int f = 0, f2; f < p2[n]; f++)
	{
		if (dp[i, f] == 0) continue;
		for (int j = 0; j < n; j++)
		{
			if (!a[i][j]) continue;
			if ((f2 = f | p2[j]) == f) continue;
			dp[i2, f2] = (dp[i2, f2] + dp[i, f]) % 1000000007;
		}
	}
Console.WriteLine(dp[n, p2[n] - 1]);
