# https://atcoder.jp/contests/tessoku-book/submissions/36746499
(N,),*T=[[*map(int,t.split())]for t in open(0)]
D=eval('[0]*(N+2),'*(N+2))
B=lambda k:N>k>=0and(l<=T[k][0]<=r)*T[k][1]
for l in range(1,N+1):
 for r in range(N,0,-1):D[l][r]=max(D[l][r+1]+B(r),D[l-1][r]+B(l-2))
print(max(D[i][i]for i in range(N)))
