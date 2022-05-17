# https://atcoder.jp/contests/dp/submissions/24251942
from collections import deque
n,m=map(int,input().split())
g=[[] for i in range(n)]
for _ in range(n-1):
  u,v=map(int,input().split())
  g[u-1].append(v-1)
  g[v-1].append(u-1)
par=[-1]*n
dq=deque([0])
order=[]
while dq:
  ver=dq.popleft()
  order.append(ver)
  for to in g[ver]:
    if to!=par[ver]:
      par[to]=ver
      g[to].remove(ver)
      dq.append(to)
bu=[0]*n
td=[1]*n
for v in order[::-1]:
  a=1
  for to in g[v]:
    a=a*(bu[to]+1)%m
  bu[v]=a
for i in order:
  c=len(g[i])
  al=[1]*(c+1)
  ar=[1]*(c+1)
  for j in range(c):
    al[j+1]=al[j]*(bu[g[i][j]]+1)%m
  for j in range(c)[::-1]:
    ar[j]=ar[j+1]*(bu[g[i][j]]+1)%m
  for j in range(c):
    td[g[i][j]]=(td[i]*al[j]*ar[j+1]+1)%m
for i in range(n):
  print(bu[i]*td[i]%m)
