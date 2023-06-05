N,W = map(int,input().split())
wvs = [tuple(map(int,input().split())) for i in range(N)]

def solve(N,W,wvs):
    dp = [[0]*(W+1) for _ in range(N+1)]
    for i in range(N):
        w = wvs[i][0]
        v = wvs[i][1]
        for j in range(W+1):
            dp[i+1][j] = dp[i][j] if j<w else max(dp[i][j-w]+v, dp[i][j])
    return dp[N][W]

print(solve(N,W,wvs))

def test():
    N,W,wvs = 6,9,[(2,3),(1,2),(3,6),(2,1),(1,3),(5,85)]
    print(solve(N,W,wvs) == 94)
    N,W,wvs = 3,4,[(3,5),(2,3),(2,3)]
    print(solve(N,W,wvs) == 6)
