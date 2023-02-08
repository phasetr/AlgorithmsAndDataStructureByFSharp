def solve(n,A): s = sum(A); return s*s
n = int(input())
A = list(map(int,input().split()))
print(solve(n,A))

def test():
    n,A = 2,[1,2]
    print(solve(n,A) == 9)
    n,A = 3,[1,10,100]
    print(solve(n,A) == 12321)
