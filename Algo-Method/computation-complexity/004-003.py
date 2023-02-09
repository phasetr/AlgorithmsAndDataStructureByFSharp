def solve(n,D,q,lr):
    s = [0]
    for d in D: s.append(s[-1]+d)
    return [s[r]-s[l] for (l,r) in lr]
n = int(input())
D = list(map(int,input().split()))
q = int(input())
lr = [tuple(map(int,input().split())) for _ in range(q)]
for i in solve(n,D,q,lr): print(i)

def test():
    n,D,q,lr = 3,[3,5],2,[(0,2),(1,2)]
    print(solve(n,D,q,lr))
    print(solve(n,D,q,lr) == [8,5])
    n,D,q,lr = 4,[1,10,100],3,[(1,3),(1,3),(1,3)]
    print(solve(n,D,q,lr))
    print(solve(n,D,q,lr) == [110,110,110])
