def solve(n,A):
    s1 = sum(A)
    s2 = sum(map(lambda a: a**2, A))
    return (s1**2-s2)//2
n = int(input())
A = list(map(int,input().split()))
print(solve(n,A))

def test():
    n,A = 2,[1,2]
    print(solve(n,A) == 2)
    n,A = 3,[1,10,100]
    print(solve(n,A) == 1110)
