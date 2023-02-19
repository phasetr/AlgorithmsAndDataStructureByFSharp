# https://atcoder.jp/contests/tessoku-book/submissions/34882088
def solve(n,k,A):
    dp = [False]*(n+1)
    for i in range(1,n+1): dp[i] = any(not dp[i-a] for a in A if a<=i)
    return "First" if dp[n] else "Second"

n,k,*A = map(int,open(0).read().split())
print(solve(n,k,A))

def test():
    n,k,A = 8,2,[2,3]
    print(solve(n,k,A) == "First")
    n,k,A = 6,2,[2,3]
    print(solve(n,k,A) == "Second")
    n,k,A = 20,3,[6,1,3]
    print(solve(n,k,A) == "Second")
