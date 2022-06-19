# https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_10_D/review/5068391/pred/Python3
def main():

    n = int(input())
    p = list(map(float, input().split()))
    q = list(map(float, input().split()))
    dp = [[0] * (n + 1) for _ in range(n + 1)]
    sump = [0, q[0], ]
    temp = q[0]

    for i in range(n):
        temp += p[i]
        sump.append(temp)
        temp += q[i + 1]
        sump.append(temp)

    for i in range(n + 1):
        dpi = dp[i]
        dpi[i] = q[i]
        for j in range(i - 1, -1, -1):
            ma = dp[j][j] + dpi[j+1]
            for k in range(1, i - j):
                mak = dp[j+k][j] + dpi[j+k+1]
                if ma > mak:
                    ma = mak
            dpi[j] = ma + sump[2 * i + 1] - sump[2 * j]

    print(dp[n][0])

main()
