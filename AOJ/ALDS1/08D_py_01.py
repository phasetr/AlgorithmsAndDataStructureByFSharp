# https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_8_D/review/3185647/jakenu0x5e/Python3
from collections import deque
import sys
readline = sys.stdin.readline
write = sys.stdout.write

def rotate(nd, d):
    c = nd[d]
    if d:
        nd[1] = c[0]
        c[0] = nd
    else:
        nd[0] = c[1]
        c[1] = nd
    return c


root = None
def insert(val, pri):
    global root
    st = []
    dr = []
    x = root
    while x:
        st.append(x)
        if x[2] == val:
            return
        d = (x[2] < val)
        dr.append(d)
        x = x[d]
    nd = [None, None, val, pri]
    while st:
        x = st.pop(); d = dr.pop()
        c = x[d] = nd
        if x[3] >= c[3]:
            break
        rotate(x, d)
    else:
        root = nd

def __delete(nd):
    st = []; dr = []
    while nd[0] or nd[1]:
        l = nd[0]; r = nd[1]
        d = (l[3] <= r[3]) if l and r else (l is None)
        st.append(rotate(nd, d))
        dr.append(d ^ 1)
    nd = x = None
    while st:
        nd = x; x = st.pop(); d = dr.pop()
        x[d] = nd
    return x

def delete(val):
    global root
    x = root

    y = None
    while x:
        if val == x[2]:
            break
        y = x; d = (x[2] < val)
        x = x[d]
    else:
        return

    if y:
        y[d] = __delete(x)
    else:
        root = __delete(x)

def find(val):
    x = root
    while x:
        if val == x[2]:
            return 1
        x = x[x[2] < val]
    return 0

def debug():
    s0 = [""]
    s1 = [""]

    def dfs(nd):
        v = str(nd[2])
        s0.append(v)
        if nd[0]:
            dfs(nd[0])
        s1.append(v)
        if nd[1]:
            dfs(nd[1])
    dfs(root)
    return " ".join(s1), " ".join(s0)


M = int(readline())
ans = []
for m in range(M):
    cmd, *V, = readline().split()
    if cmd == "print":
        ans.extend(debug())
    elif cmd == "find":
        ans.append("yes" if find(int(V[0])) else "no")
    elif cmd == "delete":
        delete(int(V[0]))
    else:
        val, pri = map(int, V)
        insert(val, pri)
write("\n".join(ans))
write("\n")
