# https://atcoder.jp/contests/dp/submissions/31274142
def solve(N,p):
    dp = [[0.0] * (N+1) for _ in range(N+1)]
    dp[0][0] = 1.0

    for i in range(N):
        for j in range(N):
            dp[i+1][j+1] += dp[i][j] * p[i]
            dp[i+1][j] += dp[i][j] * (1.0 - p[i])

    for dpi in dp: print(dpi)
    return sum(dp[-1][-N//2:])

def main():
    N = int(input())
    p = list(map(float, input().split()))
    print(solve(N,p))

print(solve(3,[0.3,0.6,0.8]))
