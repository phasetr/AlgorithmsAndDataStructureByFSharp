# https://atcoder.jp/contests/dp/submissions/31324480
n = int(input())
A = [[*map(int, input().split())] for _ in range(n)]
m = 1 << n
dp = [0] * m
cost = [0] * m

for s in range(m):
    for i in range(n):
        for j in range(i):
            if (s>>i & 1) and (s>>j & 1):
                cost[s] += A[i][j]

for s in range(m):
    u = s
    while u:
        dp[s] = max(dp[s],dp[s-u] + cost[u])
        u = (u-1)&s
print(dp[m-1])
