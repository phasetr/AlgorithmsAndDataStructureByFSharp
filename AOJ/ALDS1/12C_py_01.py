# https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_12_C/review/2628742/SotaNishy/Python3
from heapq import heappush, heappop

inf = float('inf')
n = int(input())
g = []
for i in range(n):
    line = list(map(int, input().split()[2:]))
    g.append(zip(line[0::2], line[1::2]))

dist = [inf] * n
dist[0] = 0
heap = [(0, 0)]

while heap:
    current = heappop(heap)[1]
    for v, c in g[current]:
        new_dist = dist[current] + c
        if new_dist < dist[v]:
            dist[v] = new_dist
            heappush(heap, (new_dist, v))

for i in range(n):
    print(i, dist[i])
