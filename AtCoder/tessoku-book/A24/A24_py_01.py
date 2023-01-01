# https://atcoder.jp/contests/tessoku-book/submissions/35811469
from bisect import bisect_left

N = int(input())
A = [int(x) for x in input().split()]

INF = 1000000000000000000
L = [INF] * (N + 1)

ans = 0
for a in A:
    pos = bisect_left(L, a)
    L[pos] = a
    ans = max(pos + 1, ans)
print(ans)
