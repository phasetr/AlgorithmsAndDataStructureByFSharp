def solve(n,A): return min(A)
n = int(input())
A = list(map(int,input().split()))
print(solve(n,A))

def test():
    n,A = 3,[27,18,28]
    print(solve(n,A) == 18)
