# https://atcoder.jp/contests/tessoku-book/submissions/36220074
n=int(input())
p=[0]*n
a=[0]*n

for i in range(n):
 p[i],a[i]=map(int,input().split())

d=[[0]*n for i in range(n)]



for c in range(1,n):
 for i in range(n-c):
  l=0
  r=0
  if i<=p[i]-1<=i+c:
      l=a[i]
  if i<=p[i+c]-1<=i+c:
      r=a[i+c]

  d[i][i+c]=max(l+d[i+1][i+c],r+d[i][i+c-1])
 #for i in range(n):
    #print(d[i])
print(d[0][n-1])
