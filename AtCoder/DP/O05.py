# https://atcoder.jp/contests/dp/submissions/31170554
def popcount(x):
    return bin(x).count("1")
def solve(n, A):
    mod = 10**9+7
    N = 1<<n
    dp = [0]*N
    #bits = [0]*N
    dp[0] = 1
    for s in range(N):
        # bits[s] = bits[s//2]+ s%2
        for j in range(n):
            if s>>j & 1:
                dp[s] += dp[s^(1<<j)] * A[j][popcount(s)-1]
                # print(s, 1<<j, s^(1<<j), popcount(s) ,dp)
                # dp[s] += dp[s^1<<j] * A[k][bits[s]-1]
        dp[s] %= mod
    return dp

def main():
    n = int(input())
    A = [list(map(int, input().split())) for i in range(n)]
    dp = solve(n,A)
    print(dp[-1])

dp = solve(3,[[0,1,1],[1,0,1],[1,1,1]])
print(dp)
print(dp[-1] == 3)
