# https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_5_C/review/3294770/haji149/Python3
import math

def rot60(s, t):
    v = t - s
    a = 1/2 + complex(0,(math.sqrt(3)/2))
    return v * a + s

def pr(p):
    x = p.real
    y = p.imag
    print('%.10f %.10f'%(x, y))

def dfs(p1, p2, n):
    if n == 0:
        return

    s = (p2 - p1) * (1/3) + p1
    t = (p2 - p1) * (2/3) + p1
    u = rot60(s, t)
    dfs(p1, s, n - 1)
    pr(s)
    dfs(s, u, n - 1)
    pr(u)
    dfs(u, t, n - 1)
    pr(t)
    dfs(t, p2, n -1)

n = int(input())
s = (0 + 0j)
t = (100 + 0j)
pr(s)
dfs(s, t, n)
pr(t)
