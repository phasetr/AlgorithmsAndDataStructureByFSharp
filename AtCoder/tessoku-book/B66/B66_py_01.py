# https://atcoder.jp/contests/tessoku-book/submissions/38889996
import sys
sys.setrecursionlimit(10**6)
uf={}
def find(x):
  if x not in uf:
    uf[x]=x
  if uf[x]!=x:
    uf[x]=find(uf[x])
  return uf[x]
def unite(x,y):
  x,y=find(x),find(y)
  if x!=y:
    uf[x]=y
n,m=map(int,input().split())
ab=[[*map(int,input().split())] for _ in range(m)]
que=[[*map(int,input().split())] for _ in range(int(input()))]
s=set(q[0]-1 for k,*q in que if k==1)
for i,[a,b] in enumerate(ab):
  if i not in s:
    unite(a-1,b-1)
ans=[]
for k,*q in que[::-1]:
  if k==1:
    a,b=ab[q[0]-1]
    unite(a-1,b-1)
  else:
    a,b=q
    ans+=['Yes' if find(a-1)==find(b-1) else 'No']
print(*ans[::-1],sep='\n')
