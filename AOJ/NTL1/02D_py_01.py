# https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_2_D/review/3363559/jakenu0x5e/Python3
A, B = map(int, input().split())
C = abs(A)//abs(B)
print(-C if A^B < 0 else C)
