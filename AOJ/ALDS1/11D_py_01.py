# https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_11_D/review/3184882/jakenu0x5e/Python3
import sys
readline = sys.stdin.readline
write = sys.stdout.write
N, M = map(int, readline().split())
*p, = range(N)
def root(x):
    if x == p[x]:
        return x
    p[x] = x = root(p[x])
    return x
def unite(x, y):
    px = root(x); py = root(y)
    if px < py:
        p[py] = px
    else:
        p[px] = py


for i in range(M):
    s, t = map(int, readline().split())
    unite(s, t)
*_, = map(root, range(N))
Q = int(readline())
ans = []
for q in range(Q):
    s, t = map(int, readline().split())
    ans.append('yes' if p[s] == p[t] else 'no')
write("\n".join(ans))
write("\n")
