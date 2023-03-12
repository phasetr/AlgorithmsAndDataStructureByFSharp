# https://atcoder.jp/contests/tessoku-book/submissions/38963558
n,k,*a=map(int,open(0).read().split())
ok,ng=1,10**17
while abs(ok-ng)>1:
  mid=(ok+ng)//2
  b=sum(i*10**6//mid for i in a)
  if b>=k:
    ok=mid
  else:
    ng=mid
print(*[i*10**6//ok for i in a])
