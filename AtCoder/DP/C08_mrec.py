# https://atcoder.jp/contests/dp/submissions/31742351
n = 3
v = [[10,40,70],[20,50,80],[30,60,90]]

def solve(n,v):
    dp = [[0]*3 for i in range(n)]

    for j in range(3):
        dp[0][j] = v[0][j]

    for i in range(1,n):
        for j in range(3):
            dp[i][j] = v[i][j]+max(dp[i-1][(j+1)%3],dp[i-1][(j+2)%3])

    return max(dp[n-1])

def main():
    n = int(input())
    v = [list(map(int,input().split())) for i in range(n)]
    print(solve(n,v))

# main()
print(solve(n,v) == 210)
