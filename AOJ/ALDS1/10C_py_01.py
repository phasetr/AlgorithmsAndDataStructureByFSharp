# https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_10_C/review/5906759/lloyz_nt/Python3
from collections import deque
from bisect import bisect_left
import sys
input = sys.stdin.readline

INF = 10**10
q = int(input())
for _ in range(q):
    X = list(input())
    X = X[:-1]
    Y = list(input())
    Y = Y[:-1]
    Y_info = [deque() for _ in range(50)]
    for i in range(len(Y)):
        Y_info[ord(Y[i]) - ord('a')].appendleft(i)
    ans = [INF for _ in range(max(len(X), len(Y)))]
    for s in X:
        for i in Y_info[ord(s) - ord('a')]:
            ans[bisect_left(ans, i)] = i
    print(bisect_left(ans, INF))
