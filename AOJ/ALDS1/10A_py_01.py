# https://onlinejudge.u-aizu.ac.jp/solutions/problem/ALDS1_10_A/review/3184892/jakenu0x5e/Python3
N = int(input())
a = b = 1
while N:
    a, b = b, a+b
    N -= 1
print(a)
