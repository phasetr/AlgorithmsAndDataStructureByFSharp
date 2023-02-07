def solve(n,a): return sum(a)
n = input()
a = map(int,input().split())
print(solve(n,a))

def test():
    print(solve(3,[10,20,30]) == 60)
