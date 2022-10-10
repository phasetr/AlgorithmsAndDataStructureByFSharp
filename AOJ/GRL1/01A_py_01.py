# https://onlinejudge.u-aizu.ac.jp/solutions/problem/GRL_1_A/review/4700807/tktk_snsn/Python3
import heapq
import sys
input = sys.stdin.buffer.readline
sys.setrecursionlimit(10 ** 7)

N, M, r = map(int, input().split())
edge = [[] for _ in range(N)]
for _ in range(M):
    s, t, d = map(int, input().split())
    edge[s].append((t, d))

inf = 10 ** 18
dist = [inf] * N
dist[r] = 0
que = [(0, r)]
while que:
    c, s = heapq.heappop(que)
    if dist[s] < c:
        continue
    d = dist[s]
    for t, cost in edge[s]:
        if dist[t] > d + cost:
            dist[t] = d + cost
            heapq.heappush(que, (d + cost, t))

for i in range(N):
    if dist[i] >= inf:
        print("INF")
    else:
        print(dist[i])
