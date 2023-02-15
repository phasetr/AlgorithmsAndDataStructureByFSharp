# https://atcoder.jp/contests/tessoku-book/submissions/36125562
from bisect import bisect_left
def solve(n,d):
    xs = []
    for x,y in d: xs.append([x,-y])
    xs.sort()
    e = [1<<32]*n
    for i in range(n): e[bisect_left(e, -xs[i][1])] = -xs[i][1]
    return bisect_left(e,1<<32)

n = int(input())
d = [map(int,input().split()) for _ in range(n)]
print(solve(n,d))

def test():
    n,d = 5,[[30,50],[10,30],[40,10],[50,20],[40,60]]
    print(solve(n,d) == 3)
    n,d = 9,[[10,90],[20,80],[30,70],[40,60],[50,50],[60,40],[70,30],[80,20],[90,10]]
    print(solve(n,d) == 1)
