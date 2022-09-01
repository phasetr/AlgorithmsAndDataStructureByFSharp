# https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_7_A/review/3185364/jakenu0x5e/Python3
import sys
readline = sys.stdin.readline
writelines = sys.stdout.writelines
N = int(readline())
depth = [0]*N
PR = [-1]*N
G = [None]*N
for i in range(N):
    i, _, *cs, = map(int, readline().split())
    G[i] = cs
    for v in G[i]:
        PR[v] = i
def dfs(v, d):
    depth[v] = d
    for w in G[v]:
        dfs(w, d+1)
dfs(PR.index(-1), 0)
writelines(["node %d: parent = %d, depth = %d, %s, %s\n" % (i, PR[i], depth[i], ('root' if PR[i] == -1 else 'leaf' if len(G[i]) == 0 else 'internal node'), G[i]) for i in range(N)])
