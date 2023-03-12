import sys; input = sys.stdin.readline
f = lambda:map(int,input().split())

def solve(N,M,K,ab):
    scores = [[0]*(N+1) for _ in range(N+1)]
    for A,B in ab:
        for a in range(1,A+1):
            for b in range(B,N+1):
                scores[a][b]+=1

    INF=10**5
    dp = [[-INF]*(N+1)for _ in range(K+1)]
    dp[0][0]=0
    for k in range(1,K+1):
        for i in range(1,N+1):
            for j in range(1,i+1):
                dp[k][i] = max(dp[k][i], dp[k-1][j-1]+scores[j][i])
    return(dp[K][N])

N,M,K = f()
ab = [list(map(int, input().split())) for _ in range(M)]
print(solve(N, M, K, ab))

def test():
    N,M,K,ab = 6,4,3,[(3,4),(3,5),(2,5),(1,6)]
    print(solve(N,M,K,ab) == 3)
    N,M,K,ab = 4,6,1,[(1,2),(1,3),(1,4),(2,3),(2,4),(3,4)]
    print(solve(N,M,K,ab) == 6)
    N,M,K,ab = 10,4,10,[(1,3),(2,4),(2,3),(1,4)]
    print(solve(N,M,K,ab) == 0)
