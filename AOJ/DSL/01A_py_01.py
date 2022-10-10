# https://onlinejudge.u-aizu.ac.jp/solutions/problem/DSL_1_A/review/2437153/jakenu0x5e/Python3
n, q = map(int, input().split())

*parent, = range(n)
def root(x):
    if x != parent[x]:
        x = parent[x] = root(parent[x])
    return x

def unite(x, y):
    px = root(x)
    py = root(y)

    if px < py:
        parent[py] = px
    else:
        parent[px] = py

def same(x, y):
    return root(x) == root(y)

for i in range(q):
    com, x, y = map(int, input().split())
    if com == 0:
        unite(x, y)
    else:
        print(int(same(x, y)))
