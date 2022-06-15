# https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_9_D/review/6012723/kyotoku1483/Python3
from sys import stdin

N = int(stdin.readline().rstrip())
A = list(map(int, stdin.readline().rstrip().split()))
A.sort()

for i in range(1, N):
    j = i - 1
    while j > 0:
        k = (j - 1) // 2
        A[j], A[k] = A[k], A[j]
        j = k

    A[0], A[i] = A[i], A[0]
print(*A)
