# https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_11_C/review/5259581/noimi/Python3
n = int(input())
g = [[] for _ in range(n)]

for _ in range(n):
    a = list(map(int, input().split()))
    u = a[0]
    for i in range(2, len(a)):
        g[u - 1].append(a[i] - 1)

inf = 1e10
d = [inf for _ in range(n)]
d[0] = 0
pos = 0
q = [0]
while pos < len(q):
    now = q[pos]
    pos += 1
    for u in g[now]:
        if d[u] > d[now] + 1:
            d[u] = d[now] + 1
            q.append(u)

for i in range(n):
    print(i + 1, -1 if d[i] == inf else d[i])
