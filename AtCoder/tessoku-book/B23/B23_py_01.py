# https://atcoder.jp/contests/tessoku-book/submissions/35993977
N = int(input())
P = [list(map(int, input().split())) for _ in range(N)]

def calc_dist(a, b):
  return ((P[a][0] - P[b][0])**2 + (P[a][1] - P[b][1])**2)**0.5

from math import inf
dp = [[inf] * N for _ in range(1<<N)]
dp[0][0] = 0

for S in range(1<<N):
  for i in range(N):
    if dp[S][i] == inf:
      continue
    for j in range(N):
      if (S >> j) & 1:
        continue
      dp[S | (1 << j)][j] = min(dp[S | (1 << j)][j], dp[S][i] + calc_dist(i, j))
print(dp[-1][0])
