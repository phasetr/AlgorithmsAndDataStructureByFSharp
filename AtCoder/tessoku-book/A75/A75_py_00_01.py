# https://atcoder.jp/contests/tessoku-book/submissions/36851636
# https://atcoder.jp/contests/tessoku-book/submissions/36547311
def solve(N,TD):
    M = 1440
    dp = [0] * (M+1)
    for ti, di in sorted(TD,key=lambda x:x[1]):
        for j in range(M, -1, -1):
            if ti <= j <= di:
                dp[j] = max(dp[j], dp[j-ti] + 1)
    return max(dp)

N = int(input())
TD = [tuple(map(int,input().split())) for i in range(N)]
print(solve(N, TD))

def test():
    N = 4
    TD = [(20,70),(30,50),(30,100),(20,60)]
    print(solve(N, TD) == 4)
