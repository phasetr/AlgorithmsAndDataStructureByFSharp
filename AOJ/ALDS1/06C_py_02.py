# https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_6_C/review/6099126/lloyz_nt/Python3
import sys
sys.setrecursionlimit(10**6)

def Partition(A, p, r):
    x = A[r][1]
    i = p - 1
    for j in range(p, r):
        if A[j][1] <= x:
            i += 1
            A[i], A[j] = A[j], A[i]
    A[i + 1], A[r] = A[r], A[i + 1]
    return i + 1

def QuickSort(A, p, r):
    if p < r:
        q = Partition(A, p, r)
        QuickSort(A, p, q - 1)
        QuickSort(A, q + 1, r)

n = int(input())
C = [list(input().split()) for _ in range(n)]
for i in range(n):
    C[i][1] = int(C[i][1])

sortC = sorted(C, key=lambda x: x[1])
QuickSort(C, 0, n - 1)
if C == sortC:
    print("Stable")
else:
    print("Not stable")
for i in range(n):
    print(*C[i])
