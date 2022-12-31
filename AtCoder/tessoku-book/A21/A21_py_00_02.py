# https://atcoder.jp/contests/tessoku-book/submissions/34868579
def solve(n,P,A):
    dp = [[0]*(n+1) for _ in range(n+1)]
    for r in range(n+1)[::-1]:
        for l in range(r):
            dp[l+1][r] = max(dp[l+1][r],dp[l][r]+A[l]*(l<=P[l]-1<r))
            dp[l][r-1] = max(dp[l][r-1],dp[l][r]+A[r-1]*(l<=P[r-1]-1<r))
    print(dp)
    return max(dp[i][i] for i in range(n+1))

def main():
    n = int(input())
    P,A = zip(*(map(int,input().split()) for _ in range(n)))
    print(solve(n,P,A))

# TEST
print(solve(4,[4,3,2,1],[20,30,20,10]) == 50)
print(solve(8,[8,7,6,5,4,3,2,1],[100,100,100,100,100,100,100,100]) == 400)
