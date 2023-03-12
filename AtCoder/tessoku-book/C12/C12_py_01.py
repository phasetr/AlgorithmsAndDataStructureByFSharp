# https://atcoder.jp/contests/tessoku-book/submissions/34995416
import sys; input = sys.stdin.readline
f = lambda:map(int,input().split())
N,M,K = f()
connect = [[0]*(N+1) for _ in range(N+1)]
for i in range(M):
    A,B = f()
    for a in range(1,A+1):
        for b in range(B,N+1):
            connect[a][b]+=1
INF=10**5
dp = [[-INF]*(N+1)for _ in range(K+1)]
dp[0][0]=0
for k in range(1,K+1):
    for i in range(1,N+1):
        for j in range(1,i+1):
            dp[k][i] = max(dp[k][i], dp[k-1][j-1]+connect[j][i])
print(dp[K][N])
