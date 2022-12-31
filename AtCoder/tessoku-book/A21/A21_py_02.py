# https://atcoder.jp/contests/tessoku-book/submissions/34868579
n = int(input())
P,A = zip(*(map(int,input().split()) for _ in range(n)))
dp = [[0]*(n+1) for _ in range(n+1)]
for r in range(n+1)[::-1]:
  for l in range(r):
    dp[l+1][r] = max(dp[l+1][r],dp[l][r]+A[l]*(l<=P[l]-1<r))
    dp[l][r-1] = max(dp[l][r-1],dp[l][r]+A[r-1]*(l<=P[r-1]-1<r))
ans = max(dp[i][i] for i in range(n+1))
print(ans)
