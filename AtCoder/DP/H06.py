# https://atcoder.jp/contests/dp/submissions/31452688
# 入力
h,w=map(int,input().split())
grid=[list(input()) for _ in range(h)]

dp=[[0]*w for _ in range(h)]
mod=10**9+7
# 初期条件
dp[0][0]=1

# 動的計画法
for i in range(h):
    for j in range(w):
        if i+1<h and grid[i+1][j]=='.':
            dp[i+1][j]+=dp[i][j]
            if dp[i+1][j]>=mod:
                dp[i+1][j]%=mod
        if j+1<w and grid[i][j+1]=='.':
            dp[i][j+1]+=dp[i][j]
            if dp[i][j+1]>=mod:
                dp[i][j+1]%=mod

print(dp[h-1][w-1])
