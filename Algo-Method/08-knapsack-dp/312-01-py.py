N,M,K = map(int, input().split())
As = list(map(int, input().split()))
INF = 1 << 29

def solve(N,M,K,As):
    dp = [[INF]*(M+1) for _ in range(N+1)]
    dp[0][0] = 0
    for i in range(N):
        ai = As[i]
        for j in range(M+1):
            dp[i+1][j] = min(dp[i+1][j], dp[i][j])
            if j >= ai: dp[i+1][j] = min(dp[i+1][j], dp[i][j-ai] + 1)
    return "Yes" if dp[N][M] <= K else "No"

print(solve(N,M,K,As))

def test():
    N,M,K,As = 3,10,2,[7,5,3]
    print(solve(N,M,K,As) == "Yes")
    N,M,K,As = 3,10,1,[7,5,3]
    print(solve(N,M,K,As) == "No")
