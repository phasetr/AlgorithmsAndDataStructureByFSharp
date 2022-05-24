# https://atcoder.jp/contests/dp/submissions/31327046

def solve(n,wsv):
    wsv.sort(key = lambda x:x[0] + x[1])
    W = 10 ** 4
    dp = [0] * (2 * W + 1)
    for w, s, v in wsv:
        for i in range(w + s, w - 1, -1):
            print(i-w)
            dp[i] = max(dp[i], dp[i - w] + v)
    #print(dp)
    return max(dp)

def main():
    n = int(input())
    wsv = [list(map(int, input().split())) for _ in range(n)]
    print(solve(n,wsv))

def test():
    print(solve(3,[[2,2,20],[2,1,30],[3,1,40]]) == 50)
test()
