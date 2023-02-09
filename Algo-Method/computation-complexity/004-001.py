def solve(n,A,q,K):
    xs = [0]
    for a in A: xs.append(xs[-1]+a)
    return map(lambda i: xs[i], K)
n = input()
A = list(map(int,input().split()))
q = int(input())
K = [int(input()) for _ in range(q)]
for i in solve(n,A,q,K): print(i)

def test():
    n,A,q,K = 5,[1,2,3,4,5],3,[3,4,5]
    print(list(solve(n,A,q,K)) == [6,10,15])
    n,A,q,K = 10,[1,1,1,1,1,1,1,1,1,1],3,[0,10,10]
    print(list(solve(n,A,q,K)))
    print(list(solve(n,A,q,K)) == [0,10,10])
