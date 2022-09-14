# https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_11_A/review/3184890/jakenu0x5e/Python3
N = int(input())
for i in range(N):
    u, k, *vs = map(int, input().split())
    E = [0]*N
    for v in vs:
        E[v-1] = 1
    print(*E)
