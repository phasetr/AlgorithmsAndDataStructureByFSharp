# https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_6_B/review/3185051/jakenu0x5e/Python3
N = int(input())
*A, = map(int, input().split())

def partition(A, p, r):
    x = A[r]
    i = p
    for j in range(p, r):
        if A[j] <= x:
            A[i], A[j] = A[j], A[i]
            i += 1
    A[i], A[r] = A[r], A[i]
    return i

j = partition(A, 0, N-1)
print(*(str(x) if i != j else "[%d]" % x for i, x in enumerate(A)))
