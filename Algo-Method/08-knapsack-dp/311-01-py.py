N,M = map(int, input().split())
As = list(map(int, input().split()))
INF = 1 << 29

def solve(N,M,As):
    dp = [[INF]*(M+1) for _ in range(N+1)]
    dp[0][0] = 0
    for i in range(N):
        ai = As[i]
        for j in range(M+1):
            dp[i+1][j] = dp[i][j] if j < ai else min(dp[i][j], dp[i][j-ai]+1)
    return -1 if dp[N][M] == INF else dp[N][M]

print(solve(N,M,As))

def test():
    N,M,As = 5,12,[7,5,3,1,8]
    print(solve(N,M,As) == 2)
    N,M,As = 2,6,[7,5]
    print(solve(N,M,As) == -1)
