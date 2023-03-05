# https://atcoder.jp/contests/tessoku-book/submissions/36083255
(n,t),*A=[map(int,s.split())for s in open(0)]
X,*Q=[0]*-~n,[t,0]
G=[[]for _ in X]
for a,b in A:G[a]+=b,;G[b]+=a,
for i,p in Q:
    for c in G[i]:
        if c!=p:Q+=[c,i],
for i,p in Q[::-1]:X[p]=max(X[p],X[i]+1)
print(*X[1:])
