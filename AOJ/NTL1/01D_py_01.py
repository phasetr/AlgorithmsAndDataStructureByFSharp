# https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_1_D/review/2188523/cima/Python3
n=m=int(input())
i=2
while i*i<=n:
    if n%i==0:
        m=m//i*(i-1)
        while n%i==0: n//=i
    i+=1
if n!=1:m=m//n*(n-1)
print(m)
