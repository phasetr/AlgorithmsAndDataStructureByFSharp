# https://atcoder.jp/contests/tessoku-book/submissions/34890241
mod = 10**9+7
n,p,*A = map(int,open(0).read().split())
h = {}
ans = 0
for i in range(n):
  a = A[i]%mod
  if a == 0:
    if p == 0:
      ans += i
  else:
    ans += h.get(p*pow(a,mod-2,mod)%mod,0)
  h[a] = h.get(a,0)+1
print(ans)
