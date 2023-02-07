from functools import reduce
def solve(n,S): return len(reduce(lambda x,y: x+y, S))
n = int(input())
S = [input() for i in range(n)]
print(solve(n,S))

def test():
    n,S = 3,["hello","algo","method"]
    print(solve(n,S))
    print(solve(n,S) == 15)
