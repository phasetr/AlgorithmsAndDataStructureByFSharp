# https://atcoder.jp/contests/dp/submissions/31288436
from itertools import accumulate
n = int(input())
s = input()

mod = 10**9+7
dp = [1 for i in range(n)]
for i in range(n-1):
    if s[i] == "<":
        dp = list(accumulate(dp[:-1]))
    else:
        dp = dp[::-1]
        dp = list(accumulate(dp[:-1]))
        dp = dp[::-1]
print(dp[0]%mod)
