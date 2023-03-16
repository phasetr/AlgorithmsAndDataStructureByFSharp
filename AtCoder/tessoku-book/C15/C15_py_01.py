# https://atcoder.jp/contests/tessoku-book/submissions/34890553
n = int(input())
k = int(input())
E = [tuple(map(int,input().split())) for _ in range(n)]
m = 86400
X,Y = [0]*(m+1),[0]*(m+1)
G = [[] for _ in range(m+1)]
for l,r in E:
  G[r].append(l)
t = -1
for i in range(1,m+1):
  X[i] = X[i-1]
  for l in G[i]:
    t = max(t,l-k,0)
  if t >= 0:
    X[i] = max(X[i],X[t]+1)
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
for l,r in E:
  ans = X[max(l-k,0)]+1+Y[min(r+k,m)]
  print(ans)
