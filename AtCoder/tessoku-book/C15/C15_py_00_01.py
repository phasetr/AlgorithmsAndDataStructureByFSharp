# https://atcoder.jp/contests/tessoku-book/submissions/34890553
def solve(n,k,E):
    m = 86400
    m = 20
    X,Y = [0]*(m+1),[0]*(m+1)
    G = [[] for _ in range(m+1)]
    for l,r in E:
        G[r].append(l)
    t = -1
    print(G)
    for i in range(1,m+1):
        print("Loop start")
        X[i] = X[i-1]
        for l in G[i]:
            print(t,l-k,0)
            t = max(t,l-k,0)
        if t >= 0: X[i] = max(X[i],X[t]+1)
        print(i,t)
        print("Loop end")
    print(X)

    G = [[] for _ in range(m+1)]
    for l,r in E:
        G[l].append(r)
    t = m+1
    for i in range(m)[::-1]:
        Y[i] = Y[i+1]
        for r in G[i]:
            t = min(t,r+k,m)
        if t <= m:
            Y[i] = max(Y[i],Y[t]+1)
    print(Y)

    ans = []
    for l,r in E:
        print(X[max(l-k,0)],Y[min(r+k,m)])
        ans.append(X[max(l-k,0)]+1+Y[min(r+k,m)])
    return ans

n = int(input())
k = int(input())
E = [tuple(map(int,input().split())) for _ in range(n)]

def test():
    n,k,E = 5,0,[(0,4),(1,2),(3,7),(5,9),(7,8)]
    print(solve(n,k,E) == [2,3,3,2,3])
    n,k,E = 9,1000,[(0,1000),(1000,2000),(2000,3000),(3000,4000),(4000,5000),(5000,6000),(6000,7000),(7000,8000),(8000,9000)]
    print(solve(n,k,E) == [5,4,5,4,5,4,5,4,5])

for i in range(4)[::-1]: print(i)
for i in range(1,4): print(i)
