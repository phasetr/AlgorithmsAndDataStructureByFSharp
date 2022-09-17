# https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_12_A/review/3164895/jakenu0x5e/Python3
N = int(input())
G = [[] for i in range(N)]
for v in range(N):
    for w, c in enumerate(map(int, input().split())):
        if c != -1:
            G[v].append((w, c))

from heapq import heappush, heappop, heapify
used = [0]*N
que = [(c, w) for w, c in G[0]]
used[0] = 1
heapify(que)

ans = 0
while que:
    cv, v = heappop(que)
    if used[v]:
        continue
    used[v] = 1
    ans += cv
    for w, c in G[v]:
        if used[w]:
            continue
        heappush(que, (c, w))
print(ans)
