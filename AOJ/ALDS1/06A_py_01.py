# https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_6_A/review/6087313/lloyz_nt/Python3
def CountingSort(A, k):
    C = [0 for _ in range(k + 1)]
    for j in range(n):
        C[A[j]] += 1
    for i in range(1, k + 1):
        C[i] += C[i - 1]
    for j in range(n - 1, -1, -1):
        B[C[A[j]] - 1] = A[j]
        C[A[j]] -= 1

n = int(input())
A = list(map(int, input().split()))

maxA = max(A)
B = [0 for _ in range(n)]
CountingSort(A, maxA)
print(*B)
