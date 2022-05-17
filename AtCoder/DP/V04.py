# https://atcoder.jp/contests/dp/submissions/31615106
import sys
sys.setrecursionlimit(10 ** 7)

N, M = map(int, input().split())
edges = [[] for _ in range(N)]
for _ in range(N - 1):
    x, y = map(int, input().split())
    edges[x - 1].append(y - 1)
    edges[y - 1].append(x - 1)
edges[0].append(-1)

dp1 = [0] * N
def dfs(v, p):
    tmp = 1
    edges[v].remove(p)
    for c in edges[v]:
        tmp *= dfs(c, v) + 1
        tmp %= M
    dp1[v] = tmp
    return tmp

dfs(0, -1)

ans = [0] * N
def dfs2(v, tmp):
    ans[v] = tmp * dp1[v] % M
    cum1, cum2 = [1], [1]
    for i in edges[v]:
        cum1.append(cum1[-1] * (dp1[i] + 1) % M)
    for i in edges[v][::-1]:
        cum2.append(cum2[-1] * (dp1[i] + 1) % M)
    for i in range(len(edges[v])):
        dfs2(edges[v][i], (cum1[i] * cum2[-i - 2] * tmp + 1) % M)

dfs2(0, 1)
[print(i) for i in ans]
