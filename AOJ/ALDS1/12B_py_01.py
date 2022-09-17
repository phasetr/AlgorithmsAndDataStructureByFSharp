# https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_12_B/review/6061059/lloyz_nt/Python3
from collections import defaultdict
from heapq import heappop, heappush

n = int(input())
edge = defaultdict(list)
for _ in range(n - 1):
    L = list(map(int, input().split()))
    u, k, L = L[0], L[1], L[2:]
    for i in range(0, 2 * k, 2):
        edge[u].append((L[i], L[i + 1]))

hq = [(0, 0)]
INF = 10**10
ans = [INF for _ in range(n)]
while hq:
    cost, curr = heappop(hq)
    if cost > ans[curr]:
        continue
    ans[curr] = cost
    for np, dc in edge[curr]:
        if ans[np] != INF:
            continue
        heappush(hq, (cost + dc, np))

for i in range(n):
    print(i, ans[i])
