# https://atcoder.jp/contests/dp/submissions/30332368
from itertools import accumulate

MOD = 10**9+7
N = int(input())
S = 'aa'+input()

dp = [[0]*(N+1) for _ in range(N+1)]
dp[1][1] = 1

for i in range(2,N+1):
    sums = list(accumulate(dp[i-1]))
    for j in range(1,i+1):
        if S[i]=='<':
            dp[i][j] += sums[j-1]
            dp[i][j] %= MOD
        else:
            dp[i][j] += sums[-1]-sums[j-1]
            dp[i][j] %= MOD

print(sum(dp[N])%MOD)

