# https://atcoder.jp/contests/tessoku-book/submissions/36595326
from collections import deque

N,M,As,Is = 4,2,["0","1","1","0"],[[1,2,3],[2,3,4]]
def solve(N,M,As,Is):
    A = int("".join(As),2)
    bit = []
    for i in range(M):
        Bit = ["0"]*N
        xyz = Is[i]
        x,y,z = xyz[0],xyz[1],xyz[2]
        Bit[x-1],Bit[y-1],Bit[z-1]="1","1","1"
        bit.append(int("".join(Bit),2))

    ans = [-1]*(1<<N)
    ans[A] = 0
    d = deque()
    d.append(A)
    while d:
        now = d.popleft()
        for i in bit:
            Next = now^i
            if ans[Next]==-1:
                ans[Next] = ans[now]+1
                d.append(Next)

    return(ans[-1])

N,M=map(int,input().split())
As = input().split()
Is = [list(map(int, input().split())) for _ in range(M)]
print(solve(N, M, As, Is))

print(solve(4,2,["0","1","1","0"],[[1,2,3],[2,3,4]]) == 2)
