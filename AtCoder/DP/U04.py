# https://atcoder.jp/contests/dp/submissions/31582934
def solve(N,A):
    m = 1 << N
    dp = [0] * m
    cost = [0] * m
    for s in range(m):
        for i in range(N):
            for j in range(i):
                if (s >> i & 1) and (s >> j & 1):
                    cost[s] += A[i][j]

    for s in range(m):
        u = s
        while u:
            dp[s] = max(dp[s], dp[s - u] + cost[u])
            u = (u - 1) & s

    return dp[m-1]

def main():
    N = int(input())
    A = [[*map(int, input().split())] for _ in range(N)]
    print(solve(N,A))

print(solve(3,[[0,10,20],[10,0,-100],[20,-100,0]]) == 20)
# print((0 if 1 else 2) == 0)
# print((0 if 0 else 2) == 2)
