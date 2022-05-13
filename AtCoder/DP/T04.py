# https://atcoder.jp/contests/dp/submissions/31434056
mod = 10**9+7

def solve(n,s):
    dp = [[0]*(n) for i in range(n)]
    for i in range(n):
        dp[0][i] = 1

    for i in range(n-1):
        rui = [0]*(n+1-i)
        for j in range(n-i): rui[j+1] = (rui[j] + dp[i][j]) % mod
        for less in range(n-i):
            if s[i] == "<":
                dp[i+1][less] = rui[less+1]
            else:
                dp[i+1][less] = (rui[n-i]-rui[less+1]+mod)
            dp[i+1][less] %= mod
    return dp[n-1][0]%mod

def main():
    n = int(input())
    s = input()
    solve(n,s)

print(solve(4,"<><")==5)
