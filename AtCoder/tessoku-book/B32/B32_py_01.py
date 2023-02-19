# https://atcoder.jp/contests/tessoku-book/submissions/34882088
n,k,*A = map(int,open(0).read().split())
dp = [False]*(n+1)
for i in range(1,n+1):
  dp[i] = any(not dp[i-a] for a in A if i >= a)
if dp[n]:
  print("First")
else:
  print("Second")
