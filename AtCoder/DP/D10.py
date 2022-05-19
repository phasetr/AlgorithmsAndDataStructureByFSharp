# https://atcoder.jp/contests/dp/submissions/31739320
N, W = map(int, input().split())
w, v = map(list, zip(*[map(int, input().split()) for _ in range(N)]))
dp = [[0]*(W+1) for _ in range(N)]
dp[0] = [0 if w[0] > i else v[0] for i in range(W+1)]
for i in range(1, N):
    for j in range(1, W+1):
        if j >= w[i]:
            dp[i][j] = max(dp[i-1][j], dp[i-1][j-w[i]]+v[i])
        else:
            dp[i][j] = dp[i-1][j]
print(dp[-1][-1])
