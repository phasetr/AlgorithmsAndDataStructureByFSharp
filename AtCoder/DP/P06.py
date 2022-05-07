# https://atcoder.jp/contests/dp/submissions/29806810
from collections import defaultdict
import sys
sys.setrecursionlimit(2*10**5)

MOD = 10**9+7

def solve(N,tree):
    dp = [[1] * N for _ in range(2)]

    def dfs(v, p):
        for nv in tree[v]:
            if nv == p:
                continue
            dfs(nv, v)
            dp[0][v] *= dp[1][nv]  # 黒
            dp[1][v] *= (dp[0][nv] + dp[1][nv])  # 白
            dp[0][v] %= MOD
            dp[1][v] %= MOD

    dfs(0, -1)
    return (dp[0][0] + dp[1][0]) % MOD


def main():
    N = int(input())
    tree = defaultdict(list)
    for _ in range(N-1):
        a, b = map(lambda x:int(x)-1, input().split())
        tree[a].append(b)
        tree[b].append(a)
    print(solve(N,tree))
main()
#print(solve(N,tree))
