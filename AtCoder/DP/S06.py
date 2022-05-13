# https://atcoder.jp/contests/dp/submissions/31378597
def solve(k,d):
    n = len(k)
    dp = [[0] * d for _ in range(n)]
    mod = 10 ** 9 + 7
    acc = 0
    for i in range(n):
        for j in range(10):
            for x in range(d):
                dp[i][(x+j)%d] += dp[i-1][x]
                dp[i][(x+j)%d] %= mod
                print(dp)
        kk = int(k[i])
        for j in range(kk):
            dp[i][(j+acc)%d] += 1
        acc += kk
        acc %= d
    return ((dp[-1][0] + (acc % d == 0)-1) % mod)

def main():
    k = input()
    d = int(input())
    return solve(k,d)

print(solve("30",4) == 6)
