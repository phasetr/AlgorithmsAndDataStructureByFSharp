# https://atcoder.jp/contests/tenka1-2018/submissions/19558151
N = int(input())
A = [int(input()) for i in range(N)]
A.sort()
ans = 0
if N%2==0:
  ans = 2*sum(A[N//2:])-2*sum(A[:N//2])-A[N//2]+A[N//2-1]
else:
  ans = 2*(sum(A[N//2+1:])-sum(A[:N//2]))+max(A[N//2]-A[N//2+1],A[N//2-1]-A[N//2])
print(ans)
