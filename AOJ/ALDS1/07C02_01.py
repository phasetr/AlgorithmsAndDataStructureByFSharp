# https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_7_C/review/3185395/jakenu0x5e/Python3
import sys
readline = sys.stdin.readline
write= sys.stdout.write
N = int(readline())
L = [None]*N; R = [None]*N; P = [-1]*(N+1)
for i in range(N):
    i, l, r = map(int, readline().split())
    L[i] = l; R[i] = r
    P[l] = i; P[r] = i
s0 = []; s1 = []; s2 = []
def dfs(v):
    v0 = str(v)
    s0.append(v0)
    L[v] != -1 and dfs(L[v])
    s1.append(v0)
    R[v] != -1 and dfs(R[v])
    s2.append(v0)
dfs(P.index(-1))
write("Preorder\n %s\nInorder\n %s\nPostorder\n %s\n" % tuple(map(" ".join, [s0, s1, s2])))
