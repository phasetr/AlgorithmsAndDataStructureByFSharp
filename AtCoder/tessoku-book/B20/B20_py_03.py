# https://atcoder.jp/contests/tessoku-book/submissions/38128899
S = input()
T = input()

dp = [[0 for i in range(0,len(S)+1)] for j in range(0,len(T)+1)]

for i in range(0,len(T)+1):
    for j in range(0,len(S)+1):
        if i == 0:
            dp[i][j] = j
        elif j == 0:
            dp[i][j] =i
        elif T[i-1] == S[j-1]:
            dp[i][j] = min(dp[i-1][j]+1,dp[i][j-1]+1,dp[i-1][j-1])
        else:
            dp[i][j] = min(dp[i-1][j]+1,dp[i][j-1]+1,dp[i-1][j-1]+1)

print(dp[len(T)][len(S)])
