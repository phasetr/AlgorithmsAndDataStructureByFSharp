# https://atcoder.jp/contests/dp/submissions/31121008
import sys
sys.setrecursionlimit(10**6)
input = sys.stdin.readline

n, m = map(int, input().split())
g = [[] for _ in range(n)]
for i in range(m):
    x, y = map(int, input().split())
    x -= 1
    y -= 1
    g[x].append(y)

def rec(v):
    if dp[v] != -1:
        return dp[v]
    res = 0
    for nv in g[v]:
        res = max(res, rec(nv) +1)

    dp[v] = res
    return dp[v]

dp = [-1]*n
res = 0
for i in range(n):
    res = max(res, rec(i))
print(res)
