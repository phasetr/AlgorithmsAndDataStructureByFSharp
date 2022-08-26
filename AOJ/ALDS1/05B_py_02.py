# https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_5_B/review/2472140/jakenu0x5e/Python3
import sys
sys.setrecursionlimit(10**6)

def Merge(L, R):
    global ans
    j = 0
    for l in L:
        while j < len(R) and R[j] < l:
            yield R[j]
            j += 1
        yield l
    while j < len(R):
        yield R[j]
        j += 1
    ans += len(L) + len(R)

def MergeSort(A):
    global ans
    if len(A) == 1:
        return A
    elif len(A) == 2:
        ans += 2
        a, b = A
        return A if a < b else (b, a)
    mid = len(A) // 2
    A[:] = Merge(MergeSort(A[:mid]), MergeSort(A[mid:]))
    return A

ans = 0
n = int(input())
A = list(map(int, input().split()))
ANS = MergeSort(A)
print(*ANS)
print(ans)
