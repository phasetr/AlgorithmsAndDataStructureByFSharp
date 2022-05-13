# https://atcoder.jp/contests/dp/submissions/30484080
from numpy import*
(n,k),*a=[int_(t.split())for t in open(0)]
a=matrix(a,'O')
M=10**9+7
s=1
while k:s*=~k%2or a;k//=2;a=a*a%M
print(sum(s)%M)
