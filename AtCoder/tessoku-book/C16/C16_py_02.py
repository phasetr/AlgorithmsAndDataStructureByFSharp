# https://atcoder.jp/contests/tessoku-book/submissions/38164143
N,M,K=map(int, input().split())
D={}
A=[]
for i in range(M):
  a,s,b,t=map(int, input().split())
  if s not in D:
    D[s]=[]
    A.append(s)
  D[s].append((0,t,a-1,b-1))
  if t+K not in D:
    D[t+K]=[]
    A.append(t+K)
A=sorted(list(set(A)))
dp=[0]*N
for a in A:
  DD=sorted(D[a],reverse=True,key=lambda x: x[0])
  for d,t,p,q in DD:
    if d==0:
      D[t+K].append((1,dp[p]+1,p,q))
    else:
      dp[q]=max(dp[q],t)
print(max(dp))
