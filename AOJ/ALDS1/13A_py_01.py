# https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_13_A/review/3184592/jakenu0x5e/Python3
from itertools import permutations

N = 8

M = [['.']*N for i in range(N)]
A0 = set()
B0 = set()

K = int(input())
R = set(range(N))
C = set(range(N))
for i in range(K):
    r, c = map(int, input().split())
    R.remove(r); C.remove(c)
    M[r][c] = 'Q'
    A0.add(r+c)
    B0.add(r-c)


for CS in permutations(C):
    A = A0.copy()
    B = B0.copy()
    ok = 1
    for r, c in zip(R, CS):
        if r+c in A:
            ok = 0
        A.add(r+c)
        if r-c in B:
            ok = 0
        B.add(r-c)
    if ok:
        for r, c in zip(R, CS):
            M[r][c] = 'Q'
        break
print(*("".join(m) for m in M), sep='\n')
