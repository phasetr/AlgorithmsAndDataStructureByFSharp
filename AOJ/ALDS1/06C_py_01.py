# https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_6_C/review/3185059/jakenu0x5e/Python3
import sys
readline = sys.stdin.readline
writelines = sys.stdout.writelines
N = int(input())
A = []
D = {}
for i in range(N):
    v, d = readline().split()
    A.append((v, int(d)))
    D.setdefault(int(d), []).append(v)

def partition(A, p, r):
    x = A[r]
    i = p
    for j in range(p, r):
        if A[j][1] <= x[1]:
            A[i], A[j] = A[j], A[i]
            i += 1
    A[i], A[r] = A[r], A[i]
    return i

def quicksort(A, p, r):
    if p < r:
        q = partition(A, p, r)
        quicksort(A, p, q-1)
        quicksort(A, q+1, r)

D = {k: iter(v).__next__ for k, v in D.items()}

quicksort(A, 0, N-1)
ok = 1
for v, d in A:
    if D[d]() != v:
        ok = 0
ans = ['Stable\n' if ok else 'Not stable\n']
for v, d in A:
    ans.append("%s %d\n" % (v, d))
writelines(ans)
