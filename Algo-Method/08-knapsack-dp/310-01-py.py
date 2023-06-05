N,M = map(int, input().split())
As = list(map(int, input().split()))
MOD = 1000

def solve(N,M,As):
    dp = [[0]*(M+1) for _ in range(N+1)]
    dp[0][0] = 1
    for i in range(N):
        ai = As[i]
        for j in range(M+1):
            dp[i+1][j] = dp[i][j] if j < ai else (dp[i][j] + dp[i][j-ai])%MOD
    return dp[N][M]

print(solve(N,M,As))

def test():
    N,M,As = 5,12,[7,5,3,1,8]
    print(solve(N,M,As) == 2)
    N,M,As = 4,5,[4,1,1,1]
    print(solve(N,M,As) == 3)
