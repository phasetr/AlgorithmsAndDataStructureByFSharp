# https://atcoder.jp/contests/tessoku-book/submissions/38501351
n, q = map(int, input().split())
s = input()
mod = 998244353

L = [0]
R = [0]
for i in range(n):
    L.append((L[-1]*100+(ord(s[i])-96))%mod)
for i in range(n-1, -1, -1):
    R.append((R[-1]*100+(ord(s[i])-96))%mod)

for i in range(q):
    l, r = map(int, input().split())
    x = (L[r]-L[l-1]*pow(100, r-l+1, mod)) % mod
    y = (R[-l]-R[-(r+1)]*pow(100, r-l+1, mod)) % mod
    if x == y:
        print("Yes")
    else:
        print("No")
