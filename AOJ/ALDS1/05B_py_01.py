# https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_5_B/review/2472140/jakenu0x5e/Python3
comp = 0
def m(L, R):
    global comp
    j = 0
    for l in L:
        while j < len(R) and R[j] < l:
            yield R[j]
            j += 1
        yield l
    while j < len(R):
        yield R[j]
        j += 1
    comp += len(L) + len(R)
def merge(A):
    global comp
    if len(A) == 1:
        return A
    if len(A) == 2:
        comp += 2
        a, b = A
        return A if a < b else (b, a)
    mid = len(A) // 2
    A[:] = m(merge(A[:mid]), merge(A[mid:]))
    return A

n, *A = map(int, open(0).read().split())
B = merge(A)
print(*B)
print(comp)
