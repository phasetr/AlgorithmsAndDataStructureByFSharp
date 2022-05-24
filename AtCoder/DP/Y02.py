# https://atcoder.jp/contests/dp/submissions/31740383
mod = 10 ** 9 + 7

def factorial(n):
    fact    = [1, 1] + [0] * (n - 1)
    factinv = [1, 1] + [0] * (n - 1)
    inv     = [0, 1] + [0] * (n - 1)
    for i in range(2, n + 1):
        fact[i] = fact[i - 1] * i % mod
        print(-inv[mod%i], mod // i, -inv[mod % i] * (mod // i), -inv[mod % i] * (mod // i) % mod)
        inv[i]  = -inv[mod % i] * (mod // i) % mod
        print(inv[i])
        factinv[i] = factinv[i - 1] * inv[i] % mod
    return fact, factinv, inv

def solve(h,w,n,xy):
    xy.sort(key = lambda x: x[0] + x[1])
    fact, factinv, inv = factorial(h + w)
    print(fact)
    print(factinv)
    print(inv)

    def C(n, r):
        if r < 0 or n < r:
            return 0
        return fact[n] * factinv[r] % mod * factinv[n - r] % mod

    dp = [0] * n
    for i in range(n):
        x, y = xy[i]
        dp[i] = C(x + y, y)
        for j in range(i):
            x_, y_ = xy[j]
            dp[i] -= dp[j] * C(x + y - (x_ + y_), x - x_)
            dp[i] %= mod
    ans = C(h + w, h)
    for i in range(n):
        x, y = xy[i]
        ans -= dp[i] * C(h + w - (x + y), h - x)
        ans %= mod

    return ans

def main():
    h, w, n = map(int, input().split())
    h -= 1;w -= 1;xy = []
    for _ in range(n):
        x, y = map(int, input().split())
        x -= 1;y -= 1
        xy.append((x, y))
    print(solve(h,w,n,xy))

def test():
    print(solve(3-1,4-1,2,[[2-1,2-1],[1-1,4-1]]) == 3)
test()
