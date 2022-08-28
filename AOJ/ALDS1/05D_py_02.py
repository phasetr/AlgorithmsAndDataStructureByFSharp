# https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_5_D/review/2713553/kyuna/Python3
def g(A,l,m,r):
 global c
 L,R=A[l:m]+[1e9],A[m:r]+[1e9]
 i=j=0
 for k in range(l,r):
  if L[i]<R[j]:A[k]=L[i];i+=1;c+=j
  else:A[k]=R[j];j+=1
def s(A,l,r):
 if l+1<r:m=(l+r)//2;s(A,l,m);s(A,m,r);g(A,l,m,r)
c=0
n=int(input())
A=list(map(int,input().split()))
s(A,0,n)
print(c)
