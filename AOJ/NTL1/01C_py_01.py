# https://onlinejudge.u-aizu.ac.jp/solutions/problem/NTL_1_C/review/2688019/kyuna/Python3
import math
input();b=1
for a in list(map(int,input().split())):b=a*b//math.gcd(a,b)
print(b)
