# https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_1_E/review/6080963/lloyz_nt/Python3
def rec_gcd(a, b):
    if b == 0:
        return a, 1, 0
    d, y, x = rec_gcd(b, a % b)
    y -= a // b * x
    return d, x, y

a, b = map(int, input().split())
_, x, y = rec_gcd(a, b)
print(x, y)
