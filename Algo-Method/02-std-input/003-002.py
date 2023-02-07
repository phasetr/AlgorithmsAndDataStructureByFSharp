from functools import reduce
def solve(n,a): return reduce(lambda x,y: x*y, a)
n = input()
a = map(int,input().split())
print(solve(n,a))

def test():
    print(solve(3,[10,20,30]) == 6000)
