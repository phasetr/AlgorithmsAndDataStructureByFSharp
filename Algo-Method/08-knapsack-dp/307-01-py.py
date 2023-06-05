N = int(input())
As = map(int,input().split())

def solve(As):
    Bs = list(filter(lambda x: x>=0, As))
    return 0 if len(Bs) == 0 else sum(Bs)

print(solve(As))

def test():
    N,As = 3, [7,-6,9]
    print(solve(As) == 16)
    N,As = 2, [-9,-16]
    print(solve(As) == 0)
