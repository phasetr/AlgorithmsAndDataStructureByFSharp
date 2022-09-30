# https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_1_C/review/5007394/Kite_kuma/Python3
import math

n = int(input())
a = list(map(int, input().split()))
ans = a[0]
for x in a:
    ans = ans // math.gcd(ans,x) * x
print(ans)
