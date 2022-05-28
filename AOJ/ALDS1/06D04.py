# https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_6_D/review/2714414/kyuna/Python3
input()
a = list(map(int,input().split()))
b = sorted(a)
c = 0
for i in range(len(a)):
    x = a.index(b[i])
    j = 0
    while x>i:
        j+ = 1
        y = a.index(b[x])
        c+ = a[y]
        a[x],a[y] = a[y],a[x]
        x = y
    c += min(b[i]*j,b[i]*2+b[0]*(j+2))
print(c)
