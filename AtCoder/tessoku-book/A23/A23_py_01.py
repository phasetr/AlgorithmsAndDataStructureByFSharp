# https://atcoder.jp/contests/tessoku-book/submissions/35591034
n,m = map(int,input().split())
inf = float('inf')
dp = [inf]*(1<<n)
dp[0] = 0

for _ in range(m):
    a = int(''.join(input().split()),2)
    for bit in range(1<<n):
        dp[bit|a] = min(dp[bit|a], dp[bit]+1)
print(-1 if dp[-1] == inf else dp[-1])
