# https://atcoder.jp/contests/tessoku-book/submissions/35054519
s = list(input())
t = list(input())
lens = len(s) + 1
lent = len(t) + 1
dp = [[0] * lent for _ in range(lens)] 
for i in range(lens):
    dp[i][0] = i
for i in range(lent):
    dp[0][i] = i
for i in range(1,lens):
    for j in range(1,lent):
        dp[i][j] = min(dp[i-1][j]+1,dp[i][j-1]+1,dp[i-1][j-1] + (0 if s[i-1] == t[j-1] else 1))
print(dp[-1][-1])
