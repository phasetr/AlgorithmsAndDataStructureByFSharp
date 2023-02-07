def solve(n,A): return sum(A)//n
n = int(input())
A = list(map(int,input().split()))
print(solve(n,A))

def test():
    n,A = 3,[31,41,59]
    print(solve(n,A) == 43)
