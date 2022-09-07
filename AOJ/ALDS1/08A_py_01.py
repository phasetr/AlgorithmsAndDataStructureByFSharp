# https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_8_A/review/3185533/jakenu0x5e/Python3
from collections import deque
import sys
readline = sys.stdin.readline
write = sys.stdout.write

root = None
def insert(z):
    global root
    y = None
    x = root
    while x is not None:
        y = x
        if z[2] < x[2]:
            x = x[0]
        else:
            x = x[1]
    z[3] = y

    if y is None:
        root = z
    elif z[2] < y[2]:
        y[0] = z
    else:
        y[1] = z

def debug():
    s0 = [""]
    s1 = [""]

    def dfs(nd):
        v = str(nd[2])
        s0.append(v)
        if nd[0] is not None:
            dfs(nd[0])
        s1.append(v)
        if nd[1] is not None:
            dfs(nd[1])
    dfs(root)
    return " ".join(s1), " ".join(s0)


M = int(readline())
ans = []
for m in range(M):
    cmd, *V, = readline().split()
    if cmd == "print":
        ans.extend(debug())
    else:
        insert([None, None, int(V[0]), None])
write("\n".join(ans))
write("\n")
