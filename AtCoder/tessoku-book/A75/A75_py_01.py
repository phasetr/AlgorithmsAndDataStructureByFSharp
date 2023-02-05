# https://atcoder.jp/contests/tessoku-book/submissions/36851636
N = int(input())
TD = [tuple(map(int,input().split())) for i in range(N)]
TD.sort(key=lambda x:x[1])

M = 1440
dp = [0] * (M+1)
for t,d in TD:
    dp2 = [0] * (M+1)
    for i in range(M+1):
        if i-t < 0 or i > d:
            dp2[i] = dp[i]
        else:
            dp2[i] = max(dp[i], dp[i-t] + 1)
    dp = dp2
print(max(dp))
