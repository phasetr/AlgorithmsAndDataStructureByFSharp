# https://atcoder.jp/contests/tessoku-book/submissions/38889996
import sys
sys.setrecursionlimit(10**6)
def solve(n,m,ab,Q,que):
    uf = {}
    def find(x):
        if x not in uf: uf[x] = x
        if uf[x] != x: uf[x] = find(uf[x])
        return uf[x]
    def unite(x,y):
        x,y = find(x),find(y)
        if x != y: uf[x] = y

    s = set(q[0]-1 for k,*q in que if k==1)
    for i,[a,b] in enumerate(ab):
        if i not in s: unite(a-1,b-1)
    ans = []
    for k,*q in que[::-1]:
        if k==1:
            a,b = ab[q[0]-1]
            unite(a-1,b-1)
        else:
            a,b = q
            ans.append('Yes' if find(a-1)==find(b-1) else 'No')
    return (list(reversed(ans)))

n,m = map(int,input().split())
ab = [[*map(int,input().split())] for _ in range(m)]
que = [[*map(int,input().split())] for _ in range(int(input()))]
print(solve(n,m,ab,0,que), sep="\n")

def test():
    n,m,ab,Q,que = 3,2,[(1,2),(2,3)],4,[[2,2,3],[1,2],[2,1,3],[1,1]]
    print(list(solve(n,m,ab,Q,que)))
    print(solve(n,m,ab,Q,que) == ["Yes","No"])
    n,m,ab,Q,que = 12,7,[(8,11),(1,7),(10,12),(1,4),(4,8),(5,9),(3,5)],12,[[2,6,8],[1,6],[2,10,12],[1,1],[1,5],[1,3],[2,3,5],[1,7],[2,3,6],[1,4],[1,2],[2,9,11]]
    print(solve(n,m,ab,Q,que) == ["No","Yes","Yes","No","No"])
    n,m,ab,Q,que = 4,3,[(1,2),(2,3),(3,4)],7,[[2,1,2],[2,1,3],[2,1,4],[1,2],[2,1,2],[2,1,3],[2,1,4]]
    print(solve(n,m,ab,Q,que) == ["Yes","Yes","Yes","Yes","No","No"])
