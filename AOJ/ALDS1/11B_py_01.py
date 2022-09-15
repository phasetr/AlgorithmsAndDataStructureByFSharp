# https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_11_B/review/3182881/jakenu0x5e/Python3
import sys
readline = sys.stdin.readline
write = sys.stdout.write

N = int(readline())
G = [None]*(N+1)
for i in range(N):
    u, k, *vs = map(int, readline().split())
    G[u] = vs


begin = [-1]*(N+1)
end = [-1]*(N+1)
lb = iter(range(1, 2*N+1)).__next__
def dfs(v):
    begin[v] = lb()
    for w in G[v]:
        if begin[w] != -1:
            continue
        dfs(w)
    end[v] = lb()


for v in range(1, N+1):
    if begin[v] != -1:
        continue
    dfs(v)
write("\n".join("{} {} {}".format(*args) for args in zip(range(1, N+1), begin[1:], end[1:])))
write("\n")
