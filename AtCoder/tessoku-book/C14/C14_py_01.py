# https://atcoder.jp/contests/tessoku-book/submissions/34890361
from heapq import*
n,m = map(int,input().split())
G = [[] for _ in range(n)]
for _ in range(m):
  a,b,c = map(int,input().split())
  a -= 1
  b -= 1
  G[a].append((b,c))
  G[b].append((a,c))
def f(s):
  D = [1<<30]*n
  D[s] = 0
  Q = [(0,s)]
  while Q:
    d,u = heappop(Q)
    if D[u] < d:
      continue
    for v,c in G[u]:
      if D[v] > d+c:
        D[v] = d+c
        heappush(Q,(d+c,v))
  return D
X,Y = f(0),f(n-1)
ans = sum(X[i]+Y[i] == X[n-1] for i in range(n))
print(ans)
