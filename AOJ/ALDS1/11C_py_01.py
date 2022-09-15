# https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_11_C/review/3172927/jakenu0x5e/Python3
N = int(input())
G = [None for i in range(N)]
for i in range(N):
    u, k, *vs = map(int, input().split())
    G[u-1] = [e-1 for e in vs]


from collections import deque
dist = [-1]*N
que = deque([0])
dist[0] = 0
while que:
    v = que.popleft()
    d = dist[v]
    for w in G[v]:
        if dist[w] > -1:
            continue
        dist[w] = d + 1
        que.append(w)

for i in range(N):
    print(i+1, dist[i])
