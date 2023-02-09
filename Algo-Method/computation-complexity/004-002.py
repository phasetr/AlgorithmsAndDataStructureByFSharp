def solve(n,A,q,lr):
    s = [0]
    for a in A: s.append(s[-1]+a)
    return [s[r]-s[l] for (l,r) in lr]
n = int(input())
A = list(map(int,input().split()))
q = int(input())
lr = [tuple(map(int,input().split())) for _ in range(q)]
for i in solve(n,A,q,lr): print(i)

def test():
    n,A,q,lr = 5,[1,2,3,4,5],3,[(1,3),(0,4),(0,5)]
    print(list(solve(n,A,q,lr)))
    print(list(solve(n,A,q,lr)) == [5,10,15])
    n,A,q,lr = 10,[1,1,1,1,1,1,1,1,1,1],3,[(0,1),(5,9),(5,9)]
    print(list(solve(n,A,q,lr)))
    print(list(solve(n,A,q,lr)) == [1,4,4])
