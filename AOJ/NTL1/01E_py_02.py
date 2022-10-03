# https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_1_E/review/2188577/cima/Python3
a,b=map(int,input().split())
c=g=1;e=f=0
while b:
    d,m=divmod(a,b)
    h=c-d*e
    i=f-d*g
    a,b=b,m
    c,e=e,h
    f,g=g,i
print(c,f)
