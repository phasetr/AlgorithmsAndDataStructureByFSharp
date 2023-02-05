def solve(n,T):
    T.sort()
    dp = [[-1 for _ in range(1441)] for _ in range(n+1)]
    dp[0][0] = 0

    for i in range(1, n+1):
        for j in range(1441):
            dp[i][j] = max(dp[i-1][j], dp[i][j-1])
            if (j-T[i-1][1] >= 0) and (j<=T[i-1][0]):
                dp[i][j] = max(dp[i][j], dp[i-1][j-T[i-1][1]]+1)

    return dp[-1][-1]

n = int(input())
T = []
for i in range(n):
    t, d = map(int, input().split())
    T.append([d, t])
print(solve(n,T))

def test():
    n = 4
    T = [[20,70],[30,50],[30,100],[20,60]]
    S = []
    for t in T: S.append(list(reversed(t)))
    print(S)
    print(solve(n, S) == 4)
