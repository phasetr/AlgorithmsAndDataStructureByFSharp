# https://atcoder.jp/contests/tessoku-book/submissions/36595326
from collections import deque
N,M=map(int,input().split())
A=int("".join(input().split()),2)
bit=[]
for i in range(M):
    Bit=["0"]*N
    x,y,z=map(int,input().split())
    Bit[x-1],Bit[y-1],Bit[z-1]="1","1","1"
    bit.append(int("".join(Bit),2))

ans=[-1]*(1<<N)
ans[A]=0
d=deque()
d.append(A)
while d:
    now=d.popleft()
    for i in bit:
        Next=now^i
        if ans[Next]==-1:
            ans[Next]=ans[now]+1
            d.append(Next)
print(ans[-1])
