# https://atcoder.jp/contests/tessoku-book/submissions/36701762
N = int(input())
C = [input() for i in range(N)]

es = [[] for _ in range(2*N)]
for i,row in enumerate(C):
    for j,c in enumerate(row):
        if c=='.': continue
        es[i].append(j+N)
        es[j+N].append(i)

used = [False] * (2*N)
match = [-1] * (2*N)

def _dfs(v):
    global used, match
    used[v] = True
    for u in es[v]:
        w = match[u]
        if w < 0 or not used[w] and _dfs(w):
            match[v] = u
            match[u] = v
            return True
    return False

def bipartite_matching():
    global used, match
    ret = 0
    for v in range(2*N):
        if match[v] < 0:
            used = [False] * (2*N)
            if _dfs(v):
                ret += 1
    return ret

print(bipartite_matching())
