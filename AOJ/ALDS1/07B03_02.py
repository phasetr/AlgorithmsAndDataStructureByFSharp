# https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_7_B/review/3185385/jakenu0x5e/Python3
import sys
readline = sys.stdin.readline
writelines = sys.stdout.writelines
N = int(readline())
L = [None]*N; R = [None]*N
S = [-1]*N
P = [-1]*N
D = [-1]*N
DG = [0]*N
H = [-1]*N
for i in range(N):
    i, l, r = map(int, readline().split())
    L[i] = l; R[i] = r
    if l != -1:
        P[l] = i
        DG[i] += 1
    if r != -1:
        P[r] = i
        DG[i] += 1
    if l != -1 != r:
        S[l] = r; S[r] = l
def dfs(v, d):
    D[v] = d
    H[v] = h = max((dfs(L[v], d+1) if L[v] != -1 else 0), (dfs(R[v], d+1) if R[v] != -1 else 0))
    return h+1
dfs(P.index(-1), 0)
writelines(["node %d: parent = %d, sibling = %d, degree = %d, depth = %d, height = %d, %s\n" % (i, P[i], S[i], DG[i], D[i], H[i], 'root' if P[i] == -1 else 'leaf' if DG[i] == 0 else 'internal node') for i in range(N)])
