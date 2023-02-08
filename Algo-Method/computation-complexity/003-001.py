"""
n,a = 3,[3,1,4]
"""
def solve(n,a): return max(a) - min(a)
n = int(input())
a = list(map(int,input().split()))
print(solve(n,a))

def test():
    n,a = 3,[3,1,4]
    print(solve(n,a) == 3)
    n,a = 1,[10]
    print(solve(n,a) == 0)
    n,a = 5,[1,1,1000000000,1000000000]
    print(solve(n,a) == 999999999)
