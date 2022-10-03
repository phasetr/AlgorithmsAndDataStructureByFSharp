# https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_2_D/review/3363559/jakenu0x5e/Python3
def solve(a,b):
    c = abs(a)//abs(b)
    return -c if a*b<0 else c
a,b = map(int, input().split())
print(solve(a,b))

print(solve(5,8) == 0)
