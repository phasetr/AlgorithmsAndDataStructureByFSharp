def solve(n,a): return list(map(lambda x: x%10, a))
n = input()
a = map(int,input().split())
for x in solve(n,a): print(x)

def test():
    n = 3
    a = [31,41,59]
    map(print,solve(n, a))
    print(solve(n,a) == [1,1,9])
