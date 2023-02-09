def solve(n,L,q,lr):
    M = 100001
    c = [0]*(M+1)
    for l in L: c[l] += 1
    for i in range(M): c[i+1] += c[i]
    return [c[r]-c[l-1] for (l,r) in lr]
n = int(input())
L = list(map(int,input().split()))
q = int(input())
lr = [tuple(map(int,input().split())) for _ in range(q)]
for i in solve(n,L,q,lr): print(i)

def test():
    n,L,q,lr = 5,[10,40,25,50,20],2,[(10,30),(30,40)]
    print(solve(n,L,q,lr) == [3,1])
    n,L,q,lr = 10,[10,10,10,10,10,10,10,10,10,10],3,[(1,20),(1,20),(100,120)]
    print(solve(n,L,q,lr) == [10,10,0])
