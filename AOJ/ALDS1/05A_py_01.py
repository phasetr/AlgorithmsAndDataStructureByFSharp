# https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_5_A/review/2472062/jakenu0x5e/Python3
n = int(input())
*A, = map(int, input().split())
q = int(input())
*Q, = map(int, input().split())

bits = 1
for a in A:
    bits |= bits << a

for q in Q:
    print("yes"*((bits >> q) & 1)or"no")
