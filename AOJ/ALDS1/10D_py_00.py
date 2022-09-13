def solve(n,p,q):
    dp = [[0]*(n+1) for _ in range(n+1)]
    prs = [0,q[0]]

    temp = q[0]
    for i in range(n):
        temp += p[i]
        prs.append(temp)
        temp += q[i+1]
        prs.append(temp)

    for i in range(n+1):
        dpi = dp[i]
        dpi[i] = q[i]
        for j in range(i-1, -1, -1):
            ma = dp[j][j] + dpi[j+1]
            for k in range(1, i-j):
                mak = dp[j+k][j] + dpi[j+k+1]
                ma = mak if ma > mak else ma
            dpi[j] = ma + prs[2*i+1] - prs[2*j]
    return dp[n][0]

def main():
    n = int(input())
    p = list(map(float, input().split()))
    q = list(map(float, input().split()))
    print(solve(n,p,q))
main()

def cmp(a,b): return abs(a-b) <= 1e-4
print(cmp(solve(5,[0.1500,0.1000,0.0500,0.1000,0.2000],[0.0500,0.1000,0.0500,0.0500,0.0500,0.1000]), 2.75000000))
print(cmp(solve(7,[0.0400,0.0600,0.0800,0.0200,0.1000,0.1200,0.1400],[0.0600,0.0600,0.0600,0.0600,0.0500,0.0500,0.0500,0.0500]),3.12000000))
