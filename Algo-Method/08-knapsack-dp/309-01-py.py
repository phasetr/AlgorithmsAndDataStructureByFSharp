N,M = map(int, input().split())
As = list(map(int,input().split()))

def solve(N,M,As):
    dp = [[False]*(M+1) for _ in range(N+1)]
    dp[0][0] = True
    for i in range(N):
        ai = As[i]
        for j in range(M+1):
            dp[i+1][j] = dp[i][j] if j<ai else dp[i][j-ai] or dp[i][j]
    return "Yes" if dp[N][M] else "No"

print(solve(N,M,As))

def test():
    N,M,As = 3,10,[7,5,3]
    print(solve(N,M,As) == "Yes")

    N,M,As = 2,6,[9,7]
    print(solve(N,M,As) == "No")
