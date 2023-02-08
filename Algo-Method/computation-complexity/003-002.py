def solve(n,A):
    s = sum(A)
    return max([s-a for a in A])
n = int(input())
A = list(map(int,input().split()))
print(solve(n,A))

def test():
    n,A = 3,[3,1,4]
    print(solve(n,A) == 7)
    n,A = 6,[1000000000,1000000000,1000000000,1000000000,1000000000,1000000000]
    print(solve(n,A) == 5000000000)
