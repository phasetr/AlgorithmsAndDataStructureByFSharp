# https://atcoder.jp/contests/tessoku-book/submissions/35811469
from bisect import bisect_left

def solve(N,A):
    INF = 1000000000000000000
    L = [INF]*(N+1)
    ans = 0
    for a in A:
        pos = bisect_left(L, a)
        L[pos] = a
        ans = max(pos + 1, ans)
        print(a,pos,ans,L)
    return ans

def main():
    N = int(input())
    A = [int(x) for x in input().split()]
    print(solve(N,A))

main()

def test():
    N,A = 6,[2,3,1,6,4,5]
    print(solve(N, A) == 4)
    N,A = 10,[1,1,1,1,1,1,1,1,1,1]
    print(solve(N, A) == 1)
