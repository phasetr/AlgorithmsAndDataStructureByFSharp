# cf. 13C_c_01.c
"""うまく動かない"""
from copy import copy
from functools import reduce

def L1dist(a):
    def sum(acc, i): return acc if a[i] == 15 else acc + abs(i//4 - a[i]//4) + abs(i%4 - a[i]%4)
    return reduce(sum, range(16), 0)
def swap_(a,i,j):
    """破壊的なスワップ"""
    a[i],a[j] = a[j],a[i]
    return a

def solve(ivalues):
    ans = 45
    p = 0
    a = [0] * 16
    for i in range(16):
        if ivalues[i]==0: a[i]=15; p=i
        else: a[i]=ivalues[i]-1

    def frec(pre, movs, ans, p):
        d = L1dist(a)
        if movs+d > ans:
            return (ans,p)
        if d==0:
            ans = movs
            return (ans,p)
        if pre!=1 and p>3:   swap_(a,p,p-4); p=p-4; (ans,p)=frec(0,movs+1,ans,p); p=p+4; swap_(a,p,p-4)
        if pre!=0 and p<12:  swap_(a,p,p+4); p=p+4; (ans,p)=frec(1,movs+1,ans,p); p=p-4; swap_(a,p,p+4)
        if pre!=3 and p%4>0: swap_(a,p,p-1); p=p-1; (ans,p)=frec(2,movs+1,ans,p); p=p+1; swap_(a,p,p-1)
        if pre!=2 and p%4<3: swap_(a,p,p+1); p=p+1; (ans,p)=frec(3,movs+1,ans,p); p=p-1; swap_(a,p,p+1)

    ans = frec(-1,0,ans,p)
    return ans

ivalues = [1,2,3,4,6,7,8,0,5,10,11,12,9,13,14,15]
print(solve(ivalues) == 8)
